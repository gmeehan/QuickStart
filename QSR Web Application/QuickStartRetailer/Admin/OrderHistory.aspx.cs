using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.Data;
using System.Web.UI.HtmlControls; //Connect presentation layer to web object layer

namespace QuickStartRetailer.Admin
{
    public partial class _OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdministratorID"] == null)
                Response.Redirect("~/Admin/Login.aspx");
            else
            {
                if (!Page.IsPostBack)
                {

                }
            }
        }


        protected void GridViewOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                ((HtmlAnchor)e.Row.FindControl("edit")).HRef = "Forms/EditOrderForm.aspx?orderid=" + drv[0].ToString();
            }
        }

        protected void GridViewOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewOrders.PageIndex = e.NewPageIndex;
            GridViewOrders.DataBind();
        }

        protected void GridViewOrders_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == (string)ViewState["SortColumn"])
            {
                // We are resorting the same column, so flip the sort direction
                e.SortDirection =
                    ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;
            }
            // Apply the sort
            DataTable dataTable = GridViewOrders.DataSource as DataTable;
            dataTable.DefaultView.Sort = e.SortExpression +
                (string)((e.SortDirection == SortDirection.Ascending) ? " ASC" : " DESC");
            ViewState["SortColumn"] = e.SortExpression;
            ViewState["SortColumnDirection"] = e.SortDirection;

            GridViewOrders.DataSource = dataTable;
            GridViewOrders.DataBind();
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            //Populate Orders grid
            Order order = new Order();
            DataTable dataTable = order.ToDataTable(order.GetAllOrders());
            GridViewOrders.DataSource = dataTable;
            GridViewOrders.DataBind();
        }

        protected void ButtonAddOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
