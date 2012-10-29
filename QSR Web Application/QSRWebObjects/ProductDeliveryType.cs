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
            set { _productDeliveryTypeID = value; }
        }

        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
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

                _productDeliveryTypeID = id;
                try{ _productCode = hsh["productcode"].ToString(); } catch (Exception){ _productCode = ""; }
                try{ _created = Convert.ToDateTime(hsh["created"]); } catch (Exception){ _created = DateTime.MinValue; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "ProductDeliveryType", "GetProductDeliveryTypeByID");
            }
        }
    }
}
