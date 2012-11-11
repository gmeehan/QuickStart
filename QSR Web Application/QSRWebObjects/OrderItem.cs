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
            set
            {
                try
                {
                    _orderItemID = value;
                }
                catch (Exception)
                {
                    _orderItemID = 0;
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

                OrderItemID = id;
                ProductCode = hsh["productcode"];
                Created = hsh["created"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "OrderItem", "GetOrderItemByID");
            }
        }
    }
}
