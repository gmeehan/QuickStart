using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.IO;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class EditProductForm : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Obtain product code from query string
                string prodcd = Request.QueryString["prodcd"].ToString();

                //Get product by its code
                Product prod = new Product();
                prod.GetProductByCode(prodcd);

                //Populate categories dropdown list
                Category cat = new Category();
                List<Category> categories = cat.GetAllCategories(true);
                DropDownListCategory.DataSource = categories;
                DropDownListCategory.DataTextField = "Name";
                DropDownListCategory.DataValueField = "CategoryID";
                DropDownListCategory.DataBind();

                //Put product details into fields
                LabelProductCode.Text = Request.QueryString["prodcd"].ToString();
                TextBoxName.Text = prod.Name.ToString();
                TextBoxBrand.Text = prod.Brand.ToString();
                TextBoxDescription.Text = prod.Description.ToString();
                DropDownListCategory.SelectedValue = prod.CategoryID.ToString();
                TextBoxMSRP.Text = prod.Msrp.ToString();
                CheckBoxFreeShipping.Checked = Convert.ToBoolean(prod.IsFreeShipping);
                CheckBoxTaxFree.Checked = Convert.ToBoolean(prod.IsTaxFree);
                TextBoxQtyInStock.Text = prod.QuantityInStock.ToString();
                CheckBoxQtyUnlimited.Checked = Convert.ToBoolean(prod.IsQuantityUnlimited);
                LabelCreated.Text = Convert.ToDateTime(prod.Created).ToShortDateString();
                if (Convert.ToDateTime(prod.Modified) > DateTime.MinValue)
                {
                    LabelModified.Text = Convert.ToDateTime(prod.Modified).ToShortDateString();
                }
                else
                {
                    LabelModified.Text = "N/A";
                }

                //Attempt to display image (if it is found)
                try
                {
                    Image1.ImageUrl = "~/Images/Product_Images/" + LabelProductCode.Text + ".jpg";
                }
                catch (Exception)
                {
                    Image1.ImageUrl = "";
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    //Get the file extension
                    FileInfo finfo = new FileInfo(FileUpload1.FileName);
                    string fileExtension = finfo.Extension.ToLower();

                    //Save file to server
                    FileUpload1.SaveAs(Server.MapPath("~/Images/Product_Images/") +
                         LabelProductCode.Text + fileExtension);
                }
                catch (Exception ex)
                {
                    LabelOutput.Text = "ERROR: " + ex.Message.ToString();
                    return;
                }
            else
            {
                LabelOutput.Text = "You have not specified a file.";
                return;
            }

            try
            {
                //Create a product object
                Product prod = new Product();

                //Get existing product by its code
                prod.GetProductByCode(LabelProductCode.Text);

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
                prod.Modified = DateTime.Now;

                //Update the product
                if (prod.UpdateProduct())
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "window.top.window.$.fancybox.close();", true);
                    //Response.Redirect("~/Admin/Products.aspx");
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