using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class AddProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Populate categories dropdown list
                Category cat = new Category();
                List<Category> categories = cat.GetAllCategories(true);
                DropDownListCategory.DataSource = categories;
                DropDownListCategory.DataTextField = "Name";
                DropDownListCategory.DataValueField = "CategoryID";
                DropDownListCategory.DataBind();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a product object
                Product prod = new Product();

                //Get existing product by its code
                prod.GetProductByCode(TextBoxProductCode.Text);

                //Update all fields
                prod.Name = TextBoxName.Text;
                prod.Brand = TextBoxBrand.Text;
                prod.Description = TextBoxDescription.Text;
                prod.CategoryID = Convert.ToInt32(DropDownListCategory.SelectedValue);
                prod.Msrp = Convert.ToDouble(TextBoxMSRP.Text);
                prod.IsFreeShipping = CheckBoxFreeShipping.Checked;
                prod.IsTaxFree = CheckBoxTaxFree.Checked;
                prod.QuantityInStock = Convert.ToInt32(TextBoxQtyInStock.Text);
                prod.IsQuantityUnlimited = CheckBoxQtyUnlimited.Checked;
                prod.Created = DateTime.Now;
                prod.Modified = DateTime.MinValue;

                //Add the product
                if (prod.AddProduct() != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "window.top.window.$.fancybox.close();", true);
                    //Response.Redirect("~/Admin/Products.aspx");
                }
                else
                {
                    LabelOutput.ForeColor = System.Drawing.Color.Red;
                    LabelOutput.Text = "Error: Add Failed";
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