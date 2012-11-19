using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects;
using System.Data;
using System.ComponentModel; //Connect web layer to data layer

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

        //This is used to return null if Mofidied is min value and therefore
        //not show the date in a gridview which has NullDisplayText set.
        public DateTime? ModifiedDisplay
        {
            get
            {
                if (Convert.ToDateTime(this.Modified) == default(DateTime))
                    return null;
                else
                    return Convert.ToDateTime(this.Modified);
            }
        }

        /// <summary>
        /// Purpose: Add new user information to the DB
        /// Accepts: Nothing
        /// Returns: Integer(the userid added)
        /// </summary>
        public int AddUser()
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

            return UserID;
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
                City = hsh["city"];
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

        /// <summary>
        /// Purpose: Grabs all users
        /// Accepts: Nothing
        /// Returns: List<User>
        /// </summary>
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                UserData data = new UserData();
                List<QSRDataObjects.User> dataUsers = data.GetAllUsers();

                foreach (QSRDataObjects.User u in dataUsers)
                {
                    User user = new User();
                    user.UserID = u.UserID;
                    user.Username = u.Username;
                    user.Password = u.Password;
                    user.Salutation = u.Salutation;
                    user.FirstName = u.FirstName;
                    user.LastName = u.LastName;
                    user.Address1 = u.Address1;
                    user.Address2 = u.Address2;
                    user.City = u.City;
                    user.StateProvinceID = Convert.ToInt32(u.StateProvinceID);
                    user.ZipCodePostal = u.ZipPostalCode;
                    user.Email = u.Email;
                    user.IsReceiveNewsletters = u.IsReceiveNewsletters;
                    user.Created = u.Created;
                    user.Modified = u.Modified;
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "User", "GetAllUsers");
            }
            return users;
        }

        /// <summary>
        /// Purpose: Update an existing user
        /// Accepts: Nothing
        /// Returns: Boolean
        /// </summary>
        public bool UpdateUser()
        {
            bool isSuccess = false;
            try
            {
                Hashtable HashUser = new Hashtable();
                HashUser["userid"] = UserID;
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

                UserData userData = new UserData();
                isSuccess = userData.UpdateUser(HashUser);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "User", "UpdateUser()");
            }

            return isSuccess;
        }

        public DataTable ToDataTable(List<User> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(User));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (User item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderUser
    {
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
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
        private string _salutation;

        public string Salutation
        {
            get { return _salutation; }
            set { _salutation = value; }
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
        private string _address1;

        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        private string _address2;

        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private int _stateProvinceID;

        public int StateProvinceID
        {
            get { return _stateProvinceID; }
            set { _stateProvinceID = value; }
        }
        private string _zipCodePostal;

        public string ZipCodePostal
        {
            get { return _zipCodePostal; }
            set { _zipCodePostal = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private bool _isReceiveNewsletters;

        public bool IsReceiveNewsletters
        {
            get { return _isReceiveNewsletters; }
            set { _isReceiveNewsletters = value; }
        }
        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        private DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        public RenderUser(User u)
        {
            UserID = u.UserID;
            Username = Convert.ToString(u.Username);
            Password = Convert.ToString(u.Password);
            Salutation = Convert.ToString(u.Salutation);
            FirstName = Convert.ToString(u.FirstName);
            LastName = Convert.ToString(u.LastName);
            Address1 = Convert.ToString(u.Address1);
            Address2 = Convert.ToString(u.Address2);
            City = Convert.ToString(u.City);
            StateProvinceID = Convert.ToInt32(u.StateProvinceID);
            ZipCodePostal = Convert.ToString(u.ZipCodePostal);
            Email = Convert.ToString(u.Email);
            IsReceiveNewsletters = Convert.ToBoolean(u.IsReceiveNewsletters);
            Created = Convert.ToDateTime(u.Created);
            Modified = Convert.ToDateTime(u.Modified);
        }
    }
}
