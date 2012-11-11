using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class UserData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Add new user's information to the DB
        /// Accepts: Hashtable
        /// Returns: int
        /// </summary>
        public int AddUser(Hashtable hsh)
        {
            int newId = -1;
            User usr = new User();
            QuickStart_DBEntities dbContext;

            try
            {
                dbContext = new QuickStart_DBEntities();
                usr.Username = Convert.ToString(hsh["username"]);
                usr.Password = Convert.ToString(hsh["password"]);
                usr.Salutation = Convert.ToString(hsh["salutation"]);
                usr.FirstName = Convert.ToString(hsh["firstName"]);
                usr.LastName = Convert.ToString(hsh["lastName"]);
                usr.Address1 = Convert.ToString(hsh["address1"]);
                usr.Address2 = Convert.ToString(hsh["address2"]);
                usr.City = Convert.ToString(hsh["city"]);
                usr.StateProvinceID = Convert.ToInt32(hsh["stateProv"]);
                usr.ZipPostalCode = Convert.ToString(hsh["zipPC"]);
                usr.Email = Convert.ToString(hsh["email"]);
                usr.IsReceiveNewsletters = Convert.ToBoolean(hsh["newsletters"]);
                usr.Created = DateTime.Now;

                dbContext.AddToUsers(usr);
                dbContext.SaveChanges();
                newId = usr.UserID;
                dbContext.Detach(usr);
            }
            catch (Exception e)
            {
                ErrorLoggerData.ErrorRoutine(e, "UserData", "AddUser");
            }

            return newId;
        }

        /// <summary>
        /// Purpose: Grabs user information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetUserByID(int id)
        {
            User obj = new User();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.Users.FirstOrDefault(u => u.UserID == id);
                if (obj != null)
                {
                    hsh["userid"] = obj.UserID;
                    hsh["username"] = obj.Username;
                    hsh["password"] = obj.Password;
                    hsh["salutation"] = obj.Salutation;
                    hsh["firstname"] = obj.FirstName;
                    hsh["lastname"] = obj.LastName;
                    hsh["address1"] = obj.Address1;
                    hsh["address2"] = obj.Address2;
                    hsh["city"] = obj.City;
                    hsh["stateprovinceid"] = obj.StateProvinceID;
                    hsh["zipostalcode"] = obj.ZipPostalCode;
                    hsh["email"] = obj.Email;
                    hsh["isreceivenewsletters"] = obj.IsReceiveNewsletters;
                    hsh["created"] = obj.Created;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "UserData", "GetUserByID");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs user ID based on user login information
        /// Accepts: Hashtable 
        /// Returns: Int
        /// </summary>
        public int Login(Hashtable hsh)
        {
            QuickStart_DBEntities dbContext;
            int retUserID = -1;

            try
            {
                String username = Convert.ToString(hsh["username"]);
                String password = Convert.ToString(hsh["password"]);

                dbContext = new QuickStart_DBEntities();

                //Use Linq to Entities syntax to retrieve desired User
                User user = null;
                user = dbContext.Users.FirstOrDefault(u => u.Username == username);

                if (user != null)
                {
                    if (user.Password == password)
                    {
                        retUserID = user.UserID;
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "UserData", "Login");
                retUserID = -1;
            }

            return retUserID;
        }


        /// <summary>
        /// Purpose: Grabs all users
        /// Accepts: Nothing
        /// Returns: List<User>
        /// </summary>
        public List<User> GetAllUsers()
        {
            QuickStart_DBEntities dbContext;
            List<User> allusers = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all users are returned
                allusers = dbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "UserData", "GetAllUsers");
            }

            return allusers;
        }
    }
}
