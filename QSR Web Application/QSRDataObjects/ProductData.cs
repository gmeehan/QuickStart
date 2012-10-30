using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class ProductData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs product information based on product code
        /// Accepts: String
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetProductByCode(string code)
        {
            Product obj = new Product();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.Products.FirstOrDefault(p => p.ProductCode == code);
                if (obj != null)
                {
                    hsh["productcode"] = obj.ProductCode;
                    hsh["name"] = obj.Name;
                    hsh["brand"] = obj.Brand;
                    hsh["description"] = obj.Description;
                    hsh["categoryid"] = obj.CategoryID;
                    hsh["msrp"] = obj.MSRP;
                    hsh["isfreeshipping"] = obj.isFreeShipping;
                    hsh["istaxfree"] = obj.isTaxFree;
                    hsh["quantityinstock"] = obj.QuantityInStock;
                    hsh["isquantityunlimited"] = obj.IsQuantityUnlimited;
                    hsh["created"] = obj.Created;
                    hsh["modified"] = obj.Modified;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "ProductData", "GetProductByCode");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs all products
        /// Accepts: Boolean
        /// Returns: List<Product>
        /// </summary>
        public List<Product> GetAllProducts(bool onlyActive)
        {
            QuickStart_DBEntities dbContext;
            List<Product> allproducts = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                allproducts = dbContext.Products.ToList();
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductData", "GetAllProducts");
            }

            return allproducts;
        }
    }
}
