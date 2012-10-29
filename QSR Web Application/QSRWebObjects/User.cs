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
            set { _userID = value; }
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

        public string Salutation
        {
            get { return _salutation; }
            set { _salutation = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public int StateProvinceID
        {
            get { return _stateProvinceID; }
            set { _stateProvinceID = value; }
        }

        public string ZipCodePostal
        {
            get { return _zipCodePostal; }
            set { _zipCodePostal = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool IsReceiveNewsletters
        {
            get { return _isReceiveNewsletters; }
            set { _isReceiveNewsletters = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
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

                _userID = id;
                try{ _username = hsh["username"].ToString(); } catch (Exception){ _username = ""; }
                try{ _password = hsh["password"].ToString(); } catch (Exception){ _password = ""; }
                try{ _salutation = hsh["salutation"].ToString(); } catch (Exception){ _salutation = ""; }
                try{ _firstName = hsh["firstname"].ToString(); } catch (Exception){ _firstName = ""; }
                try{ _lastName = hsh["lastname"].ToString(); } catch (Exception){ _lastName = ""; }
                try{ _address1 = hsh["address1"].ToString(); } catch (Exception){ _address1 = ""; }
                try{ _address2 = hsh["address2"].ToString(); } catch (Exception){ _address2 = ""; }
                try{ _city = hsh["city"].ToString(); } catch (Exception){ _city = ""; }
                try{ _stateProvinceID = Convert.ToInt32(hsh["stateprovinceid"]); } catch (Exception){ _stateProvinceID = 0; }
                try{ _zipCodePostal = hsh["zippostalcode"].ToString(); } catch (Exception){ _zipCodePostal = ""; }
                try{ _email = hsh["email"].ToString(); } catch (Exception){ _email = ""; }
                try{ _isReceiveNewsletters = Convert.ToBoolean(hsh["isreceivenewsletters"]); } catch (Exception){ _isReceiveNewsletters = false; }
                try { _created = Convert.ToDateTime(hsh["created"]); }catch (Exception) { _created = DateTime.MinValue; }
                try { _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception) { _modified = DateTime.MinValue; }
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
                _userID = userData.Login(hsh);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "User", "Login");
            }
        }
    }
}
