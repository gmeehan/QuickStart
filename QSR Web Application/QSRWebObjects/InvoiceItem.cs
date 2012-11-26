using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QSRDataObjects;

namespace QSRWebObjects
{
    //Invoice item is used to display full details of an order item, including its product info and tax info
    public class InvoiceItem : ErrorLogger
    {
        private string _prodCode;
        private string _prodName;
        private string _prodDesc;
        private double _msrp;
        private int _quantity;
        private double _tax;
        private double _total;

        public string ProdCode
        {
            get { return _prodCode; }
            set { _prodCode = value; }
        }

        public string ProdName
        {
            get { return _prodName; }
            set { _prodName = value; }
        }

        public string ProdDesc
        {
            get { return _prodDesc; }
            set { _prodDesc = value; }
        }

        public double Msrp
        {
            get { return _msrp; }
            set { _msrp = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public double Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public double Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public List<InvoiceItem> GetAllInvoiceItemsByOrderID(int orderid)
        {
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>();
            try
            {
                InvoiceItemData data = new InvoiceItemData();
                List<QSRDataObjects.InvoiceItem> dataInvoiceItems = data.GetAllInvoiceItemsByOrderID(orderid);

                foreach (QSRDataObjects.InvoiceItem dataItem in dataInvoiceItems)
                {
                    InvoiceItem item = new InvoiceItem();
                    item.ProdCode = dataItem.ProductCode;
                    item.ProdName = dataItem.ProductName;
                    item.ProdDesc = dataItem.ProductDescription;
                    item.Msrp = Convert.ToDouble(dataItem.MSRP);
                    item.Quantity = dataItem.Quantity.Value;
                    item.Tax = dataItem.TaxAmount.Value;
                    invoiceItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "InvoiceItem", "GetAllInvoiceItemsByOrderID");
            }
            return invoiceItems;
        }
    }
}
