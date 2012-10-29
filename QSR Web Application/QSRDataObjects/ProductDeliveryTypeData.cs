using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class ProductDeliveryTypeData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs product delivery type information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetProductDeliveryTypeByID(int id)
        {
            ProductDeliveryType obj = new ProductDeliveryType();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.ProductDeliveryTypes.FirstOrDefault(d => d.ProductDeliveryTypeID == id);
                if (obj != null)
                {
                    hsh["productdeliverytypeid"] = obj.ProductDeliveryTypeID;
                    hsh["productcode"] = obj.ProductCode;
                    hsh["created"] = obj.Created;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "ProductDeliveryTypeData", "GetProductDeliveryTypeByID");
            }

            return hsh;
        }
    }
}
