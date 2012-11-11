using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class AdministratorData : ErrorLoggerData
    {

        /// <summary>
        /// Purpose: Grabs administrator information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetAdministratorByID(int id)
        {
            Administrator obj = new Administrator();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.Administrators.FirstOrDefault(a => a.AdministratorID == id);
                if (obj != null)
                {
                    hsh["adminid"] = obj.AdministratorID;
                    hsh["username"] = obj.Username;
                    hsh["password"] = obj.Password;
                    hsh["firstname"] = obj.FirstName;
                    hsh["lastname"] = obj.LastName;
                    hsh["isactive"] = obj.IsActive;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "AdministratorData", "GetAdministratorByID");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs administrator ID based on administrator login information
        /// Accepts: Hashtable 
        /// Returns: Int
        /// </summary>
        public int Login(Hashtable hsh)
        {
            QuickStart_DBEntities dbContext;
            int retAdminID = -1;

            try
            {
                String username = Convert.ToString(hsh["username"]);
                String password = Convert.ToString(hsh["password"]);

                dbContext = new QuickStart_DBEntities();

                //Use Linq to Entities syntax to retrieve desired Administrator
                Administrator admin = null;
                admin = dbContext.Administrators.FirstOrDefault(a => a.Username == username);

                if (admin != null)
                {
                    if (admin.Password == password)
                    {
                        retAdminID = admin.AdministratorID;
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "AdministratorData", "Login");
                retAdminID = -1;
            }

            return retAdminID;
        }

        /// <summary>
        /// Purpose: Grabs all administrators
        /// Accepts: Boolean
        /// Returns: List<Administrator>
        /// </summary>
        public List<Administrator> GetAllAdministrators(bool onlyActive)
        {
            QuickStart_DBEntities dbContext;
            List<Administrator> alladministrators = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                if (onlyActive == true) //only the active administrators are returned
                {
                    alladministrators = dbContext.Administrators.Where(a => a.IsActive == true).ToList();
                }
                else //all administrators are returned
                {
                    alladministrators = dbContext.Administrators.ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "AdministratorData", "GetAllAdministrators");
            }

            return alladministrators;
        }
    }
}
