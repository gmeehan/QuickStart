using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class OrderItemData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs orderitem information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetOrderItemByID(int id)
        {
            OrderItem obj = new OrderItem();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.OrderItems.FirstOrDefault(o => o.OrderItemID == id);
                if (obj != null)
                {
                    hsh["orderitemid"] = obj.OrderItemID;
                    hsh["productcode"] = obj.ProductCode;
                    hsh["quantity"] = obj.Quantity;
                    hsh["created"] = obj.Created;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "OrderItemData", "GetOrderItemByID");
            }

            return hsh;
        }
    }
}
