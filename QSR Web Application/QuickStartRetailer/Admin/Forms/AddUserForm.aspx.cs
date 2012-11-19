using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;

namespace QuickStartRetailer.Admin.Forms
{
    public partial class AddUserForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Populate States/Provinces dropdown list
                StateProvince sp = new StateProvince();
                List<StateProvince> states = sp.GetAllStatesProvinces();
                DropDownListStateProvince.DataSource = states;
                DropDownListStateProvince.DataTextField = "Name";
                DropDownListStateProvince.DataValueField = "StateProvinceID";
                DropDownListStateProvince.DataBind();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Create a User object
                User user = new User();

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
                user.Created = DateTime.Now;
                user.Modified = DateTime.MinValue;

                //Update the product
                if (user.AddUser() > 0)
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