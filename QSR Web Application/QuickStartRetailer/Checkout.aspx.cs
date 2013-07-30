using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;

using QSRWebObjects;
using System.Data; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if logged in
            if (Session["UserID"] == null)
            {
                //Set a session variable to indicate return to checkout after login
                Session.Add("ReturnToCheckout", true);
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                List<Tuple<string, int>> list = new List<Tuple<string, int>>();
                if (Session["cartList"] != null)
                {
                    list = (List<Tuple<string, int>>)(Session["cartList"]);
                }
                else
                {
                    Response.Redirect("~/Index.aspx");
                }

                //Datatable that will be bound to the checkout datalist
                DataTable dt = new DataTable();
                dt.Columns.Add("Prodcd");
                dt.Columns.Add("Quantity");
                dt.Columns.Add("Name");
                dt.Columns.Add("Msrp");

                foreach (Tuple<string, int> item in list)
                {
                    DataRow dr = dt.NewRow();
                    dr["Prodcd"] = item.Item1;
                    dr["Quantity"] = item.Item2;

                    //Get product info
                    Product prod = new Product();
                    prod.GetProductByCode(item.Item1);
                    dr["Name"] = prod.Name.ToString();
                    dr["Msrp"] = prod.Msrp;

                    //Add checkout item to datasource list
                    dt.Rows.Add(dr);
                }

                //Bind to the datalist
                DataListCheckout.DataSource = dt;
                DataListCheckout.DataBind();
            }
        }

        protected void Check_Changed(Object sender, EventArgs e)
        {
            var id = ((CheckBox)sender).InputAttributes["value"];

            foreach (DataListItem item in DataListCheckout.Items)
            {
                HtmlContainerControl div = (HtmlContainerControl)item.FindControl("SpecifiedDeliveryInfoDiv");
                if (div.Attributes["rowID"] == id)
                {
                    CheckBox cb = (CheckBox)sender;
                    if (cb.Checked)
                    {
                        div.Visible = false;
                    }
                    else
                    {
                        div.Visible = true;
                    }
                }
            }
        }

        protected void DataListCheckout_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var item = e.Item.DataItem as DataRowView;
                if (item != null)
                {
                    //Set the checkbox value attribute
                    var chk = e.Item.FindControl("CheckBoxUseUserAddress") as CheckBox;
                    if (chk != null)
                    {
                        chk.InputAttributes.Add("value", item["Prodcd"].ToString());
                    }

                    //Set the dropdownlist datasource
                    DropDownList spDDL = e.Item.FindControl("dropStateProv") as DropDownList;
                    StateProvince sp = new StateProvince();
                    List<StateProvince> states = sp.GetAllStatesProvinces();
                    spDDL.DataSource = states;
                    spDDL.DataTextField = "Name";
                    spDDL.DataValueField = "StateProvinceID";
                    spDDL.DataBind();

                    //Get all ProductDeliveryType objects for this prodcd
                    ProductDeliveryType pdt = new ProductDeliveryType();
                    List<ProductDeliveryType> pdtypes = pdt.GetAllProductDeliveryTypesByProdCode(item["Prodcd"].ToString());

                    //For each ProductDeliveryType, add its associated DeliveryType object to the list
                    List<DeliveryType> dTypes = new List<DeliveryType>();
                    foreach (ProductDeliveryType pdtype in pdtypes)
                    {
                        DeliveryType delType = new DeliveryType();
                        delType.GetDeliveryTypeByID(pdtype.DeliveryTypeID);
                        dTypes.Add(delType);
                    }

                    //Assign list of DeliveryType to data list
                    DropDownList delTypesDDL = e.Item.FindControl("DropDownListDeliveryType") as DropDownList;
                    delTypesDDL.DataSource = dTypes;
                    delTypesDDL.DataTextField = "Name";
                    delTypesDDL.DataValueField = "DeliveryTypeID";
                    delTypesDDL.DataBind();
                }
            }
        }

        protected void ButtonGoToPayInfo_Click(object sender, EventArgs e)
        {
            //Get a reference to the original datasource for the datalist (doesn't take into account DeliveryType changes)
            DataTable dt = new DataTable();
            dt.Columns.Add("Prodcd");
            dt.Columns.Add("Name");
            dt.Columns.Add("Msrp", System.Type.GetType("System.Double"));
            dt.Columns.Add("Quantity");
            dt.Columns.Add("DeliveryTypeID");
            dt.Columns.Add("DeliveryTypeName");
            dt.Columns.Add("DeliveryCost", System.Type.GetType("System.Double"));
            dt.Columns.Add("Taxes", System.Type.GetType("System.Double"));
            dt.Columns.Add("Total", System.Type.GetType("System.Double"));
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Address1");
            dt.Columns.Add("Address2");
            dt.Columns.Add("City");
            dt.Columns.Add("Country");
            dt.Columns.Add("StateProvinceID");
            dt.Columns.Add("StateProvinceName");
            dt.Columns.Add("ZipPostalCode");
            dt.Columns.Add("Email");

            //For each data list item...
            for (int i = 0; i < DataListCheckout.Items.Count; i++)
            {
                //Get reference to this data list item
                DataListItem item = DataListCheckout.Items[i];
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    //Get reference to original datarow for this datalist item
                    DataRow dr = dt.NewRow();

                    //Get reference to the product for this datalist item
                    Product prod = new Product();
                    prod.GetProductByCode(DataListCheckout.DataKeys[i].ToString());

                    dr["Prodcd"] = prod.ProductCode;
                    dr["Name"] = prod.Name;
                    dr["Msrp"] = prod.Msrp;
                    dr["Quantity"] = ((Label)(item.FindControl("LabelQuantity"))).Text;
                    dr["DeliveryTypeID"] = ((DropDownList)(item.FindControl("DropDownListDeliveryType"))).SelectedValue;
                    
                    //Get the delivery type name and cost
                    DeliveryType dtype = new DeliveryType();
                    dtype.GetDeliveryTypeByID(Convert.ToInt32(dr["DeliveryTypeID"]));
                    dr["DeliveryTypeName"] = dtype.Name;
                    dr["DeliveryCost"] = dtype.Cost;

                    if (((CheckBox)item.FindControl("CheckBoxUseUserAddress")).Checked == true) //use account delivery info
                    {
                        //Get the current user
                        User user = new User();
                        user.GetUserByID(Convert.ToInt32(Session["UserID"]));
                        dr["FirstName"] = user.FirstName;
                        dr["LastName"] = user.LastName;
                        dr["Address1"] = user.Address1;
                        dr["Address2"] = user.Address2;
                        dr["City"] = user.City;
                        dr["StateProvinceID"] = user.StateProvinceID;
                        //dr["Country"] = user.  MUST DEAL WITH COUNTRY LATER
                        dr["ZipPostalCode"] = user.ZipCodePostal;
                        dr["Email"] = user.Email;
                    }
                    else //use customized delivery info
                    {
                        dr["FirstName"] = ((TextBox)(item.FindControl("txtFName"))).Text;
                        dr["LastName"] = ((TextBox)(item.FindControl("txtLName"))).Text;
                        dr["Address1"] = ((TextBox)(item.FindControl("txtAddress"))).Text;
                        dr["Address2"] = ((TextBox)(item.FindControl("txtAddress2"))).Text;
                        dr["City"] = ((TextBox)(item.FindControl("txtCity"))).Text;
                        //dr["Country"] = ((DropDownList)(item.FindControl("dropCountry"))).SelectedValue; MUST DEAL WITH COUNTRY LATER
                        dr["StateProvinceID"] = ((DropDownList)(item.FindControl("dropStateProv"))).SelectedValue;
                        dr["ZipPostalCode"] = ((TextBox)(item.FindControl("txtZipPostal"))).Text;
                        dr["Email"] = ((TextBox)(item.FindControl("txtEmail"))).Text;
                    }

                    //Get the state/province name and tax cost
                    StateProvince sp = new StateProvince();
                    sp.GetStateProvinceByID(Convert.ToInt32(dr["StateProvinceID"]));
                    dr["StateProvinceName"] = sp.Name;
                    dr["Taxes"] = sp.TaxRatePercentage / 100 * Convert.ToDouble(dr["Msrp"]);

                    //Calculate the total cost
                    dr["Total"] = Convert.ToDouble(dr["Msrp"]) + Convert.ToDouble(dr["DeliveryCost"]) + Convert.ToDouble(dr["Taxes"]);

                    //Add row to datatable
                    dt.Rows.Add(dr);
                }
            }

            //Add checkout list to session
            Session.Add("CheckoutDataTable",dt);

            //Go to next page
            Response.Redirect("~/PaymentInfo.aspx");
        }
    }
}
