using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class AuditTypeData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs audit type information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetAuditTypeByID(int id)
        {
            AuditType obj = new AuditType();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.AuditTypes.FirstOrDefault(a => a.AuditTypeID == id);
                if (obj != null)
                {
                    hsh["audittypeid"] = obj.AuditTypeID;
                    hsh["description"] = obj.Description;
                    hsh["isadmin"] = obj.IsAdmin;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "AuditTypeData", "GetAuditTypeByID");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs all audit types
        /// Accepts: Nothing
        /// Returns: List<AuditType>
        /// </summary>
        public List<AuditType> GetAllAuditTypes()
        {
            QuickStart_DBEntities dbContext;
            List<AuditType> allaudittypes = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all audit types are returned
                allaudittypes = dbContext.AuditTypes.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "AuditTypeData", "GetAllAuditTypes");
            }

            return allaudittypes;
        }
    }
}
