using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer.Admin
{
    public partial class _Pricing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdministratorID"] == null)
                Response.Redirect("~/Admin/Login.aspx");
            else
            {
                if (!Page.IsPostBack)
                {

                }
            }
        }
    }
}
