using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.IO; //Connect presentation layer to web object layer

namespace QuickStartRetailer.Admin
{
    public partial class _Appearance : System.Web.UI.Page
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

        protected void ButtonUpdateBannerLogo_Click(object sender, EventArgs e)
        {
            if (FileUploadBannerLogo.HasFile)
                try
                {
                    //Get the file extension
                    FileInfo finfo = new FileInfo(FileUploadBannerLogo.FileName);
                    string fileExtension = finfo.Extension.ToLower();

                    //Save file to serverSS
                    FileUploadBannerLogo.SaveAs(Server.MapPath("~/Images/Logo_Banner/Logo_Banner.png"));
                }
                catch (Exception ex)
                {
                    LabelOutput.Text = "ERROR: " + ex.Message.ToString();
                    return;
                }
            else
            {
                LabelOutput.Text = "You have not specified a file.";
                return;
            }
        }
    }
}
