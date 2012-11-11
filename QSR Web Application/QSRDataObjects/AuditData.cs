using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class AuditData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs audit information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetAuditByID(int id)
        {
            Audit obj = new Audit();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.Audits.FirstOrDefault(a => a.AuditID == id);
                if (obj != null)
                {
                    hsh["auditid"] = obj.AuditID;
                    hsh["audittypeid"] = obj.AuditTypeID;
                    hsh["userid"] = obj.UserID;
                    hsh["adminid"] = obj.AdminID;
                    hsh["notes"] = obj.Notes;
                    hsh["created"] = obj.Created;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "AuditData", "GetAuditByID");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs all audits
        /// Accepts: Nothing
        /// Returns: List<Audit>
        /// </summary>
        public List<Audit> GetAllAudits()
        {
            QuickStart_DBEntities dbContext;
            List<Audit> allaudits = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all audits are returned
                allaudits = dbContext.Audits.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "AuditData", "GetAllAudits");
            }

            return allaudits;
        }
    }
}
