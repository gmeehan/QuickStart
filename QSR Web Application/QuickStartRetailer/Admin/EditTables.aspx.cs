using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using QSRWebObjects; //Connect presentation layer to web object layer

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
            /*
            if (DropDownListDBTables.SelectedValue == "Administrators")
            {
                Administrator obj = new Administrator();
                GridViewDBTable.DataSource = obj.GetAllAdministrators(false);
            }
            else if (DropDownListDBTables.SelectedValue == "AuditTypes")
            {
                AuditType obj = new AuditType();
                GridViewDBTable.DataSource = obj.GetAllAuditTypes(false);
            }
            if (DropDownListDBTables.SelectedValue == "Categories")
            {
                Category obj = new Category();
                GridViewDBTable.DataSource = obj.GetAllCategories(false);
            }
            else if (DropDownListDBTables.SelectedValue == "Configurations")
            {
                Configuration obj = new Configuration();
                GridViewDBTable.DataSource = obj.GetAllConfigurations(false);
            }
            else if (DropDownListDBTables.SelectedValue == "DeliveryType")
            {
                DeliveryType obj = new DeliveryType();
                GridViewDBTable.DataSource = obj.GetAllDeliveryTypes(false);
            }
            else if (DropDownListDBTables.SelectedValue == "LangLabels")
            {
                LangLabel obj = new LangLabel();
                GridViewDBTable.DataSource = obj.GetAllLangLabels(false);
            }
            else if (DropDownListDBTables.SelectedValue == "OrderItems")
            {
                OrderItem obj = new OrderItem();
                GridViewDBTable.DataSource = obj.GetAllOrderItems(false);
            }
            else if (DropDownListDBTables.SelectedValue == "Orders")
            {
                Order obj = new Order();
                GridViewDBTable.DataSource = obj.GetAllOrders(false);
            }
            else if (DropDownListDBTables.SelectedValue == "ProductDeliveryTypes")
            {
                ProductDeliveryType obj = new ProductDeliveryType();
                GridViewDBTable.DataSource = obj.GetAllProductDeliveryTypes(false);
            }
            else if (DropDownListDBTables.SelectedValue == "Products")
            {
                Product obj = new Product();
                GridViewDBTable.DataSource = obj.GetAllProducts(false);
            }
            else if (DropDownListDBTables.SelectedValue == "StatesProvinces")
            {
                StateProvince obj = new StateProvince();
                GridViewDBTable.DataSource = obj.GetAllStatesProvinces(false);
            }
            else if (DropDownListDBTables.SelectedValue == "Users")
            {
                User obj = new User();
                GridViewDBTable.DataSource = obj.GetAllUsers(false);
            }

            //Databind the new datasource obtained above
            GridViewDBTable.DataBind();
             */
        }
        
    }
}
