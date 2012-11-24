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
    public class OrderItem : ErrorLogger
    {
        private int _orderItemID;
        private int _orderID;
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

        public Object OrderID
        {
            get { return _orderID; }
            set
            {
                try
                {
                    _orderID = Convert.ToInt32(value);
                }
                catch (Exception)
                {
                    _orderID = 0;
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
                OrderID = hsh["orderid"];
                ProductCode = hsh["productcode"];
                Created = hsh["created"];
                Modified = hsh["modified"];
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "OrderItem", "GetOrderItemByID");
            }
        }

        /// <summary>
        /// Purpose: Grabs all order items
        /// Accepts: Nothing
        /// Returns: List<OrderItem>
        /// </summary>
        public List<OrderItem> GetAllOrderItems()
        {
            List<OrderItem> orderitems = new List<OrderItem>();
            try
            {
                OrderItemData data = new OrderItemData();
                List<QSRDataObjects.OrderItem> dataOrderItems = data.GetAllOrderItems();

                foreach (QSRDataObjects.OrderItem oi in dataOrderItems)
                {
                    OrderItem order = new OrderItem();
                    order.OrderItemID = oi.OrderItemID;
                    order.OrderID = oi.OrderID;
                    order.ProductCode = oi.ProductCode;
                    order.Created = oi.Created;
                    order.Modified = oi.Modified;
                    orderitems.Add(order);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "OrderItem", "GetAllOrderItems");
            }
            return orderitems;
        }

        public DataTable ToDataTable(List<OrderItem> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(OrderItem));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (OrderItem item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderOrderItem
    {
        private int _orderItemID;

        public int OrderItemID
        {
            get { return _orderItemID; }
            set { _orderItemID = value; }
        }
        private int _orderID;

        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
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

        public RenderOrderItem(OrderItem oi)
        {
            OrderItemID = oi.OrderItemID;
            OrderID = Convert.ToInt32(oi.OrderID);
            ProductCode = Convert.ToString(oi.ProductCode);
            Created = Convert.ToDateTime(oi.Created);
            Modified = Convert.ToDateTime(oi.Modified);
        }

    }
}
