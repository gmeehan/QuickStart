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

        /// <summary>
        /// Purpose: Grabs all audit types
        /// Accepts: Nothing
        /// Returns: List<AuditType>
        /// </summary>
        public List<AuditType> GetAllAuditTypes()
        {
            List<AuditType> audittypes = new List<AuditType>();
            try
            {
                AuditTypeData data = new AuditTypeData();
                List<QSRDataObjects.AuditType> dataAudits = data.GetAllAuditTypes();

                foreach (QSRDataObjects.AuditType at in dataAudits)
                {
                    AuditType audittype = new AuditType();
                    audittype.AuditTypeID = Convert.ToInt32(at.AuditTypeID);
                    audittype.Description = at.Description;
                    audittype.IsAdmin = at.IsAdmin;
                    audittypes.Add(audittype);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "AuditType", "GetAllAuditTypes");
            }
            return audittypes;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderAuditType
    {
        private int _auditTypeID;

        public int AuditTypeID
        {
            get { return _auditTypeID; }
            set { _auditTypeID = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        public RenderAuditType(AuditType at)
        {
            AuditTypeID = Convert.ToInt32(at.AuditTypeID);
            Description = Convert.ToString(at.Description);
            IsAdmin = Convert.ToBoolean(at.IsAdmin);
        }

    }

}
