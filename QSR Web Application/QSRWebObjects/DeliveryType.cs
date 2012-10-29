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
            set { _deliveryTypeID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
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
                try{ _name = hsh["name"].ToString(); } catch (Exception){ _name = ""; }
                try{ _description = hsh["description"].ToString(); } catch (Exception){ _description = ""; }
                try{ _cost = Convert.ToDouble(hsh["cost"]); } catch (Exception){ _cost = 0.00; }
                try{ _created = Convert.ToDateTime(hsh["created"]); } catch (Exception){ _created = DateTime.MinValue; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "DeliveryType", "GetDeliveryTypeByID");
            }
        }
    }
}
