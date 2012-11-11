using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects;
using System.Data; //Connect presentation layer to web object layer

namespace QuickStartRetailer.Admin
{
    public partial class _EditTables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdministratorID"] == null)
                Response.Redirect("~/Admin/Login.aspx");
            else
            {
                if (!Page.IsPostBack)
                {
                    String[] tableNames = {"Select Table...", "Administrators", "Audits", "AuditTypes", "Categories", 
                                           "Configurations", "DeliveryType", "LangLabels", "OrderItems", "Orders",
                                           "ProductDeliveryTypes", "Products", "StatesProvinces", "Users" };

                    DropDownListDBTables.DataSource = tableNames;
                    DropDownListDBTables.DataBind();
                }
            }
        }

        protected void DropDownListDBTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reload gridview for the selected table
            reloadGridView();
        }

        private void reloadGridView()
        {
            if (DropDownListDBTables.SelectedValue == "Administrators")
            {
                //Get all objects
                Administrator obj = new Administrator();
                List<Administrator> list = obj.GetAllAdministrators(false);

                //Fill a rendered object list
                List<RenderAdministrator> renderedList = new List<RenderAdministrator>();
                foreach (Administrator x in list)
                {
                    renderedList.Add(new RenderAdministrator(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "Audits")
            {
                //Get all objects
                Audit obj = new Audit();
                List<Audit> list = obj.GetAllAudits();

                //Fill a rendered object list
                List<RenderAudit> renderedList = new List<RenderAudit>();
                foreach (Audit x in list)
                {
                    renderedList.Add(new RenderAudit(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "AuditTypes")
            {
                //Get all objects
                AuditType obj = new AuditType();
                List<AuditType> list = obj.GetAllAuditTypes();

                //Fill a rendered object list
                List<RenderAuditType> renderedList = new List<RenderAuditType>();
                foreach (AuditType x in list)
                {
                    renderedList.Add(new RenderAuditType(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            if (DropDownListDBTables.SelectedValue == "Categories")
            {
                //Get all objects
                Category obj = new Category();
                List<Category> list = obj.GetAllCategories(false);

                //Fill a rendered object list
                List<RenderCategory> renderedList = new List<RenderCategory>();
                foreach (Category x in list)
                {
                    renderedList.Add(new RenderCategory(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "Configurations")
            {
                //Get all objects
                Configuration obj = new Configuration();
                List<Configuration> list = obj.GetAllConfigurations();

                //Fill a rendered object list
                List<RenderConfiguration> renderedList = new List<RenderConfiguration>();
                foreach (Configuration x in list)
                {
                    renderedList.Add(new RenderConfiguration(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "DeliveryType")
            {
                //Get all objects
                DeliveryType obj = new DeliveryType();
                List<DeliveryType> list = obj.GetAllDeliveryTypes();

                //Fill a rendered object list
                List<RenderDeliveryType> renderedList = new List<RenderDeliveryType>();
                foreach (DeliveryType x in list)
                {
                    renderedList.Add(new RenderDeliveryType(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "LangLabels")
            {
                //Get all objects
                LangLabel obj = new LangLabel();
                List<LangLabel> list = obj.GetAllLangLabels();

                //Fill a rendered object list
                List<RenderLangLabel> renderedList = new List<RenderLangLabel>();
                foreach (LangLabel x in list)
                {
                    renderedList.Add(new RenderLangLabel(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "OrderItems")
            {
                //Get all objects
                OrderItem obj = new OrderItem();
                List<OrderItem> list = obj.GetAllOrderItems();

                //Fill a rendered object list
                List<RenderOrderItem> renderedList = new List<RenderOrderItem>();
                foreach (OrderItem x in list)
                {
                    renderedList.Add(new RenderOrderItem(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "Orders")
            {
                //Get all objects
                Order obj = new Order();
                List<Order> list = obj.GetAllOrders();

                //Fill a rendered object list
                List<RenderOrder> renderedList = new List<RenderOrder>();
                foreach (Order x in list)
                {
                    renderedList.Add(new RenderOrder(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "ProductDeliveryTypes")
            {
                //Get all objects
                ProductDeliveryType obj = new ProductDeliveryType();
                List<ProductDeliveryType> list = obj.GetAllProductDeliveryTypes();

                //Fill a rendered object list
                List<RenderProductDeliveryType> renderedList = new List<RenderProductDeliveryType>();
                foreach (ProductDeliveryType x in list)
                {
                    renderedList.Add(new RenderProductDeliveryType(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "Products")
            {
                //Get all objects
                Product obj = new Product();
                List<Product> list = obj.GetAllProducts(false);

                //Fill a rendered object list
                List<RenderProduct> renderedList = new List<RenderProduct>();
                foreach(Product x in list)
                {
                    renderedList.Add(new RenderProduct(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "StatesProvinces")
            {
                //Get all objects
                StateProvince obj = new StateProvince();
                List<StateProvince> list = obj.GetAllStatesProvinces();

                //Fill a rendered object list
                List<RenderStateProvince> renderedList = new List<RenderStateProvince>();
                foreach (StateProvince x in list)
                {
                    renderedList.Add(new RenderStateProvince(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }
            else if (DropDownListDBTables.SelectedValue == "Users")
            {
                //Get all objects
                User obj = new User();
                List<User> list = obj.GetAllUsers();

                //Fill a rendered object list
                List<RenderUser> renderedList = new List<RenderUser>();
                foreach (User x in list)
                {
                    renderedList.Add(new RenderUser(x));
                }

                GridViewDBTable.DataSource = renderedList;
            }

            //Databind the new datasource obtained above
            GridViewDBTable.DataBind();
        }

        protected void GridViewDBTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDBTable.PageIndex = e.NewPageIndex;
            GridViewDBTable.DataBind();
        }

        protected void GridViewDBTable_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == (string)ViewState["SortColumn"])
            {
                // We are resorting the same column, so flip the sort direction
                e.SortDirection =
                    ((SortDirection)ViewState["SortColumnDirection"] == SortDirection.Ascending) ?
                    SortDirection.Descending : SortDirection.Ascending;
            }
            // Apply the sort
            DataTable dataTable = GridViewDBTable.DataSource as DataTable;
            dataTable.DefaultView.Sort = e.SortExpression +
                (string)((e.SortDirection == SortDirection.Ascending) ? " ASC" : " DESC");
            ViewState["SortColumn"] = e.SortExpression;
            ViewState["SortColumnDirection"] = e.SortDirection;

            GridViewDBTable.DataSource = dataTable;
            GridViewDBTable.DataBind();
        }
    }
}
