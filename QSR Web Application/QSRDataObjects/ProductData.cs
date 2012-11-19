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
                    hsh["isactive"] = obj.isActive;
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

                if (onlyActive == true) //only the active products are returned
                {
                    allproducts = dbContext.Products.Where(p => p.isActive == true).ToList();
                }
                else //all products are returned
                {
                    allproducts = dbContext.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductData", "GetAllProducts");
            }

            return allproducts;
        }

        /// <summary>
        /// Purpose: Grabs all products for a given category id
        /// Accepts: Integer, Boolean
        /// Returns: List<Product>
        /// </summary>
        public List<Product> GetAllProductsByCategoryID(int catid, bool onlyActive)
        {
            QuickStart_DBEntities dbContext;
            List<Product> allproducts = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                if (onlyActive == true) //only the active categories are returned
                {
                    allproducts = dbContext.Products.Where(p => p.isActive == true && p.CategoryID == catid).ToList();
                }
                else //all categories are returned
                {
                    allproducts = dbContext.Products.Where(p => p.CategoryID == catid).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductData", "GetAllProductsByCategoryID");
            }

            return allproducts;
        }

        /// <summary>
        /// Purpose: Update an existing Product in the database
        /// Accepts: Hashtable
        /// Returns: Boolean
        /// </summary>
        public bool UpdateProduct(Hashtable hsh)
        {
            bool isSuccess = false;
            Product prod = new Product();
            QuickStart_DBEntities dbContext;
            try
            {
                dbContext = new QuickStart_DBEntities();
                string prodcd = hsh["productcode"].ToString();
                prod = dbContext.Products.FirstOrDefault(p => p.ProductCode == prodcd);
                prod.Name = Convert.ToString(hsh["name"]);
                prod.Brand = Convert.ToString(hsh["brand"]);
                prod.Description = Convert.ToString(hsh["description"]);
                prod.CategoryID = Convert.ToInt32(hsh["categoryid"]);
                prod.MSRP = Convert.ToDouble(hsh["msrp"]);
                prod.isFreeShipping = Convert.ToBoolean(hsh["isfreeshipping"]);
                prod.isTaxFree = Convert.ToBoolean(hsh["istaxfree"]);
                prod.QuantityInStock = Convert.ToInt32(hsh["quantityinstock"]);
                prod.IsQuantityUnlimited = Convert.ToBoolean(hsh["isquantityunlimited"]);
                //need 'modified' but not 'created' during an update
                prod.Modified = DateTime.Now;
                prod.isActive = Convert.ToBoolean(hsh["isactive"]);

                dbContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ProductData", "UpdateProduct");
            }

            return isSuccess;
        }

        /// <summary>
        /// Purpose: Add a new Product to the database
        /// Accepts: Hashtable
        /// Returns: String (Product Code)
        /// </summary>
        public string AddProduct(Hashtable hsh)
        {
            //The product code that was added to database
            string retProdcd = "";
            Product prod = new Product();
            QuickStart_DBEntities dbContext;
            try
            {
                dbContext = new QuickStart_DBEntities();
                prod.ProductCode = Convert.ToString(hsh["productcode"]);
                prod.Name = Convert.ToString(hsh["name"]);
                prod.Brand = Convert.ToString(hsh["brand"]);
                prod.Description = Convert.ToString(hsh["description"]);
                prod.CategoryID = Convert.ToInt32(hsh["categoryid"]);
                prod.MSRP = Convert.ToDouble(hsh["msrp"]);
                prod.isFreeShipping = Convert.ToBoolean(hsh["isfreeshipping"]);
                prod.isTaxFree = Convert.ToBoolean(hsh["istaxfree"]);
                prod.QuantityInStock = Convert.ToInt32(hsh["quantityinstock"]);
                prod.IsQuantityUnlimited = Convert.ToBoolean(hsh["isquantityunlimited"]);
                prod.Created = DateTime.Now;
                prod.Modified = null;
                prod.isActive = true; //set to active

                dbContext.AddToProducts(prod);
                dbContext.SaveChanges();
                retProdcd = prod.ProductCode;
                dbContext.Detach(prod);
            }
            catch (Exception e)
            {
                ErrorRoutine(e, "ProductData", "AddProduct");
            }

            return retProdcd;
        }
    }
}
