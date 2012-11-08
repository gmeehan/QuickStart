﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class EditProductForm : System.Web.UI.Page
    {
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
                TextBoxName.Text = prod.Name;
                TextBoxBrand.Text = prod.Brand;
                TextBoxDescription.Text = prod.Description;
                DropDownListCategory.SelectedValue = prod.CategoryID.ToString();
                TextBoxMSRP.Text = prod.Msrp.ToString();
                CheckBoxFreeShipping.Checked = prod.IsFreeShipping;
                CheckBoxTaxFree.Checked = prod.IsTaxFree;
                TextBoxQtyInStock.Text = prod.QuantityInStock.ToString();
                CheckBoxQtyUnlimited.Checked = prod.IsQuantityUnlimited;
                LabelCreated.Text = prod.Created.ToShortDateString();
                if (prod.Modified > DateTime.MinValue)
                {
                    LabelModified.Text = prod.Modified.ToShortDateString();
                }
                else
                {
                    LabelModified.Text = "N/A";
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
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