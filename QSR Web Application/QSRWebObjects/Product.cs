using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class Product : ErrorLogger
    {
        private string _productCode;
        private string _name;
        private string _brand;
        private string _description;
        private int _categoryID;
        private double _msrp;
        private bool _isFreeShipping;
        private bool _isTaxFree;
        private int _quantityInStock;
        private bool _isQuantityUnlimited;
        private DateTime _created;
        private DateTime _modified;

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public double Msrp
        {
            get { return _msrp; }
            set { _msrp = value; }
        }

        public bool IsFreeShipping
        {
            get { return _isFreeShipping; }
            set { _isFreeShipping = value; }
        }

        public bool IsTaxFree
        {
            get { return _isTaxFree; }
            set { _isTaxFree = value; }
        }

        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set { _quantityInStock = value; }
        }

        public bool IsQuantityUnlimited
        {
            get { return _isQuantityUnlimited; }
            set { _isQuantityUnlimited = value; }
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
        /// Purpose: Grabs product information based on product code
        /// Accepts: String
        /// Returns: Nothing
        /// </summary>
        public void GetProductByCode(string code)
        {
            try
            {
                ProductData data = new ProductData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetProductByCode(code);

                _productCode = code;
                try{ _name = hsh["name"].ToString(); } catch (Exception){ _name = ""; }
                try{ _brand = hsh["brand"].ToString(); }catch (Exception) { _brand = ""; }
                try{ _description = hsh["description"].ToString(); } catch (Exception){ _description = ""; }
                try{ _categoryID = Convert.ToInt32(hsh["categoryid"]); } catch (Exception){ _categoryID = 0; }
                try{ _msrp = Convert.ToDouble(hsh["msrp"]); } catch (Exception){ _msrp = 0.00; }
                try{ _isFreeShipping = Convert.ToBoolean(hsh["isfreeshipping"]); } catch (Exception){ _isFreeShipping = false; }
                try{ _isTaxFree = Convert.ToBoolean(hsh["istaxfree"]); } catch (Exception){ _isTaxFree = false; }
                try{ _quantityInStock = Convert.ToInt32(hsh["quantityinstock"]); } catch (Exception){ _quantityInStock = 0; }
                try{ _isQuantityUnlimited = Convert.ToBoolean(hsh["isquantityunlimited"]); } catch (Exception){ _isQuantityUnlimited = false; }
                try{ _created = Convert.ToDateTime(hsh["created"]); } catch (Exception){ _created = DateTime.MinValue; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Product", "GetProductByCode");
            }
        }

        /// <summary>
        /// Purpose: Grabs all products
        /// Accepts: Boolean
        /// Returns: List<Product>
        /// </summary>
        public List<Product> GetAllProducts(bool onlyActive)
        {
            List<Product> products = new List<Product>();
            try
            {
                ProductData data = new ProductData();
                List<QSRDataObjects.Product> dataProducts = data.GetAllProducts(onlyActive);

                foreach (QSRDataObjects.Product p in dataProducts)
                {
                    Product prod = new Product();
                    try{ prod.ProductCode = p.ProductCode.ToString(); } catch (Exception){ prod.ProductCode = ""; }
                    try{ prod.Name = p.Name.ToString(); } catch (Exception){ prod.Name = ""; }
                    try{ prod.Brand = p.Brand.ToString(); } catch (Exception){ prod.Brand = ""; }
                    try{ prod.Description = p.Description.ToString(); } catch (Exception){ prod.Description = ""; }
                    try{ prod.CategoryID = Convert.ToInt32(p.CategoryID); } catch (Exception){ prod.CategoryID = 0; }
                    try{ prod.Msrp = Convert.ToDouble(p.MSRP); } catch (Exception){ prod.Msrp = 0.00; }
                    try{ prod.IsFreeShipping = Convert.ToBoolean(p.isFreeShipping); } catch (Exception){ prod.IsFreeShipping = false; }
                    try{ prod.IsTaxFree = Convert.ToBoolean(p.isTaxFree); } catch (Exception){ prod.IsTaxFree = false; }
                    try{ prod.QuantityInStock = Convert.ToInt32(p.QuantityInStock); } catch (Exception){ prod.QuantityInStock = 0; }
                    try{ prod.IsQuantityUnlimited = Convert.ToBoolean(p.IsQuantityUnlimited); } catch (Exception){ prod.IsQuantityUnlimited = false; }
                    try{ prod.Created = Convert.ToDateTime(p.Created); } catch (Exception){ prod.Created = DateTime.MinValue; }
                    try{ prod.Modified = Convert.ToDateTime(p.Modified); } catch (Exception){ prod.Modified = DateTime.MinValue; }
                    products.Add(prod);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Product", "GetAllProducts");
            }
            return products;
        }
    }
}
