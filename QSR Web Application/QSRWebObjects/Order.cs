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

        /// <summary>
        /// Purpose: Grabs all orders
        /// Accepts: Nothing
        /// Returns: List<Order>
        /// </summary>
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                OrderData data = new OrderData();
                List<QSRDataObjects.Order> dataOrders = data.GetAllOrders();

                foreach (QSRDataObjects.Order o in dataOrders)
                {
                    Order order = new Order();
                    order.OrderID = o.OrderID;
                    order.UserID = Convert.ToInt32(o.UserID);
                    order.Subtotal = Convert.ToDouble(o.Subtotal);
                    order.Taxes = Convert.ToDouble(o.Taxes);
                    order.DeliveryCost = Convert.ToDouble(o.DeliveryCost);
                    order.DeliveryTypeID = Convert.ToInt32(o.DeliveryTypeID);
                    order.GrandTotal = Convert.ToDouble(o.GrandTotal);
                    order.Created = o.Created;
                    order.Modified = o.Modified;
                    orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Order", "GetAllOrders");
            }
            return orders;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderOrder
    {
        private int _orderID;

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private double _subtotal;

        public double Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }
        private double _taxes;

        public double Taxes
        {
            get { return _taxes; }
            set { _taxes = value; }
        }
        private double _deliveryCost;

        public double DeliveryCost
        {
            get { return _deliveryCost; }
            set { _deliveryCost = value; }
        }
        private int _deliveryTypeID;

        public int DeliveryTypeID
        {
            get { return _deliveryTypeID; }
            set { _deliveryTypeID = value; }
        }
        private double _grandTotal;

        public double GrandTotal
        {
            get { return _grandTotal; }
            set { _grandTotal = value; }
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

        public RenderOrder(Order o)
        {
            OrderID = o.OrderID;
            UserID = Convert.ToInt32(o.UserID);
            Subtotal = Convert.ToDouble(o.Subtotal);
            Taxes = Convert.ToDouble(o.Taxes);
            DeliveryCost = Convert.ToDouble(o.DeliveryCost);
            DeliveryTypeID = Convert.ToInt32(o.DeliveryTypeID);
            GrandTotal = Convert.ToDouble(o.GrandTotal);
            Created = Convert.ToDateTime(o.Created);
            Modified = Convert.ToDateTime(o.Modified);
        }

    }
}
