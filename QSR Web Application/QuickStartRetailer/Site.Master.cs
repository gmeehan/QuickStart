using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                //Not logged in
                LabelWelcome.Text = "Welcome, Guest";
                LinkButtonLoginLogout.Text = "Login";
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    //Get the first name of the current user
                    User user = new User();
                    user.GetUserByID(Convert.ToInt32(Session["UserID"]));
                    LabelWelcome.Text = "Welcome, " + user.FirstName;

                    //Change login button to logout
                    LinkButtonLoginLogout.Text = "Logout";
                }
            }

            //Get all active categories
            Category cat = new Category();
            List<Category> cats = cat.GetAllCategories(true);

            //TO DO: PLACE ALL CATEGORIES AND SUB-CATEGORIES IN MASTER PAGE'S "CATEGORIES" MENU ITEM
        }

        protected void LinkButtonLoginLogout_Click(object sender, EventArgs e)
        {
            //If not logged in...
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else //If logged in...
            {
                //Log out
                Session.Clear();
                Response.Redirect("~/Index.aspx");
            }
        }
    }
}
