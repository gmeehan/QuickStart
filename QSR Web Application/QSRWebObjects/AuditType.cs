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
            set
            {
                try
                {
                    _auditTypeID = value;
                }
                catch (Exception)
                {
                    _auditTypeID = 0;
                }
            }
        }

        public Object Description
        {
            get { return _description; }
            set
            {
                try
                {
                    _description = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _description = "";
                }
            }
        }

        public Object IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                try
                {
                    _isAdmin = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isAdmin = false;
                }
            }
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

                AuditTypeID = id;
                Description = hsh["description"];
                IsAdmin = hsh["isadmin"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "AuditType", "GetAuditTypeByID");
            }
        }

    }
}
