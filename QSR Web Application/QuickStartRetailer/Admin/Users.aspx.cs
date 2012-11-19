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
    public partial class _Users : System.Web.UI.Page
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
    
        protected void GridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                ((HtmlAnchor)e.Row.FindControl("edit")).HRef = "Forms/EditUserForm.aspx?userid=" + drv[0].ToString();
            }
        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsers.PageIndex = e.NewPageIndex;
            GridViewUsers.DataBind();
        }

        protected void GridViewUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == (string)ViewState["SortColumn"])
            {
                // We are resorting the same column, so flip the sort direction
                e.SortDirection =
                    ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;
            }
            // Apply the sort
            DataTable dataTable = GridViewUsers.DataSource as DataTable;
            dataTable.DefaultView.Sort = e.SortExpression +
                (string)((e.SortDirection == SortDirection.Ascending) ? " ASC" : " DESC");
            ViewState["SortColumn"] = e.SortExpression;
            ViewState["SortColumnDirection"] = e.SortDirection;

            GridViewUsers.DataSource = dataTable;
            GridViewUsers.DataBind();
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            //Populate Users grid
            User user = new User();
            DataTable dataTable = user.ToDataTable(user.GetAllUsers());
            GridViewUsers.DataSource = dataTable;
            GridViewUsers.DataBind();
        }

        protected void ButtonAddUser_Click(object sender, EventArgs e)
        {

        }
    }
}

