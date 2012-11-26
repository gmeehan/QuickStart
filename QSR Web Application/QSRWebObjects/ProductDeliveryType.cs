using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class ProductDeliveryType : ErrorLogger
    {
        private int _productDeliveryTypeID;
        private int _deliveryTypeID;
        private string _productCode;
        private DateTime _created;
        private DateTime _modified;

        public int ProductDeliveryTypeID
        {
            get { return _productDeliveryTypeID; }
            set
            {
                try
                {
                    _productDeliveryTypeID = value;
                }
                catch (Exception)
                {
                    _productDeliveryTypeID = 0;
                }
            }
        }

        public int DeliveryTypeID
        {
            get { return _deliveryTypeID; }
            set
            {
                try
                {
                    _deliveryTypeID = value;
                }
                catch (Exception)
                {
                    _deliveryTypeID = 0;
                }
            }
        }

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

        /// <summary>
        /// Purpose: Grabs product delivery type information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetProductDeliveryTypeByID(int id)
        {
            try
            {
                ProductDeliveryTypeData data = new ProductDeliveryTypeData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetProductDeliveryTypeByID(id);

                ProductDeliveryTypeID = id;
                DeliveryTypeID = Convert.ToInt32(hsh["deliverytypeid"]);
                ProductCode = hsh["productcode"];
                Created = hsh["created"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductDeliveryType", "GetProductDeliveryTypeByID");
            }
        }

        /// <summary>
        /// Purpose: Grabs all product delivery types
        /// Accepts: Nothing
        /// Returns: List<ProductDeliveryType>
        /// </summary>
        public List<ProductDeliveryType> GetAllProductDeliveryTypes()
        {
            List<ProductDeliveryType> pdtypes = new List<ProductDeliveryType>();
            try
            {
                ProductDeliveryTypeData data = new ProductDeliveryTypeData();
                List<QSRDataObjects.ProductDeliveryType> dataPDTypes = data.GetAllProductDeliveryTypes();

                foreach (QSRDataObjects.ProductDeliveryType pdt in dataPDTypes)
                {
                    ProductDeliveryType pdtype = new ProductDeliveryType();
                    pdtype.ProductDeliveryTypeID = pdt.ProductDeliveryTypeID;
                    pdtype.DeliveryTypeID = Convert.ToInt32(pdt.DeliveryTypeID);
                    pdtype.ProductCode = pdt.ProductCode;
                    pdtype.Created = pdt.Created;
                    pdtype.Modified = pdt.Modified;
                    pdtypes.Add(pdtype);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductDeliveryType", "GetAllProductDeliveryTypes");
            }
            return pdtypes;
        }

        /// <summary>
        /// Purpose: Grabs all product delivery types by product code
        /// Accepts: String (Product Code)
        /// Returns: List<ProductDeliveryType>
        /// </summary>
        public List<ProductDeliveryType> GetAllProductDeliveryTypesByProdCode(string prodcd)
        {
            List<ProductDeliveryType> pdtypes = new List<ProductDeliveryType>();
            try
            {
                ProductDeliveryTypeData data = new ProductDeliveryTypeData();
                List<QSRDataObjects.ProductDeliveryType> dataPDTypes = data.GetAllProductDeliveryTypesByProdCode(prodcd);

                foreach (QSRDataObjects.ProductDeliveryType pdt in dataPDTypes)
                {
                    ProductDeliveryType pdtype = new ProductDeliveryType();
                    pdtype.ProductDeliveryTypeID = pdt.ProductDeliveryTypeID;
                    pdtype.DeliveryTypeID = Convert.ToInt32(pdt.DeliveryTypeID);
                    pdtype.ProductCode = pdt.ProductCode;
                    pdtype.Created = pdt.Created;
                    pdtype.Modified = pdt.Modified;
                    pdtypes.Add(pdtype);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductDeliveryType", "GetAllProductDeliveryTypesByProdCode");
            }
            return pdtypes;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderProductDeliveryType
    {
        private int _productDeliveryTypeID;

        public int ProductDeliveryTypeID
        {
            get { return _productDeliveryTypeID; }
            set { _productDeliveryTypeID = value; }
        }

        private int _deliveryTypeID;

        public int DeliveryTypeID
        {
            get { return _deliveryTypeID; }
            set { _deliveryTypeID = value; }
        }

        private string _productCode;

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
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

        public RenderProductDeliveryType(ProductDeliveryType pdt)
        {
            ProductDeliveryTypeID = pdt.ProductDeliveryTypeID;
            ProductCode = Convert.ToString(pdt.ProductCode);
            Created = Convert.ToDateTime(pdt.Created);
            Modified = Convert.ToDateTime(pdt.Modified);
        }

    }
}
