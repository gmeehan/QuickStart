using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.Data.SqlClient;
using System.Configuration; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _MyProfile : System.Web.UI.Page
    {
               private int usrID;
        private int pID;
        private string country;
        private string state;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            else
            {
                if (!Page.IsPostBack)
                {
                    usrID = Convert.ToInt32(Session["UserID"]);
                    User usr = new User();
                    usr.GetUserByID(usrID);

                    // Load users data into the fields
                    txtUName.Text = usr.Username.ToString();
                    txtPass.Text = usr.Password.ToString();
                    txtSal.Text = usr.Salutation.ToString();
                    txtFName.Text = usr.FirstName.ToString();
                    txtLName.Text = usr.LastName.ToString();
                    txtAddress.Text = usr.Address1.ToString();
                    txtAddress2.Text = usr.Address2.ToString();
                    pID = usr.StateProvinceID;
                    // populate the drop downs
                    SelectCountryAndProv();
                    txtCity.Text = usr.City.ToString();
                    txtZip.Text = usr.ZipCodePostal.ToString();
                    txtEmail.Text = usr.Email.ToString();
                    if(Convert.ToBoolean(usr.IsReceiveNewsletters))
                        ckBox.Checked = true;
                }
            }
        }

        protected void drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDropdownStateProv();
        }

        private void SelectCountryAndProv()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM StatesProvinces where StateProvinceID = '" + pID + "'", new SqlConnection(ConfigurationManager.AppSettings["ConnString"]));
            cmd.Connection.Open();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                state = reader["Name"].ToString();
                country = reader["Country"].ToString();
            }

            reader.Close();
            cmd.Connection.Close();
            cmd.Connection.Dispose();

            int indx;

            if (country == "Canada")
                indx = 1;
            else
                indx = 0;

            drop.SelectedIndex = indx;
            PopulateDropdownStateProv();
            dropStateProv.SelectedIndex = pID - 1;
        }

        private void PopulateDropdownStateProv()
        {
            country = drop.SelectedItem.Text;
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

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (txtUName.Text != "" && txtPass.Text != "" && txtPass2.Text != "" && txtFName.Text != ""
                && txtLName.Text != "" && txtSal.Text != "" && txtAddress.Text != "" && txtCity.Text != ""
                && txtZip.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    usrID = Convert.ToInt32(Session["UserID"]);
                    User usr = new User();
                    usr.GetUserByID(usrID);

                    //take all values from text boxes and send them to User.cs
                    usr.Username = txtUName.Text;
                    if (txtPass.Text != txtPass2.Text)
                    {
                        LabelOutput.ForeColor = System.Drawing.Color.Red;
                        LabelOutput.Text = "Passwords do not match!";
                    }
                    else
                    {
                        usr.Password = txtPass.Text;
                        usr.Salutation = txtSal.Text;
                        usr.FirstName = txtFName.Text;
                        usr.LastName = txtLName.Text;
                        usr.Address1 = txtAddress.Text;
                        usr.Address2 = txtAddress2.Text;
                        usr.City = txtCity.Text;
                        usr.StateProvinceID = Convert.ToInt32(dropStateProv.SelectedValue);
                        usr.ZipCodePostal = txtZip.Text;
                        usr.Email = txtEmail.Text;
                        usr.IsReceiveNewsletters = ckBox.Checked;

                        // call addusr method to add usr and display success/fail text to usr
                        if (usr.UpdateUser())
                        {
                            LabelOutput.ForeColor = System.Drawing.Color.Green;
                            LabelOutput.Text = "Thank you " + txtUName.Text + "! You have successfully changed your information.";
                        }
                        else
                        {
                            LabelOutput.ForeColor = System.Drawing.Color.Red;
                            LabelOutput.Text = "Update Failed.<br />Please verify entered values.";
                            throw new Exception();
                        }
                    }
                }
                catch (Exception ex)
                {
                    String strEx = ex.Message;
                    LabelOutput.ForeColor = System.Drawing.Color.Red;
                    LabelOutput.Text = "Problem Updating, try again";
                }
            }// end if
            else
            {
                LabelOutput.ForeColor = System.Drawing.Color.Red;
                LabelOutput.Text = "Problem Updating, some required fields have not been filled.";
            }
        }// btn click

        protected void dropStateProv_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 
    }
}
