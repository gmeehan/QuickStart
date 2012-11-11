using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using QSRWebObjects; //Connect presentation layer to web object layer

namespace QuickStartRetailer
{
    public partial class _Category : System.Web.UI.Page
    {
        protected override void OnPreRender(EventArgs e)
        {
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Create the side menu
                BuildSideNavMenu();

                foreach (TreeNode rootNode in TreeViewLeftNav.Nodes)
                {
                    foreach (TreeNode node in rootNode.ChildNodes)
                    {
                        if (node.Value == Request.QueryString["id"])
                        {
                            node.Selected = true;
                        }
                    }
                }

                categoryChanged();
            }
        }

        private void BuildSideNavMenu()
        {
            //Clear existing nav menu items
            TreeViewLeftNav.Nodes.Clear();

            //Get the subcategory passed in by the query string
            Category cat = new Category();
            cat.GetCategoryByID(Int32.Parse(Request.QueryString["id"]));

            //Get the parent category for this subcategory
            Category parentCat = new Category();
            parentCat.GetCategoryByID(cat.ParentCategoryID);

            //Set the parent category
            TreeNode categoryNode = new TreeNode();
            categoryNode.Text = parentCat.Name.ToString();
            categoryNode.Expanded = true;
            TreeViewLeftNav.Nodes.Add(categoryNode);

            //Get all active categories
            List<Category> cats = cat.GetAllCategories(true);

            foreach (Category c in cats)
            {
                if (c.ParentCategoryID == parentCat.CategoryID)
                {
                    TreeNode subCategoryNode = new TreeNode();
                    subCategoryNode.Text = c.Name.ToString();
                    subCategoryNode.Value = c.CategoryID.ToString();
                    categoryNode.ChildNodes.Add(subCategoryNode);
                }
            }
        }

        protected void TreeViewLeftNav_SelectedNodeChanged(object sender, EventArgs e)
        {
            categoryChanged();
        }

        private void categoryChanged()
        {
            //Get the selected category object
            Category cat = new Category();
            cat.GetCategoryByID(Convert.ToInt32(TreeViewLeftNav.SelectedValue));

            //Set the title for content section
            subcategoryTitle.InnerText = cat.Name.ToString();

            //Get all products for this category
            Product prod = new Product();
            List<Product> prods = prod.GetAllProductsByCategoryID(Convert.ToInt32(TreeViewLeftNav.SelectedValue),true);

            DataListProducts.DataSource = prods;
            DataListProducts.DataBind();

        }

        protected void DataListProducts_ItemCreated(object sender, DataListItemEventArgs e)
        {
            //If this is the middle cell on the first row...
            if (e.Item.ItemIndex == 1)
            {
                //Add vertical borders to cell
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-left", "1px dotted silver");
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-right", "1px dotted silver");
            }
            if ((e.Item.ItemIndex - 1) % 3 == 0) //If this is the middle element on 2nd or later row
            {
                //Add vertical borders to cell
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-left", "1px dotted silver");
                ((HtmlContainerControl)(e.Item.FindControl("productListInnerCell"))).Style.Add("border-right", "1px dotted silver");
            }
        }
    }
}
