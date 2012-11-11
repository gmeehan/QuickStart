using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class Audit : ErrorLogger
    {
        private int _auditID;
        private int _auditTypeID;
        private int _userID;
        private int _adminID;
        private string _notes;
        private DateTime _created;

        public int AuditID
        {
            get { return _auditID; }
            set
            {
                try
                {
                    _auditID = value;
                }
                catch (Exception)
                {
                    _auditID = 0;
                }
            }
        }

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

        public int AdminID
        {
            get { return _adminID; }
            set
            {
                try
                {
                    _adminID = value;
                }
                catch (Exception)
                {
                    _adminID = 0;
                }
            }
        }

        public Object Notes
        {
            get { return _notes; }
            set
            {
                try
                {
                    _notes = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _notes = "";
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

        /// <summary>
        /// Purpose: Grabs audit information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetAuditByID(int id)
        {
            try
            {
                AuditData data = new AuditData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetAuditByID(id);

                AuditID = id;
                AuditTypeID = Convert.ToInt32(hsh["audittypeid"]);
                UserID = Convert.ToInt32(hsh["userid"]);
                AdminID = Convert.ToInt32(hsh["adminid"]);
                Notes = hsh["notes"];
                Created = hsh["created"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Audit", "GetAuditByID");
            }
        }
    }
}
