using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class OrderData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs order information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetOrderByID(int id)
        {
            Order obj = new Order();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.Orders.FirstOrDefault(o => o.OrderID == id);
                if (obj != null)
                {
                    hsh["orderid"] = obj.OrderID;
                    hsh["userid"] = obj.UserID;
                    hsh["subtotal"] = obj.Subtotal;
                    hsh["taxes"] = obj.Taxes;
                    hsh["deliverytypeid"] = obj.DeliveryTypeID;
                    hsh["deliverycost"] = obj.DeliveryCost;
                    hsh["grandtotal"] = obj.GrandTotal;
                    hsh["created"] = obj.Created;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "OrderData", "GetOrderByID");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs all orders
        /// Accepts: Nothing
        /// Returns: List<Order>
        /// </summary>
        public List<Order> GetAllOrders()
        {
            QuickStart_DBEntities dbContext;
            List<Order> allorders = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all orders are returned
                allorders = dbContext.Orders.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "OrderData", "GetAllOrders");
            }

            return allorders;
        }

        /// <summary>
        /// Purpose: Grabs all orders
        /// Accepts: Int representing the userID
        /// Returns: List<Order>
        /// </summary>
        public List<Order> GetAllOrdersByUserID(int uId)
        {
            QuickStart_DBEntities dbContext;
            List<Order> allorders = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all orders are returned
                allorders = dbContext.Orders.Where(o => o.UserID == uId).ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "OrderData", "GetAllOrders");
            }

            return allorders;
        }

        /// <summary>
        /// Purpose: Update an existing Order in the database
        /// Accepts: Hashtable
        /// Returns: Boolean
        /// </summary>
        public bool UpdateOrder(Hashtable hsh)
        {
            bool isSuccess = false;
            Order order = new Order();
            QuickStart_DBEntities dbContext;
            try
            {
                dbContext = new QuickStart_DBEntities();
                int orderid = Convert.ToInt32(hsh["orderid"]);
                order = dbContext.Orders.FirstOrDefault(o => o.OrderID == orderid);
                order.UserID = Convert.ToInt32(hsh["userid"]);
                order.Subtotal = Convert.ToDouble(hsh["subtotal"]);
                order.Taxes = Convert.ToDouble(hsh["taxes"]);
                order.DeliveryCost = Convert.ToDouble(hsh["deliverycost"]);
                order.DeliveryTypeID= Convert.ToInt32(hsh["deliverytypeid"]);
                order.GrandTotal = Convert.ToDouble(hsh["grandtotal"]);
                //need 'modified' but not 'created' during an update
                order.Modified = DateTime.Now;

                dbContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "OrderData", "UpdateOrder");
            }

            return isSuccess;
        }
    }
}
