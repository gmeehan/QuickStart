using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;

using QSRWebObjects; //Connect presentation layer to web object layer

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

                //Collection that will be bound to the checkout datalist
                List<CheckoutItem> coItems = new List<CheckoutItem>();

                foreach (Tuple<string, int> item in list)
                {
                    CheckoutItem coItem = new CheckoutItem();
                    coItem.Prodcd = item.Item1;
                    coItem.Quantity = item.Item2;

                    //Get product info
                    Product prod = new Product();
                    prod.GetProductByCode(item.Item1);
                    coItem.Name = prod.Name.ToString();
                    coItem.Msrp = prod.Msrp;

                    //Get all product delivery types
                    ProductDeliveryType pdt = new ProductDeliveryType();
                    List<ProductDeliveryType> pdtypes = pdt.GetAllProductDeliveryTypesByProdCode(prod.ProductCode.ToString());
                    foreach(ProductDeliveryType pdtype in pdtypes)
                    {
                        DeliveryType dt = new DeliveryType();
                        dt.GetDeliveryTypeByID(pdtype.DeliveryTypeID);
                        coItem.DeliveryTypes.Add(dt);
                    }

                    //Add checkout item to datasource list
                    coItems.Add(coItem);
                }

                //Bind to the datalist
                DataListCheckout.DataSource = coItems;
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
                var item = e.Item.DataItem as CheckoutItem;
                if (item != null)
                {
                    //Set the checkbox value attribute
                    var chk = e.Item.FindControl("CheckBoxUseUserAddress") as CheckBox;
                    if (chk != null)
                    {
                        chk.InputAttributes.Add("value", item.Prodcd.ToString());
                    }

                    //Set the dropdownlist datasource
                    DropDownList spDDL = e.Item.FindControl("dropStateProv") as DropDownList;
                    StateProvince sp = new StateProvince();
                    List<StateProvince> states = sp.GetAllStatesProvinces();
                    spDDL.DataSource = states;
                    spDDL.DataTextField = "Name";
                    spDDL.DataValueField = "StateProvinceID";
                    spDDL.DataBind();

                }
            }
        }

        protected void ButtonGoToPayInfo_Click(object sender, EventArgs e)
        {
            //Pass this to next page
            List<Hashtable> products_hshList = new List<Hashtable>();

            List<CheckoutItem> coItems = DataListCheckout.DataSource as List<CheckoutItem>;
            for (int i = 0; i < DataListCheckout.Items.Count; i++)
            {
                //Get reference to this data list row
                DataListItem item = DataListCheckout.Items[i];
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    //Get reference to CheckoutItem for this row
                    var coItem = coItems[i] as CheckoutItem;

                    Hashtable hsh = new Hashtable();
                    hsh.Add("prodcd", coItem.Prodcd);
                    hsh.Add("quantity", coItem.Quantity);
                    hsh.Add("deliverytypeid", Convert.ToInt32(((DropDownList)(item.FindControl("DropDownListDeliveryType"))).SelectedValue));
                    //Add it to the list (which will be passed into session)
                    products_hshList.Add(hsh);
                }
            }

            //Go to next page
            Response.Redirect("~/PaymentInfo.aspx");
        }
    }

    public class CheckoutItem
    {
        //Private members
        string _prodcd;
        int _quantity;
        string _name;
        double _msrp;
        List<DeliveryType> _deliveryTypes;

        public string Prodcd
        {
            get { return _prodcd; }
            set { _prodcd = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Msrp
        {
            get { return _msrp; }
            set { _msrp = value; }
        }

        public List<DeliveryType> DeliveryTypes
        {
            get { return _deliveryTypes; }
            set { _deliveryTypes = value; }
        }

        //Constructor
        public CheckoutItem()
        {
            _deliveryTypes = new List<DeliveryType>();

            //Add a default selection to the delivery type dropdownlist
            DeliveryType dt = new DeliveryType();
            dt.DeliveryTypeID = 0;
            dt.Name = "Select One...";
            _deliveryTypes.Add(dt);
        }
    }
}
