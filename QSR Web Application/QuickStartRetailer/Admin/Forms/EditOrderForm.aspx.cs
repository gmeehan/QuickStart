using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QSRWebObjects;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class EditOrderForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Obtain Order ID from query string
                int orderid = Convert.ToInt32(Request.QueryString["orderid"]);

                //Get Order by its orderid
                Order order = new Order();
                order.GetOrderByID(orderid);

                //Populate Delivery Types dropdown list
                DeliveryType dt = new DeliveryType();
                List<DeliveryType> dtypes = dt.GetAllDeliveryTypes();
                DropDownListDeliveryType.DataSource = dtypes;
                DropDownListDeliveryType.DataTextField = "Name";
                DropDownListDeliveryType.DataValueField = "DeliveryTypeID";
                DropDownListDeliveryType.DataBind();

                //Populate Users dropdown list
                User user = new User();
                List<User> users = user.GetAllUsers();
                DropDownListUsers.DataSource = users;
                DropDownListUsers.DataTextField = "Username";
                DropDownListUsers.DataValueField = "UserID";
                DropDownListUsers.DataBind();

                //Put order details into fields
                LabelOrderID.Text = Request.QueryString["orderid"].ToString();
                DropDownListUsers.SelectedValue = Convert.ToString(order.UserID);
                TextBoxSubtotal.Text = Convert.ToString(order.Subtotal);
                TextBoxTaxes.Text = Convert.ToString(order.Taxes);
                TextBoxDeliveryCost.Text = Convert.ToString(order.DeliveryCost);
                DropDownListDeliveryType.SelectedValue = Convert.ToString(order.DeliveryTypeID);
                TextBoxGrandTotal.Text = Convert.ToString(order.GrandTotal);
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a Order object
                Order order = new Order();

                //Get existing order by its id
                order.GetOrderByID(Convert.ToInt32(LabelOrderID.Text));

                //Update all fields
                order.UserID = Convert.ToInt32(DropDownListUsers.SelectedValue);
                order.Subtotal = Convert.ToDouble(TextBoxSubtotal.Text);
                order.Taxes = Convert.ToDouble(TextBoxTaxes.Text);
                order.DeliveryCost = Convert.ToDouble(TextBoxDeliveryCost.Text);
                order.DeliveryTypeID = Convert.ToInt32(DropDownListDeliveryType.SelectedValue);
                order.GrandTotal = Convert.ToDouble(TextBoxGrandTotal.Text);
                order.Modified = DateTime.Now;

                //Update the order
                if (order.UpdateOrder())
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "window.top.window.$.fancybox.close();", true);
                }
                else
                {
                    LabelOutput.ForeColor = System.Drawing.Color.Red;
                    LabelOutput.Text = "Error: Update Failed";
                }
            }
            catch (Exception ex)
            {
                LabelOutput.ForeColor = System.Drawing.Color.Red;
                LabelOutput.Text = "Error: " + ex.Message;
            }
        }
    }
}