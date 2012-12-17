using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _ProductInfo : System.Web.UI.Page
    {
        string prodcd;
        protected void Page_Load(object sender, EventArgs e)
        {
            prodcd = Request.QueryString["prodcd"].ToString();
            var prod = new Product();
            prod.GetProductByCode(prodcd);
            title.Text = prod.Name.ToString();
            productCode.Text = prod.ProductCode.ToString();
            brand.Text = prod.Brand.ToString();

            //Get configurations
            Configuration config = new Configuration();
            config.GetConfigurationByCode("xCurrencyCode");

            price.Text = "$" + prod.Msrp.ToString() + " " + config.Value;

            LabelDescription.Text = prod.Description.ToString();

            //If the unlimited quantity flag is set...
            if (Convert.ToBoolean(prod.IsQuantityUnlimited) == true)
            {
                quantity.Text = "Quantity Remaining: Unlimited";
            }
            else
            {
                quantity.Text = "Quantity Remaining: " + prod.QuantityInStock.ToString();
            }

            //Attempt to display image (if it is found)
            try
            {
                itemPic.ImageUrl = "~/Images/Product_Images/" + prodcd + ".jpg";
            }
            catch (Exception)
            {
                itemPic.ImageUrl = "";
            }

            //Fill gridview with available delivery types
            ProductDeliveryType pdt = new ProductDeliveryType();
            List<ProductDeliveryType> pdtypes = pdt.GetAllProductDeliveryTypesByProdCode(prodcd);

            List<DeliveryType> deliveryTypes = new List<DeliveryType>();
            foreach (ProductDeliveryType prodDelType in pdtypes)
            {
                DeliveryType dt = new DeliveryType();
                dt.GetDeliveryTypeByID(prodDelType.DeliveryTypeID);
                deliveryTypes.Add(dt);
            }

            GridViewDeliveryTypes.DataSource = deliveryTypes;
            GridViewDeliveryTypes.DataBind();

            //Don't show "Delivery Types" title if there are no delivery types listed
            if (deliveryTypes.Count == 0)
            {
                LabelDeliveryTypesTitle.Visible = false;
            }
        }

        public void addCartClick(object sender, EventArgs e)
        {
            var list = new List<Tuple<string, int>>();
            if (Session["cartList"] != null)
            {
                list = (List<Tuple<string, int>>)(Session["cartList"]);
            }
            list.Add(new Tuple<string,int>(prodcd, 1));
            Session["cartList"] = list;

            Response.Redirect("~/CartItems.aspx");
        }
    }
}
