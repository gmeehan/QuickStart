using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using QSRWebObjects;
using System.Data;
using System.ComponentModel; //Connect presentation layer to web object layer

namespace QuickStartRetailer.Admin
{
    public partial class _Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdministratorID"] == null)
                Response.Redirect("~/Admin/Login.aspx");
            else
            {
                if (!Page.IsPostBack)
                {
                    //Populate the featured product dropdowns
                    Product prod = new Product();
                    List<Product> products = prod.GetAllProducts(true);
                    DropDownListFeaturedProduct1.DataSource = products;
                    DropDownListFeaturedProduct1.DataTextField = "ProductCode";
                    DropDownListFeaturedProduct1.DataValueField = "ProductCode";
                    DropDownListFeaturedProduct1.DataBind();
                    Configuration config1 = new Configuration();
                    config1.GetConfigurationByCode("xFeaturedProduct1");
                    DropDownListFeaturedProduct1.SelectedValue = config1.Value.ToString();


                    DropDownListFeaturedProduct2.DataSource = products;
                    DropDownListFeaturedProduct2.DataTextField = "ProductCode";
                    DropDownListFeaturedProduct2.DataValueField = "ProductCode";
                    DropDownListFeaturedProduct2.DataBind();
                    Configuration config2 = new Configuration();
                    config2.GetConfigurationByCode("xFeaturedProduct2");
                    DropDownListFeaturedProduct2.SelectedValue = config2.Value.ToString();

                    DropDownListFeaturedProduct3.DataSource = products;
                    DropDownListFeaturedProduct3.DataTextField = "ProductCode";
                    DropDownListFeaturedProduct3.DataValueField = "ProductCode";
                    DropDownListFeaturedProduct3.DataBind();
                    Configuration config3 = new Configuration();
                    config3.GetConfigurationByCode("xFeaturedProduct3");
                    DropDownListFeaturedProduct3.SelectedValue = config3.Value.ToString();

                    DropDownListFeaturedProduct4.DataSource = products;
                    DropDownListFeaturedProduct4.DataTextField = "ProductCode";
                    DropDownListFeaturedProduct4.DataValueField = "ProductCode";
                    DropDownListFeaturedProduct4.DataBind();
                    Configuration config4 = new Configuration();
                    config4.GetConfigurationByCode("xFeaturedProduct4");
                    DropDownListFeaturedProduct4.SelectedValue = config4.Value.ToString();
                }
            }
        }

        protected void GridViewProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                ((HtmlAnchor)e.Row.FindControl("edit")).HRef = "Forms/EditProductForm.aspx?prodcd=" + drv[0].ToString();
                /*
                HtmlAnchor htmlanchor = new HtmlAnchor();
                htmlanchor.HRef = "Forms/AddProductForm.aspx?this=4";
                htmlanchor.
                htmlanchor.Title = "Edit"; //tooltip
                htmlanchor.InnerHtml = "<img alt=\"edit\" src=\"Images/clipboard_edit.png\" />";
                e.Row.Cells[12].Controls.Add(htmlanchor);
                */

                DataRowView row = (DataRowView)e.Row.DataItem; 

                if (Convert.ToBoolean(row["isActive"]))
                {
                    ((HtmlAnchor)e.Row.FindControl("activation")).InnerHtml = "<img alt=\"deactivate\" src=\"Images/Check-icon.png\" />";
                    ((HtmlAnchor)e.Row.FindControl("activation")).HRef = "Forms/DeactivateProductForm.aspx?prodcd=" + drv[0].ToString();
                }
                else
                {
                    ((HtmlAnchor)e.Row.FindControl("activation")).InnerHtml = "<img alt=\"activate\" src=\"Images/X-icon.png\" />";
                    ((HtmlAnchor)e.Row.FindControl("activation")).HRef = "Forms/ActivateProductForm.aspx?prodcd=" + drv[0].ToString();
                }

            }
        }

        protected void GridViewProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProducts.PageIndex = e.NewPageIndex;
            GridViewProducts.DataBind();
        }

        protected void GridViewProducts_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == (string)ViewState["SortColumn"])
            {
                // We are resorting the same column, so flip the sort direction
                e.SortDirection =
                    ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;
            }
            // Apply the sort
            DataTable dataTable = GridViewProducts.DataSource as DataTable;
            dataTable.DefaultView.Sort = e.SortExpression +
                (string)((e.SortDirection == SortDirection.Ascending) ? " ASC" : " DESC");
            ViewState["SortColumn"] = e.SortExpression;
            ViewState["SortColumnDirection"] = e.SortDirection;

            GridViewProducts.DataSource = dataTable;
            GridViewProducts.DataBind();
        }

        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            //Populate products grid
            Product product = new Product();
            DataTable dataTable = product.ToDataTable(product.GetAllProducts(false));
            GridViewProducts.DataSource = dataTable;
            GridViewProducts.DataBind();
        }

        protected void ButtonAddProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
