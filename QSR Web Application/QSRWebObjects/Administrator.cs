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
            set
            {
                try
                {
                    _administratorID = value;
                }
                catch (Exception)
                {
                    _administratorID = 0;
                }
            }
        }

        public Object Username
        {
            get { return _username; }
            set
            {
                try
                {
                    _username = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _username = "";
                }
            }
        }

        public Object Password
        {
            get { return _password; }
            set
            {
                try
                {
                    _password = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _password = "";
                }
            }
        }

        public Object FirstName
        {
            get { return _firstName; }
            set
            {
                try
                {
                    _firstName = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _firstName = "";
                }
            }
        }

        public Object LastName
        {
            get { return _lastName; }
            set
            {
                try
                {
                    _lastName = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _lastName = "";
                }
            }
        }

        public Object IsActive
        {
            get { return _isActive; }
            set
            {
                try
                {
                    _isActive = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isActive = false;
                }
            }
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

                AdministratorID = id;
                Username = hsh["username"];
                Password = hsh["password"];
                FirstName = hsh["firstname"];
                LastName = hsh["lastname"];
                IsActive = hsh["isactive"];
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
                AdministratorID = adminData.Login(hsh);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Administrator", "Login");
            }
        }

        /// <summary>
        /// Purpose: Grabs all administrators
        /// Accepts: Boolean
        /// Returns: List<Administrator>
        /// </summary>
        public List<Administrator> GetAllAdministrators(bool onlyActive)
        {
            List<Administrator> administrators = new List<Administrator>();
            try
            {
                AdministratorData data = new AdministratorData();
                List<QSRDataObjects.Administrator> dataAdministrators = data.GetAllAdministrators(onlyActive);

                foreach (QSRDataObjects.Administrator a in dataAdministrators)
                {
                    Administrator admin = new Administrator();
                    admin.AdministratorID = a.AdministratorID;
                    admin.Username = a.Username;
                    admin.Password = a.Password;
                    admin.FirstName = a.FirstName;
                    admin.LastName = a.LastName;
                    admin.IsActive = a.IsActive;
                    administrators.Add(admin);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Administrator", "GetAllAdministrators");
            }
            return administrators;
        }
    }

    public class RenderAdministrator
    {
        private int _administratorID;

        public int AdministratorID
        {
            get { return _administratorID; }
            set { _administratorID = value; }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public RenderAdministrator(Administrator a)
        {
            AdministratorID = a.AdministratorID;
            Username = Convert.ToString(a.Username);
            Password = Convert.ToString(a.Password);
            FirstName = Convert.ToString(a.FirstName);
            LastName = Convert.ToString(a.LastName);
            IsActive = Convert.ToBoolean(a.IsActive);
        }

    }
}
