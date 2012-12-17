using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public class CartItem
    {
        private string prodcd;

        public string Prodcd
        {
            get { return prodcd; }
            set { prodcd = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string img;

        public string Img
        {
            get { return img; }
            set { img = value; }
        }
        private int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
    }

    public partial class _CartItems : System.Web.UI.Page
    {
        List<CartItem> prods = new List<CartItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["cartList"] != null)
                {
                    foreach (var i in (List<Tuple<string, int>>)(Session["cartList"]))
                    {
                        bool exists = false;
                        
                        foreach (var x in prods)
                        {
                            if (i.Item1 == x.Prodcd)
                            {
                                exists = true;
                                x.Qty++;
                                x.Total = x.Qty * x.Price;
                                break;
                            }
                        }
                        if (!exists)
                        {
                            var prod = new Product();
                            var cartItem = new CartItem();
                            prod.GetProductByCode(i.Item1);
                            cartItem.Prodcd = i.Item1;
                            cartItem.Name = prod.Name.ToString();
                            cartItem.Img = "~/Images/Product_Images/" + i.Item1 + ".jpg";
                            cartItem.Qty = i.Item2;
                            cartItem.Price = cartItem.Total = prod.Msrp;
                            prods.Add(cartItem);
                        }
                    }
                    DataListCartItems.DataSource = prods;
                    DataListCartItems.DataBind();
                }
            }
            //another test
        }

        public void DataListProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            /*
            var list = (List<Tuple<string, int>>)(Session["cartList"]);
            
            foreach (var i in list)
            {
                if (i.Item1 == e.CommandName)
                {
                    list.Add(new Tuple<string, int>(e.CommandName, 1));
                    break;
                }
            }
            Session["cartList"] = list;

            

            foreach (var x in prods)
            {
                if (e.CommandName == x.Prodcd)
                {
                    x.Qty++;
                    x.Total = x.Qty * x.Price;
                    DataListCartItems.DataSource = prods;
                    DataListCartItems.DataBind();
                    break;
                }
            }
             * */
        }

        protected void ButtonCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout.aspx");
        }

        protected void ButtonContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

    }
    
}
