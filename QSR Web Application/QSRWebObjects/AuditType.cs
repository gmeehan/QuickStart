using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class AuditType : ErrorLogger
    {
        private int _auditTypeID;
        private string _description;
        private bool _isAdmin;

        public int AuditTypeID
        {
            get { return _auditTypeID; }
            set { _auditTypeID = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        /// <summary>
        /// Purpose: Grabs audit type information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetAuditTypeByID(int id)
        {
            try
            {
                AuditTypeData data = new AuditTypeData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetAuditTypeByID(id);

                _auditTypeID = id;
                try{ _description = hsh["description"].ToString(); } catch (Exception){ _description = ""; }
                try{ _isAdmin = Convert.ToBoolean(hsh["isadmin"]); } catch (Exception){ _isAdmin = false; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "AuditType", "GetAuditTypeByID");
            }
        }

    }
}
