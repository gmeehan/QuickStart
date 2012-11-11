using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class Order : ErrorLogger
    {
        private int _orderID;
        private int _userID;
        private double _subtotal;
        private double _taxes;
        private double _deliveryCost;
        private int _deliveryTypeID;
        private double _grandTotal;
        private DateTime _created;
        private DateTime _modified;

        public int OrderID
        {
            get { return _orderID; }
            set
            {
                try
                {
                    _orderID = value;
                }
                catch (Exception)
                {
                    _orderID = 0;
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

        public double Subtotal
        {
            get { return _subtotal; }
            set
            {
                try
                {
                    _subtotal = value;
                }
                catch (Exception)
                {
                    _subtotal = 0.00;
                }
            }
        }

        public double Taxes
        {
            get { return _taxes; }
            set
            {
                try
                {
                    _taxes = value;
                }
                catch (Exception)
                {
                    _taxes = 0.00;
                }
            }
        }

        public double DeliveryCost
        {
            get { return _deliveryCost; }
            set
            {
                try
                {
                    _deliveryCost = value;
                }
                catch (Exception)
                {
                    _deliveryCost = 0.00;
                }
            }
        }

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

        public double GrandTotal
        {
            get { return _grandTotal; }
            set
            {
                try
                {
                    _grandTotal = value;
                }
                catch (Exception)
                {
                    _grandTotal = 0.00;
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
        /// Purpose: Grabs order information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetOrderByID(int id)
        {
            try
            {
                OrderData data = new OrderData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetOrderByID(id);

                OrderID = id;
                UserID = Convert.ToInt32(hsh["userid"]);
                Subtotal = Convert.ToDouble(hsh["subtotal"]);
                Taxes = Convert.ToDouble(hsh["taxes"]);
                DeliveryCost = Convert.ToDouble(hsh["deliverycost"]);
                DeliveryTypeID = Convert.ToInt32(hsh["deliverytypeid"]);
                GrandTotal = Convert.ToDouble(hsh["grandtotal"]);
                Created = hsh["created"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Order", "GetOrderByID");
            }
        }
    }
}
