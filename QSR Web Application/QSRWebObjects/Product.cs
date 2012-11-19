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

        public Object ProductCode
        {
            get { return _productCode; }
            set
            {
                try
                {
                    _productCode = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _productCode = "";
                }
            }
        }

        public Object Name
        {
            get { return _name; }
            set
            {
                try
                {
                    _name = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _name = "";
                }
            }
        }

        public Object Brand
        {
            get { return _brand; }
            set
            {
                try
                {
                    _brand = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _brand = "";
                }
            }
        }

        public Object Description
        {
            get { return _description; }
            set
            {
                try
                {
                    _description = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _description = "";
                }
            }
        }

        public int CategoryID
        {
            get { return _categoryID; }
            set
            {
                try
                {
                    _categoryID = value;
                }
                catch (Exception)
                {
                    _categoryID = 0;
                }
            }
        }

        public string CategoryName
        {
            get {
                QSRWebObjects.Category cat = new QSRWebObjects.Category();
                cat.GetCategoryByID(_categoryID);
                return cat.Name.ToString();
            }
        }

        public double Msrp
        {
            get { return _msrp; }
            set
            {
                try
                {
                    _msrp = value;
                }
                catch (Exception)
                {
                    _msrp = 0.00;
                }
            }
        }

        public Object IsFreeShipping
        {
            get { return _isFreeShipping; }
            set
            {
                try
                {
                    _isFreeShipping = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isFreeShipping = false;
                }
            }
        }

        public Object IsTaxFree
        {
            get { return _isTaxFree; }
            set
            {
                try
                {
                    _isTaxFree = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isTaxFree = false;
                }
            }
        }

        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set
            {
                try
                {
                    _quantityInStock = value;
                }
                catch (Exception)
                {
                    _quantityInStock = 0;
                }
            }
        }

        public Object IsQuantityUnlimited
        {
            get { return _isQuantityUnlimited; }
            set
            {
                try
                {
                    _isQuantityUnlimited = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isQuantityUnlimited = false;
                }
            }
        }

        public Object Created
        {
            get { return _created; }
            set
            {
                try
                {
                    _created = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _created = DateTime.MinValue;
                }
            }
        }

        public Object Modified
        {
            get { return _modified; }
            set
            {
                try
                {
                    _modified = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _modified = DateTime.MinValue;
                }
            }
        }

        //This is used to return null if Mofidied is min value and therefore
        //not show the date in a gridview which has NullDisplayText set.
        public DateTime? ModifiedDisplay
        {
            get
            {
                if (Convert.ToDateTime(this.Modified) == default(DateTime))
                    return null;
                else
                    return Convert.ToDateTime(this.Modified);
            }
        }

        public Object IsActive
        {
            get { return _isActive; }
            set
            {
                try
                {
                    _isActive = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isActive = false;
                }
            }
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

                ProductCode = code;
                Name = hsh["name"];
                Brand = hsh["brand"];
                Description = hsh["description"];
                CategoryID = Convert.ToInt32(hsh["categoryid"]);
                Msrp = Convert.ToDouble(hsh["msrp"]);
                IsFreeShipping = hsh["isfreeshipping"];
                IsTaxFree = hsh["istaxfree"];
                QuantityInStock = Convert.ToInt32(hsh["quantityinstock"]);
                IsQuantityUnlimited = hsh["isquantityunlimited"];
                Created = hsh["created"];
                Modified = hsh["modified"];
                IsActive = hsh["isactive"];
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
                    prod.ProductCode = p.ProductCode;
                    prod.Name = p.Name;
                    prod.Brand = p.Brand;
                    prod.Description = p.Description;
                    prod.CategoryID = Convert.ToInt32(p.CategoryID);
                    prod.Msrp = Convert.ToDouble(p.MSRP);
                    prod.IsFreeShipping = p.isFreeShipping;
                    prod.IsTaxFree = p.isTaxFree;
                    prod.QuantityInStock = Convert.ToInt32(p.QuantityInStock);
                    prod.IsQuantityUnlimited = p.IsQuantityUnlimited;
                    prod.Created = p.Created;
                    prod.Modified = p.Modified;
                    prod.IsActive = p.isActive;
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
                    prod.ProductCode = p.ProductCode;
                    prod.Name = p.Name;
                    prod.Brand = p.Brand;
                    prod.Description = p.Description;
                    prod.CategoryID = Convert.ToInt32(p.CategoryID);
                    prod.Msrp = Convert.ToDouble(p.MSRP);
                    prod.IsFreeShipping = p.isFreeShipping;
                    prod.IsTaxFree = p.isTaxFree;
                    prod.QuantityInStock = Convert.ToInt32(p.QuantityInStock);
                    prod.IsQuantityUnlimited = p.IsQuantityUnlimited;
                    prod.Created = p.Created;
                    prod.Modified = p.Modified;
                    prod.IsActive = p.isActive;
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
                hsh["productcode"] = ProductCode;
                hsh["name"] = Name;
                hsh["brand"] = Brand;
                hsh["description"] = Description;
                hsh["categoryid"] = CategoryID;
                hsh["msrp"] = Msrp;
                hsh["isfreeshipping"] = IsFreeShipping;
                hsh["istaxfree"] = IsTaxFree;
                hsh["quantityinstock"] = QuantityInStock;
                hsh["isquantityunlimited"] = IsQuantityUnlimited;
                hsh["created"] = Created;
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
                hsh["productcode"] = ProductCode;
                hsh["name"] = Name;
                hsh["brand"] = Brand;
                hsh["description"] = Description;
                hsh["categoryid"] = CategoryID;
                hsh["msrp"] = Msrp;
                hsh["isfreeshipping"] = IsFreeShipping;
                hsh["istaxfree"] = IsTaxFree;
                hsh["quantityinstock"] = QuantityInStock;
                hsh["isquantityunlimited"] = IsQuantityUnlimited;
                hsh["created"] = Created;
                hsh["modified"] = Modified;
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

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderProduct
    {
        private string _productCode;

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        private double _msrp;

        public double Msrp
        {
            get { return _msrp; }
            set { _msrp = value; }
        }
        private bool _isFreeShipping;

        public bool IsFreeShipping
        {
            get { return _isFreeShipping; }
            set { _isFreeShipping = value; }
        }
        private bool _isTaxFree;

        public bool IsTaxFree
        {
            get { return _isTaxFree; }
            set { _isTaxFree = value; }
        }
        private int _quantityInStock;

        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set { _quantityInStock = value; }
        }
        private bool _isQuantityUnlimited;

        public bool IsQuantityUnlimited
        {
            get { return _isQuantityUnlimited; }
            set { _isQuantityUnlimited = value; }
        }
        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        private DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }
        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public RenderProduct(Product p)
        {
            ProductCode = Convert.ToString(p.ProductCode);
            Name = Convert.ToString(p.Name);
            Brand = Convert.ToString(p.Brand);
            Description = Convert.ToString(p.Description);
            CategoryID = Convert.ToInt32(p.CategoryID);
            Msrp = Convert.ToDouble(p.Msrp);
            IsFreeShipping = Convert.ToBoolean(p.IsFreeShipping);
            IsTaxFree = Convert.ToBoolean(p.IsTaxFree);
            QuantityInStock = Convert.ToInt32(p.QuantityInStock);
            IsQuantityUnlimited = Convert.ToBoolean(p.IsQuantityUnlimited);
            Created = Convert.ToDateTime(p.Created);
            Modified = Convert.ToDateTime(p.Modified);
            IsActive = Convert.ToBoolean(p.IsActive);
        }

    }
}
