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
                    hsh["deliverytypeid"] = obj.DeliveryTypeID;
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

        /// <summary>
        /// Purpose: Grabs all product delivery types
        /// Accepts: Nothing
        /// Returns: List<ProductDeliveryType>
        /// </summary>
        public List<ProductDeliveryType> GetAllProductDeliveryTypes()
        {
            QuickStart_DBEntities dbContext;
            List<ProductDeliveryType> allproddeliverytypes = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all product delivery types are returned
                allproddeliverytypes = dbContext.ProductDeliveryTypes.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductDeliveryTypeData", "GetAllProductDeliveryTypes");
            }

            return allproddeliverytypes;
        }

        /// <summary>
        /// Purpose: Grabs all product delivery types by product code
        /// Accepts: String (Product Code)
        /// Returns: List<ProductDeliveryType>
        /// </summary>
        public List<ProductDeliveryType> GetAllProductDeliveryTypesByProdCode(string prodcd)
        {
            QuickStart_DBEntities dbContext;
            List<ProductDeliveryType> proddeliverytypes = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                //all product delivery types for this product are returned
                proddeliverytypes = dbContext.ProductDeliveryTypes.Where(pdt => pdt.ProductCode == prodcd).ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductDeliveryTypeData", "GetAllDeliveryTypesByProdCode");
            }

            return proddeliverytypes;
        }
    }
}
