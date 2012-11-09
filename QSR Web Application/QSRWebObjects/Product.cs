using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects;
using System.Data;
using System.ComponentModel; //Connect web layer to data layer

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
        private bool _isActive;

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

        public string CategoryName
        {
            get {
                QSRWebObjects.Category cat = new QSRWebObjects.Category();
                cat.GetCategoryByID(_categoryID);
                return cat.Name;
            }
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

        //This is used to return null if Mofidied is min value and therefore
        //not show the date in a gridview which has NullDisplayText set.
        public DateTime? ModifiedDisplay
        {
            get
            {
                if (this.Modified == default(DateTime))
                    return null;
                else
                    return this.Modified;
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
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
                try{ _isActive = Convert.ToBoolean(hsh["isactive"]); } catch (Exception){ _isActive = false; }
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
                    try{ prod.IsActive = Convert.ToBoolean(p.isActive); } catch (Exception){ prod.IsActive = false; }
                    products.Add(prod);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Product", "GetAllProducts");
            }
            return products;
        }

        /// <summary>
        /// Purpose: Grabs all products for a given category id
        /// Accepts: Integer, Boolean
        /// Returns: List<Product>
        /// </summary>
        public List<Product> GetAllProductsByCategoryID(int catid, bool onlyActive)
        {
            List<Product> products = new List<Product>();
            try
            {
                ProductData data = new ProductData();
                List<QSRDataObjects.Product> dataProducts = data.GetAllProductsByCategoryID(catid, onlyActive);

                foreach (QSRDataObjects.Product p in dataProducts)
                {
                    Product prod = new Product();
                    try { prod.ProductCode = p.ProductCode.ToString(); }catch (Exception) { prod.ProductCode = ""; }
                    try { prod.Name = p.Name.ToString(); }catch (Exception) { prod.Name = ""; }
                    try { prod.Brand = p.Brand.ToString(); }catch (Exception) { prod.Brand = ""; }
                    try { prod.Description = p.Description.ToString(); }catch (Exception) { prod.Description = ""; }
                    try { prod.CategoryID = Convert.ToInt32(p.CategoryID); }catch (Exception) { prod.CategoryID = 0; }
                    try { prod.Msrp = Convert.ToDouble(p.MSRP); }catch (Exception) { prod.Msrp = 0.00; }
                    try { prod.IsFreeShipping = Convert.ToBoolean(p.isFreeShipping); }catch (Exception) { prod.IsFreeShipping = false; }
                    try { prod.IsTaxFree = Convert.ToBoolean(p.isTaxFree); }catch (Exception) { prod.IsTaxFree = false; }
                    try { prod.QuantityInStock = Convert.ToInt32(p.QuantityInStock); }catch (Exception) { prod.QuantityInStock = 0; }
                    try { prod.IsQuantityUnlimited = Convert.ToBoolean(p.IsQuantityUnlimited); }catch (Exception) { prod.IsQuantityUnlimited = false; }
                    try { prod.Created = Convert.ToDateTime(p.Created); }catch (Exception) { prod.Created = DateTime.MinValue; }
                    try { prod.Modified = Convert.ToDateTime(p.Modified); }catch (Exception) { prod.Modified = DateTime.MinValue; }
                    try { prod.IsActive = Convert.ToBoolean(p.isActive); }catch (Exception) { prod.IsActive = false; }
                    products.Add(prod);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Product", "GetAllProducts");
            }
            return products;
        }

        public DataTable ToDataTable(List<Product> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(Product));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (Product item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        /// <summary>
        /// Purpose: Update an existing product
        /// Accepts: Nothing
        /// Returns: Boolean
        /// </summary>
        public bool UpdateProduct()
        {
            bool isSuccess = false;
            try
            {
                Hashtable hsh = new Hashtable();
                hsh["productcode"] = _productCode;
                hsh["name"] = _name;
                hsh["brand"] = _brand;
                hsh["description"] = _description;
                hsh["categoryid"] = _categoryID;
                hsh["msrp"] = _msrp;
                hsh["isfreeshipping"] = _isFreeShipping;
                hsh["istaxfree"] = _isTaxFree;
                hsh["quantityinstock"] = _quantityInStock;
                hsh["isquantityunlimited"] = _isQuantityUnlimited;
                hsh["created"] = _created;
                hsh["modified"] = _modified;
                hsh["isactive"] = IsActive;

                ProductData prodData = new ProductData();
                isSuccess = prodData.UpdateProduct(hsh);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Product", "UpdateProduct()");
            }

            return isSuccess;
        }

        /// <summary>
        /// Purpose: Add a new product
        /// Accepts: Nothing
        /// Returns: String (Product Code)
        /// </summary>
        public string AddProduct()
        {
            //The product code that was added to database
            string retProdcd = "";

            try
            {
                Hashtable hsh = new Hashtable();
                hsh["productcode"] = _productCode;
                hsh["name"] = _name;
                hsh["brand"] = _brand;
                hsh["description"] = _description;
                hsh["categoryid"] = _categoryID;
                hsh["msrp"] = _msrp;
                hsh["isfreeshipping"] = _isFreeShipping;
                hsh["istaxfree"] = _isTaxFree;
                hsh["quantityinstock"] = _quantityInStock;
                hsh["isquantityunlimited"] = _isQuantityUnlimited;
                hsh["created"] = _created;
                hsh["modified"] = _modified;
                hsh["isactive"] = IsActive;

                ProductData prodData = new ProductData();
                retProdcd = prodData.AddProduct(hsh);
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Product", "AddProduct()");
            }

            return retProdcd;
        }
    }
}
