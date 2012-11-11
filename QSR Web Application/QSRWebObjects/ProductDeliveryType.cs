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
                ProductCode = hsh["productcode"];
                Created = hsh["created"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductDeliveryType", "GetProductDeliveryTypeByID");
            }
        }
    }
}
