using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class OrderItem : ErrorLogger
    {
        private int _orderItemID;
        private string _productCode;
        private DateTime _created;
        private DateTime _modified;

        public int OrderItemID
        {
            get { return _orderItemID; }
            set { _orderItemID = value; }
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
        /// Purpose: Grabs order item information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetOrderItemByID(int id)
        {
            try
            {
                OrderItemData data = new OrderItemData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetOrderItemByID(id);

                _orderItemID = id;
                try{ _productCode = hsh["productcode"].ToString(); } catch (Exception){ _productCode = ""; }
                try{ _created = Convert.ToDateTime(hsh["created"]); } catch (Exception){ _created = DateTime.MinValue; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "OrderItem", "GetOrderItemByID");
            }
        }
    }
}
