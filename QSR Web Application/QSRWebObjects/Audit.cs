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
            set { _auditID = value; }
        }

        public int AuditType
        {
            get { return _auditTypeID; }
            set { _auditTypeID = value; }
        }

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public int AdminID
        {
            get { return _adminID; }
            set { _adminID = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
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

                _auditID = id;
                try{ _auditTypeID = Convert.ToInt32(hsh["audittypeid"]); } catch (Exception){ _auditTypeID = 0; }
                try{ _userID = Convert.ToInt32(hsh["userid"]); } catch (Exception){ _userID = 0; }
                try{ _adminID = Convert.ToInt32(hsh["adminid"]); } catch (Exception){ _adminID = 0; }
                try{ _notes = hsh["notes"].ToString(); } catch (Exception){ _notes = ""; }
                try{ _created = Convert.ToDateTime(hsh["created"]); } catch (Exception){ _created = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Audit", "GetAuditByID");
            }
        }
    }
}
