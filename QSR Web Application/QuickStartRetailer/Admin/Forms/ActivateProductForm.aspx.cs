using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class ActivateProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtain product code from query string
                string prodcd = Request.QueryString["prodcd"].ToString();

                //Create a product object
                Product prod = new Product();

                //Get existing product by its code
                prod.GetProductByCode(prodcd);

                //Update all fields
                prod.Modified = DateTime.Now;
                prod.IsActive = true;

                //Update the product
                if (prod.UpdateProduct())
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "", "parent.location.reload(true);", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "window.top.window.$.fancybox.close();", true);
                }
                else
                {
                    LabelOutput.ForeColor = System.Drawing.Color.Red;
                    LabelOutput.Text = "Error: Activation Failed";
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