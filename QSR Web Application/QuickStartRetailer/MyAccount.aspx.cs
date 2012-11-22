using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            else
            {
                if (!Page.IsPostBack)
                {
                    
                }
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            //Log out
            Session.Clear();
            Response.Redirect("~/Index.aspx");
        }
    }
}
