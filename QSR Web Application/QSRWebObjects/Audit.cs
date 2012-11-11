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

        /// <summary>
        /// Purpose: Grabs all audits
        /// Accepts: Nothing
        /// Returns: List<Audit>
        /// </summary>
        public List<Audit> GetAllAudits()
        {
            List<Audit> audits = new List<Audit>();
            try
            {
                AuditData data = new AuditData();
                List<QSRDataObjects.Audit> dataAudits = data.GetAllAudits();

                foreach (QSRDataObjects.Audit a in dataAudits)
                {
                    Audit audit = new Audit();
                    audit.AuditID = a.AuditID;
                    audit.AuditTypeID = Convert.ToInt32(a.AuditTypeID);
                    audit.UserID = Convert.ToInt32(a.UserID);
                    audit.AdminID = Convert.ToInt32(a.AdminID);
                    audit.Notes = a.Notes;
                    audit.Created = a.Created;
                    audits.Add(audit);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Audit", "GetAllAudits");
            }
            return audits;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderAudit
    {
        private int _auditID;

        public int AuditID
        {
            get { return _auditID; }
            set { _auditID = value; }
        }
        private int _auditTypeID;

        public int AuditTypeID
        {
            get { return _auditTypeID; }
            set { _auditTypeID = value; }
        }
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private int _adminID;

        public int AdminID
        {
            get { return _adminID; }
            set { _adminID = value; }
        }
        private string _notes;

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public RenderAudit(Audit a)
        {
            AuditID = a.AuditID;
            AuditTypeID = Convert.ToInt32(a.AuditTypeID);
            UserID = Convert.ToInt32(a.UserID);
            AdminID = Convert.ToInt32(a.AdminID);
            Notes = Convert.ToString(a.Created);
        }
    }
}
