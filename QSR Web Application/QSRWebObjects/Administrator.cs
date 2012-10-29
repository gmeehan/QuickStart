using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class Administrator : ErrorLogger
    {
        private int _administratorID;
        private string _username;
        private string _password;
        private string _firstName;
        private string _lastName;
        private bool _isActive;

        public int AdministratorID
        {
            get { return _administratorID; }
            set { _administratorID = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string Lastname
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        /// Purpose: Grabs administrator information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetAdministratorByID(int id)
        {
            try
            {
                AdministratorData data = new AdministratorData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetAdministratorByID(id);

                _administratorID = id;
                try{ _username = hsh["username"].ToString(); } catch (Exception){ _username = ""; }
                try{ _password = hsh["password"].ToString(); } catch (Exception){ _password = ""; }
                try{ _firstName = hsh["firstname"].ToString(); } catch (Exception){ _firstName = ""; }
                try{ _lastName = hsh["lastname"].ToString(); } catch (Exception){ _lastName = ""; }
                try{ _isActive = Convert.ToBoolean(hsh["isactive"]); } catch (Exception){ _isActive = false; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Administrator", "GetAdministratorByID");
            }
        }

        /// <summary>
        /// Purpose: Sets administrator ID based on administrator login information
        /// Accepts: String username, String password
        /// Returns: Nothing
        /// </summary>
        public void Login(string username, string password)
        {
            try
            {
                AdministratorData adminData = new AdministratorData();
                Hashtable hsh = new Hashtable();
                hsh["username"] = username.Trim();
                hsh["password"] = password.Trim();
                _administratorID = adminData.Login(hsh);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Administrator", "Login");
            }
        }
    }
}
