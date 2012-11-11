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

            if (!Page.IsPostBack)
            {
                //Get all active categories
                Category cat = new Category();
                List<Category> cats = cat.GetAllCategories(true);

                foreach (var cs in cats)
                {
                    MenuItem mi = new MenuItem();
                    MenuItem m = new MenuItem();
                    foreach (MenuItem main in appleNav.Items)
                    {
                        if (main.Text == "Categories")
                        {
                            m = main;
                            break;
                        }
                    }

                    if (cs.ParentCategoryID > 0)
                    {
                        foreach (MenuItem ms in m.ChildItems)
                        {
                            if (ms.Value == cs.ParentCategoryID.ToString())
                            {
                                mi.Value = cs.ParentCategoryID.ToString();
                                mi.Text = cs.Name.ToString();
                                mi.NavigateUrl = "~/Category.aspx?id=" + cs.CategoryID;
                                ms.ChildItems.Add(mi);
                                break;
                            }
                        }
                    }
                    else
                    {
                        mi.Value = cs.CategoryID.ToString();
                        mi.Text = cs.Name.ToString();
                        mi.Selectable = false;
                        m.ChildItems.Add(mi);
                    }
                }
            }
            
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
