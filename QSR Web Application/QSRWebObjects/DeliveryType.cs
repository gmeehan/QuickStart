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
    }
}
