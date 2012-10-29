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
    }
}
