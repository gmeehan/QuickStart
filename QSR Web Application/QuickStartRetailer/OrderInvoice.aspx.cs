using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.Data; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _OrderInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
            else
            {
                InvoiceItem ii = new InvoiceItem();
                OrderItemsGrid.DataSource = ii.GetAllInvoiceItemsByOrderID(Convert.ToInt32(Request.QueryString["orderid"]));
                DataBind();

                if (!Page.IsPostBack)
                {

                }
            }
        }

        protected void HistoryGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == (string)ViewState["SortColumn"])
            {
                // We are resorting the same column, so flip the sort direction
                e.SortDirection =
                    ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;
            }
            // Apply the sort
            DataTable dataTable = OrderItemsGrid.DataSource as DataTable;
            dataTable.DefaultView.Sort = e.SortExpression +
                (string)((e.SortDirection == SortDirection.Ascending) ? " ASC" : " DESC");
            ViewState["SortColumn"] = e.SortExpression;
            ViewState["SortColumnDirection"] = e.SortDirection;

            OrderItemsGrid.DataSource = dataTable;
            OrderItemsGrid.DataBind();
        }
    }
}
