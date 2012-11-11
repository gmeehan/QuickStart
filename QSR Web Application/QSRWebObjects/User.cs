using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class User : ErrorLogger
    {
        private int _userID;
        private string _username;
        private string _password;
        private string _salutation;
        private string _firstName;
        private string _lastName;
        private string _address1;
        private string _address2;
        private string _city;
        private int _stateProvinceID;
        private string _zipCodePostal;
        private string _email;
        private bool _isReceiveNewsletters;
        private DateTime _created;
        private DateTime _modified;

        public int UserID
        {
            get { return _userID; }
            set
            {
                try
                {
                    _userID = value;
                }
                catch (Exception)
                {
                    _userID = 0;
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

        public Object Salutation
        {
            get { return _salutation; }
            set
            {
                try
                {
                    _salutation = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _salutation = "";
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

        public Object Address1
        {
            get { return _address1; }
            set
            {
                try
                {
                    _address1 = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _address1 = "";
                }
            }
        }

        public Object Address2
        {
            get { return _address2; }
            set
            {
                try
                {
                    _address2 = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _address2 = "";
                }
            }
        }

        public Object City
        {
            get { return _city; }
            set
            {
                try
                {
                    _city = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _city = "";
                }
            }
        }

        public int StateProvinceID
        {
            get { return _stateProvinceID; }
            set
            {
                try
                {
                    _stateProvinceID = value;
                }
                catch (Exception)
                {
                    _stateProvinceID = 0;
                }
            }
        }

        public Object ZipCodePostal
        {
            get { return _zipCodePostal; }
            set
            {
                try
                {
                    _zipCodePostal = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _zipCodePostal = "";
                }
            }
        }

        public Object Email
        {
            get { return _email; }
            set
            {
                try
                {
                    _email = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _email = "";
                }
            }
        }

        public Object IsReceiveNewsletters
        {
            get { return _isReceiveNewsletters; }
            set
            {
                try
                {
                    _isReceiveNewsletters = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isReceiveNewsletters = false;
                }
            }
        }

        public Object Created
        {
            get { return _created; }
            set
            {
                try
                {
                    _created = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _created = DateTime.MinValue;
                }
            }
        }

        public Object Modified
        {
            get { return _modified; }
            set
            {
                try
                {
                    _modified = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _modified = DateTime.MinValue;
                }
            }
        }

        /// <summary>
        /// Purpose: Add new user information to the DB
        /// Accepts: Nothing
        /// Returns: Boolean
        /// </summary>
        public void AddUser()
        {
            Hashtable HashUser = new Hashtable();
            try
            {
                UserData usr = new UserData();
                HashUser["username"] = Username;
                HashUser["password"] = Password;
                HashUser["salutation"] = Salutation;
                HashUser["firstName"] = FirstName;
                HashUser["lastName"] = LastName;
                HashUser["address1"] = Address1;
                HashUser["address2"] = Address2;
                HashUser["city"] = City;
                HashUser["stateProv"] = StateProvinceID;
                HashUser["zipPC"] = ZipCodePostal;
                HashUser["email"] = Email;
                HashUser["newsletters"] = IsReceiveNewsletters;
                UserID = usr.AddUser(HashUser);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "User", "AddUser");
            }
        }

        /// <summary>
        /// Purpose: Grabs user information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetUserByID(int id)
        {
            try
            {
                UserData data = new UserData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetUserByID(id);

                UserID = id;
                Username = hsh["username"];
                Password = hsh["password"];
                Salutation = hsh["salutation"];
                FirstName = hsh["firstname"];
                LastName = hsh["lastname"];
                Address1 = hsh["address1"];
                Address2 = hsh["address2"];
                City = hsh["city"].ToString();
                StateProvinceID = Convert.ToInt32(hsh["stateprovinceid"]);
                ZipCodePostal = hsh["zippostalcode"];
                Email = hsh["email"];
                IsReceiveNewsletters = hsh["isreceivenewsletters"];
                Created = hsh["created"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "User", "GetUserByID");
            }
        }

        /// <summary>
        /// Purpose: Sets user ID based on user login information
        /// Accepts: String username, String password
        /// Returns: Nothing
        /// </summary>
        public void Login(string username, string password)
        {
            try
            {
                UserData userData = new UserData();
                Hashtable hsh = new Hashtable();
                hsh["username"] = username.Trim();
                hsh["password"] = password.Trim();
                UserID = userData.Login(hsh);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "User", "Login");
            }
        }
    }
}
