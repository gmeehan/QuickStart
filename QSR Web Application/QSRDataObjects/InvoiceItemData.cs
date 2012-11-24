using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSRDataObjects
{
    public class InvoiceItemData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs all InvoiceItems via stored procedure 
        /// Accepts: Nothing
        /// Returns: List<InvoiceItem>
        /// </summary>
        public List<InvoiceItem> GetAllInvoiceItemsByOrderID(int orderid)
        {
            QuickStart_DBEntities dbContext;
            List<InvoiceItem> retList = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all Invoice Items are returned for this order id
                retList = dbContext.spGetInvoiceItemsByOrderID(orderid).ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "InvoiceItemData", "GetAllInvoiceItemsByOrderID");
            }

            return retList;
        }
    }
}
