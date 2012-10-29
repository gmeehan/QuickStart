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
            set { _orderID = value; }
        }

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public double Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }

        public double Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
        }

        public double DeliveryCost
        {
            get { return _deliveryCost; }
            set { _deliveryCost = value; }
        }

        public int DeliveryTypeID
        {
            get { return _deliveryTypeID; }
            set { _deliveryTypeID = value; }
        }

        public double GrandTotal
        {
            get { return _grandTotal; }
            set { _grandTotal = value; }
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

                _orderID = id;
                try{ _userID = Convert.ToInt32(hsh["userid"]); } catch (Exception){ _userID = 0; }
                try{ _subtotal = Convert.ToDouble(hsh["subtotal"]); } catch (Exception){ _subtotal = 0.00; }
                try{ _taxes = Convert.ToDouble(hsh["taxes"]); } catch (Exception){ _taxes = 0.00; }
                try{ _deliveryCost = Convert.ToDouble(hsh["deliverycost"]); } catch (Exception){ _deliveryCost = 0.00; }
                try{ _deliveryTypeID = Convert.ToInt32(hsh["deliverytypeid"]); } catch (Exception){ _deliveryTypeID = 0; }
                try{ _grandTotal = Convert.ToDouble(hsh["grandtotal"]); } catch (Exception){ _grandTotal = 0.00; }
                try{ _created = Convert.ToDateTime(hsh["created"]); } catch (Exception){ _created = DateTime.MinValue; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Order", "GetOrderByID");
            }
        }
    }
}
