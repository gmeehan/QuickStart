using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.Data; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _PaymentInfo : System.Web.UI.Page
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
                DataTable dt = new DataTable();

                //If the checkout page completed successfully...
                if (Session["CheckoutDataTable"] != null)
                {
                    //Obtain the checkout datatable from the session
                    dt = Session["CheckoutDataTable"] as DataTable;
                }
                else
                {
                    Response.Redirect("~/Index.aspx");
                }

                //Bind to the datalist
                GridViewPaymentInfoItems.DataSource = dt;
                GridViewPaymentInfoItems.DataBind();
            }
        }

        double total = 0.00;
        protected void GridViewPaymentInfoItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //replace maounty with the name of property 
                total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Total"));
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblamount = (Label)e.Row.FindControl("LabelTotalSum");
                lblamount.Text = String.Format("{0:C}",total);
            }
        }

        protected void ButtonReturnToCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout.aspx");
        }

        protected void ButtonContinueToConfirmation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/OrderConfirmation.aspx");
        }
    }
}
