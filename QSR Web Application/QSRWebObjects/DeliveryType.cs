using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class DeliveryType : ErrorLogger
    {
        private int _deliveryTypeID;
        private string _name;
        private string _description;
        private double _cost;
        private DateTime _created;
        private DateTime _modified;

        public int DeliveryTypeID
        {
            get { return _deliveryTypeID; }
            set
            {
                try
                {
                    _deliveryTypeID = value;
                }
                catch (Exception)
                {
                    _deliveryTypeID = 0;
                }
            }
        }

        public Object Name
        {
            get { return _name; }
            set
            {
                try
                {
                    _name = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _name = "";
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

        public double Cost
        {
            get { return _cost; }
            set
            {
                try
                {
                    _cost = value;
                }
                catch (Exception)
                {
                    _cost = 0.00;
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

        public Object Modified
        {
            get { return _modified; }
            set
            {
                try
                {
                    _modified = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _modified = DateTime.MinValue;
                }
            }
        }

        /// <summary>
        /// Purpose: Grabs delivery type information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetDeliveryTypeByID(int id)
        {
            try
            {
                DeliveryTypeData data = new DeliveryTypeData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetDeliveryTypeByID(id);

                _deliveryTypeID = id;
                Name = hsh["name"].ToString();
                Description = hsh["description"].ToString();
                Cost = Convert.ToDouble(hsh["cost"]);
                Created = Convert.ToDateTime(hsh["created"]);
                Modified = Convert.ToDateTime(hsh["modified"]);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "DeliveryType", "GetDeliveryTypeByID");
            }
        }

        /// <summary>
        /// Purpose: Grabs all delivery types
        /// Accepts: Nothing
        /// Returns: List<DeliveryType>
        /// </summary>
        public List<DeliveryType> GetAllDeliveryTypes()
        {
            List<DeliveryType> deliveryTypes = new List<DeliveryType>();
            try
            {
                DeliveryTypeData data = new DeliveryTypeData();
                List<QSRDataObjects.DeliveryType> dataDeliveryTypes = data.GetAllDeliveryTypes();

                foreach (QSRDataObjects.DeliveryType dt in dataDeliveryTypes)
                {
                    DeliveryType deliveryType = new DeliveryType();
                    deliveryType.DeliveryTypeID = dt.DeliveryTypeID;
                    deliveryType.Name = dt.Name;
                    deliveryType.Cost = Convert.ToDouble(dt.Cost);
                    deliveryType.Description = dt.Description;
                    deliveryType.Created = dt.Created;
                    deliveryType.Modified = dt.Modified;
                    deliveryTypes.Add(deliveryType);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "DeliveryType", "GetAllDeliveryTypes");
            }
            return deliveryTypes;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderDeliveryType
    {
        private int _deliveryTypeID;

        public int DeliveryTypeID
        {
            get { return _deliveryTypeID; }
            set { _deliveryTypeID = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private double _cost;

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        private DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        public RenderDeliveryType(DeliveryType dt)
        {
            DeliveryTypeID = dt.DeliveryTypeID;
            Name = Convert.ToString(dt.Name);
            Cost = Convert.ToDouble(dt.Cost);
            Description = Convert.ToString(dt.Description);
            Created = Convert.ToDateTime(dt.Created);
            Modified = Convert.ToDateTime(dt.Modified);
        }
    }
}
