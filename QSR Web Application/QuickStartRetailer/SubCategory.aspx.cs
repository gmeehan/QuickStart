using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _SubCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Category cat = new Category();
            List<Category> cats = cat.GetAllCategories(true);

            foreach (var c in cats)
            {

                if (c.CategoryID == Int32.Parse(Request.QueryString["id"]))
                {

                    subCatDiv.InnerHtml = "<h2>" + c.Name + "</h2>";
                    break;
                }
            }
        }
    }
}
