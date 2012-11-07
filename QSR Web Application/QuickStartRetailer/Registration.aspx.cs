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
    public partial class _Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // dynamic dropdown loads here
            PopulateDropdownStateProv();
        }

        protected void drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDropdownStateProv();
        }

        public void PopulateDropdownStateProv()
        {
            string country = drop.SelectedItem.Text;
            SqlCommand cmd = new SqlCommand("SELECT * FROM StatesProvinces where country = '" + country + "'", new SqlConnection(ConfigurationManager.AppSettings["ConnString"]));
            cmd.Connection.Open();

            SqlDataReader ddlValues;
            ddlValues = cmd.ExecuteReader();

            dropStateProv.DataSource = ddlValues;
            dropStateProv.DataValueField = "StateProvinceID";
            dropStateProv.DataTextField = "Name";
            dropStateProv.DataBind();

            cmd.Connection.Close();
            cmd.Connection.Dispose();
        }

        protected void ButtonReg_Click(object sender, EventArgs e)
        {
            if (txtUName.Text != "" && txtPass.Text != "" && txtPass2.Text != "" && txtFName.Text != ""
                && txtLName.Text != "" && txtSal.Text != "" && txtAddress.Text != "" && txtCity.Text != ""
                && txtZip.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    //try and register new user
                    User user = new User();

                    //take all values from text boxes and send them to User.cs
                    user.Username = txtUName.Text;
                    if (txtPass.Text != txtPass2.Text)
                    {
                        LabelOutput.ForeColor = System.Drawing.Color.Red;
                        LabelOutput.Text = "Passwords do not match!";
                    }
                    else
                        user.Password = txtPass.Text;
                    user.Salutation = txtSal.Text;
                    user.FirstName = txtFName.Text;
                    user.LastName = txtLName.Text;
                    user.Address1 = txtAddress.Text;
                    user.Address2 = txtAddress2.Text;
                    user.City = txtCity.Text;
                    user.StateProvinceID = Convert.ToInt32(dropStateProv.SelectedValue);
                    user.ZipCodePostal = txtZip.Text;
                    user.Email = txtEmail.Text;
                    user.IsReceiveNewsletters = ckBox.Checked;

                    // call addUser method to add user and display success/fail text to user
                    user.AddUser();

                    if (user.UserID > 0)
                    {
                        LabelOutput.ForeColor = System.Drawing.Color.Green;
                        LabelOutput.Text = "Thank you " + txtUName.Text + "! You have successfully registered as a new user.";
                    }
                    else
                    {
                        LabelOutput.ForeColor = System.Drawing.Color.Red;
                        LabelOutput.Text = "Register Failed.<br />Please verify entered values.";
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    String strEx = ex.Message;
                    LabelOutput.ForeColor = System.Drawing.Color.Red;
                    LabelOutput.Text = "Problem Registering, try again";
                }
            }// end if
            else
            {
                LabelOutput.ForeColor = System.Drawing.Color.Red;
                LabelOutput.Text = "Problem Registering, some required fields have not been filled.";
            }
        }

        protected void dropStateProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
