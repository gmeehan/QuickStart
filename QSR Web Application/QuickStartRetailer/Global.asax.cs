using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace QuickStartRetailer
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

            //Admin site page routes    //THIS IS ALL BROKEN, COULDN'T GET IT WORKING -GRAHAM M, OCT 27/2012
            /*
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/Appearance", "Admin/Appearance", "~/Admin/Appearance.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/Categories", "Admin/Categories", "~/Admin/Categories.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/EditTables", "Admin/EditTables", "~/Admin/EditTables.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/EmailToUsers", "Admin/EmailToUsers", "~/Admin/EmailToUsers.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("", "Index/", "~/Admin/Index.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("", "Login/", "~/Admin/Login.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/OrderHistory", "Admin/OrderHistory", "~/Admin/OrderHistory.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/Pricing", "Admin/Pricing", "~/Admin/Pricing.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/Products", "Admin/Products", "~/Admin/Products.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/Purchasing", "Admin/Purchasing", "~/Admin/Purchasing.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/Taxes", "Admin/Taxes", "~/Admin/Taxes.aspx");
            System.Web.Routing.RouteTable.Routes.MapPageRoute("Admin/Users", "Admin/Users", "~/Admin/Users.aspx");
            */

            //Main site page routes

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
