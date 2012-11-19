using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class EditUserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Obtain User ID from query string
                int userid = Convert.ToInt32(Request.QueryString["userid"]);

                //Get User by its code
                User user = new User();
                user.GetUserByID(userid);

                //Populate States/Provinces dropdown list
                StateProvince sp = new StateProvince();
                List<StateProvince> states = sp.GetAllStatesProvinces();
                DropDownListStateProvince.DataSource = states;
                DropDownListStateProvince.DataTextField = "Name";
                DropDownListStateProvince.DataValueField = "StateProvinceID";
                DropDownListStateProvince.DataBind();

                //Put user details into fields
                LabelUserID.Text = Request.QueryString["userid"].ToString();
                TextBoxUsername.Text = Convert.ToString(user.Username);
                TextBoxPassword.Text = Convert.ToString(user.Password);
                TextBoxSalutation.Text = Convert.ToString(user.Salutation);
                TextBoxFirstName.Text = Convert.ToString(user.FirstName);
                TextBoxLastName.Text = Convert.ToString(user.LastName);
                TextBoxAddress1.Text = Convert.ToString(user.Address1);
                TextBoxAddress2.Text = Convert.ToString(user.Address2);
                TextBoxCity.Text = Convert.ToString(user.City);
                DropDownListStateProvince.SelectedValue = Convert.ToString(user.StateProvinceID);
                TextBoxZipPostalCode.Text = Convert.ToString(user.ZipCodePostal);
                TextBoxEmail.Text = Convert.ToString(user.Email);
                CheckBoxIsReceiveNewsletters.Checked = Convert.ToBoolean(user.IsReceiveNewsletters);
                LabelCreated.Text = Convert.ToDateTime(user.Created).ToShortDateString();
                if (Convert.ToDateTime(user.Modified) > DateTime.MinValue)
                {
                    LabelModified.Text = Convert.ToDateTime(user.Modified).ToShortDateString();
                }
                else
                {
                    LabelModified.Text = "N/A";
                }
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a User object
                User user = new User();

                //Get existing user by its id
                user.GetUserByID(Convert.ToInt32(LabelUserID.Text));

                //Update all fields
                user.Username = TextBoxUsername.Text;
                user.Password = TextBoxPassword.Text;
                user.Salutation = TextBoxSalutation.Text;
                user.FirstName = TextBoxFirstName.Text;
                user.LastName = TextBoxLastName.Text;
                user.Address1 = TextBoxAddress1.Text;
                user.Address2 = TextBoxAddress2.Text;
                user.City = TextBoxCity.Text;
                user.StateProvinceID = Convert.ToInt32(DropDownListStateProvince.SelectedValue);
                user.ZipCodePostal = TextBoxZipPostalCode.Text;
                user.Email = TextBoxEmail.Text;
                user.IsReceiveNewsletters = CheckBoxIsReceiveNewsletters.Checked;
                user.Modified = DateTime.Now;

                //Update the product
                if (user.UpdateUser())
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "window.top.window.$.fancybox.close();", true);
                    //Response.Redirect("~/Admin/Users.aspx");
                }
                else
                {
                    LabelOutput.ForeColor = System.Drawing.Color.Red;
                    LabelOutput.Text = "Error: Update Failed";
                }
                
            }
            catch (Exception ex)
            {
                LabelOutput.ForeColor = System.Drawing.Color.Red;
                LabelOutput.Text = "Error: " + ex.Message;
            }
        }
    }
}