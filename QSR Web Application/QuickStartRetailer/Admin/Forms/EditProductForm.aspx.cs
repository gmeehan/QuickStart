using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class EditProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelProductCode.Text = Request.QueryString["prodcd"].ToString();
        }
    }
}