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
    }
}
