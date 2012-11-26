using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.Web.UI.HtmlControls; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Load the slider images and details
            Configuration config = new Configuration();
            Product prod = new Product();

            //Slide 1
            config.GetConfigurationByCode("xFeaturedProduct1");
            prod.GetProductByCode(config.Value.ToString());

            //Attempt to display image (if it is found)
            try
            {
                ImageFeatured1.Src = "~/Images/Product_Images/" + prod.ProductCode + ".jpg";
            }
            catch (Exception)
            {
                ImageFeatured1.Src = "";
            }

            LabelFeaturedBrand1.Text = prod.Brand.ToString();
            LabelFeaturedName1.Text = prod.Name.ToString();
            LabelFeaturedPrice1.Text = "Only $" + prod.Msrp.ToString();
            LinkButtonFeatured1.PostBackUrl = "~/ProductInfo.aspx?prodcd=" + prod.ProductCode.ToString();

            //Slide 2
            config.GetConfigurationByCode("xFeaturedProduct2");
            prod.GetProductByCode(config.Value.ToString());

            //Attempt to display image (if it is found)
            try
            {
                ImageFeatured2.Src = "~/Images/Product_Images/" + prod.ProductCode + ".jpg";
            }
            catch (Exception)
            {
                ImageFeatured2.Src = "";
            }

            LabelFeaturedBrand2.Text = prod.Brand.ToString();
            LabelFeaturedName2.Text = prod.Name.ToString();
            LabelFeaturedPrice2.Text = "Only $" + prod.Msrp.ToString();

            //Slide 3
            config.GetConfigurationByCode("xFeaturedProduct3");
            prod.GetProductByCode(config.Value.ToString());

            //Attempt to display image (if it is found)
            try
            {
                ImageFeatured3.Src = "~/Images/Product_Images/" + prod.ProductCode + ".jpg";
            }
            catch (Exception)
            {
                ImageFeatured3.Src = "";
            }

            LabelFeaturedBrand3.Text = prod.Brand.ToString();
            LabelFeaturedName3.Text = prod.Name.ToString();
            LabelFeaturedPrice3.Text = "Only $" + prod.Msrp.ToString();

            //Slide 4
            config.GetConfigurationByCode("xFeaturedProduct4");
            prod.GetProductByCode(config.Value.ToString());

            //Attempt to display image (if it is found)
            try
            {
                ImageFeatured4.Src = "~/Images/Product_Images/" + prod.ProductCode + ".jpg";
            }
            catch (Exception)
            {
                ImageFeatured4.Src = "";
            }

            LabelFeaturedBrand4.Text = prod.Brand.ToString();
            LabelFeaturedName4.Text = prod.Name.ToString();
            LabelFeaturedPrice4.Text = "Only $" + prod.Msrp.ToString();

            //Load the data list (THIS IS A TEMPORARY WAY...CHOOSES FIRST 6 PRODUCTS)
            List<Product> allProducts = new List<Product>();
            allProducts = prod.GetAllProducts(true);
            List<Product> frontpageProducts = new List<Product>();
            for (int i = 0; i < 6; i++)
            {
                frontpageProducts.Add(allProducts[i]);
            }
            DataListProducts.DataSource = frontpageProducts;
            DataListProducts.DataBind();
        }

        protected void DataListProducts_ItemCreated(object sender, DataListItemEventArgs e)
        {
            //If this is the middle cell on the first row...
            if (e.Item.ItemIndex == 1)
            {
                //Add vertical borders to cell
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-left", "1px dotted silver");
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-right", "1px dotted silver");
            }
            if ((e.Item.ItemIndex - 1) % 3 == 0) //If this is the middle element on 2nd or later row
            {
                //Add vertical borders to cell
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-left", "1px dotted silver");
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-right", "1px dotted silver");
            }
        }
    }
}
