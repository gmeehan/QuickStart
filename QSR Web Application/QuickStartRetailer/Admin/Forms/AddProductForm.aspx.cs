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
                string prodcd = prod.AddProduct();

                //If it worked...
                if (prodcd != "")
                {
                    if (FileUpload1.HasFile)
                        try
                        {
                            //Get the file extension
                            FileInfo finfo = new FileInfo(FileUpload1.FileName);
                            string fileExtension = finfo.Extension.ToLower();

                            //Save file to server
                            FileUpload1.SaveAs(Server.MapPath("~/Images/Product_Images/") +
                                 prodcd + fileExtension);
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

                    //Close the FancyBox
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "window.top.window.$.fancybox.close();", true);
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
                return;
            }
        }
    }
}