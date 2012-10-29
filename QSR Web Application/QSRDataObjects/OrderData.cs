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
    }
}
