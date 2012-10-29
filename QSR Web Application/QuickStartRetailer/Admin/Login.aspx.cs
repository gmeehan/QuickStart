using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer.Admin
{
    public partial class _Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            //Create an Administrator object and attempt login
            Administrator admin = new Administrator();
            admin.Login(TextBoxUsername.Text, TextBoxPassword.Text);

            //If login was successful...
            if (admin.AdministratorID > 0)
            {
                Session.Add("AdministratorID", admin.AdministratorID);
                Response.Redirect("Index.aspx");
            }
            else //if not successful...
            {
                LabelOutput.ForeColor = System.Drawing.Color.Red;
                LabelOutput.Text = "Login Failed.<br />Please verify username and password.";
            }
        }
    }
}
