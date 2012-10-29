using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdministratorID"] == null)
            {
                //Not logged in, so hide the admin user panel and toolbar
                divUserPanel.Visible = false;
                appleNav.Visible = false;
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    //Show the admin user panel and toolbar
                    divUserPanel.Visible = true;
                    appleNav.Visible = true;

                    //Get the first name of the current user
                    Administrator admin = new Administrator();
                    admin.GetAdministratorByID(Convert.ToInt32(Session["AdministratorID"]));
                    LabelWelcome.Text = "Welcome, " + admin.FirstName;
                    

                }
            }
        }

        protected void LinkButtonLogout_Click(object sender, EventArgs e)
        {
            //Clear the session on logout
            Session.Clear();

            //Redirect to login page
            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}
