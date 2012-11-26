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
            price.Text = prod.Msrp.ToString();
            itemPic.ImageUrl = "~/Images/Product_Images/" + prodcd + ".jpg";
            itemPic.Height = 100;
            itemPic.Width = 100; ;
        }

        public void addCartClick(object sender, EventArgs e)
        {
            var list = new List<Tuple<string, int>>();
            if (Session["stringList"] != null)
            {
                list = (List<Tuple<string, int>>)(Session["stringList"]);
            }
            list.Add(new Tuple<string,int>(prodcd, 1));
            Session["stringList"] = list;

            Response.Redirect("~/CartItems.aspx");
        }
    }
}
