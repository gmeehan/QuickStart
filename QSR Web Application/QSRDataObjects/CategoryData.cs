using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace QSRDataObjects
{
    public class CategoryData : ErrorLoggerData
    {
        /// <summary>
        /// Purpose: Grabs category information based on ID
        /// Accepts: Int
        /// Returns: Hashtable
        /// </summary>
        public Hashtable GetCategoryByID(int id)
        {
            Category obj = new Category();
            QuickStart_DBEntities dbContext;
            Hashtable hsh = new Hashtable();
            try
            {
                dbContext = new QuickStart_DBEntities();
                obj = dbContext.Categories.FirstOrDefault(c => c.CategoryID == id);
                if (obj != null)
                {
                    hsh["categoryid"] = obj.CategoryID;
                    hsh["name"] = obj.Name;
                    hsh["description"] = obj.Description;
                    hsh["parentcategoryid"] = obj.ParentCategoryID;
                    hsh["created"] = obj.Created;
                    hsh["modified"] = obj.Modified;
                    hsh["isactive"] = obj.IsActive;
                }
            }
            catch (Exception ex)
            {
                ErrorLoggerData.ErrorRoutine(ex, "CategoryData", "GetCategoryByID");
            }

            return hsh;
        }

        /// <summary>
        /// Purpose: Grabs all categories
        /// Accepts: Boolean
        /// Returns: List<Category>
        /// </summary>
        public List<Category> GetAllCategories(bool onlyActive)
        {
            QuickStart_DBEntities dbContext;
            List<Category> allCategories = null;
            try
            {
                dbContext = new QuickStart_DBEntities();

                if (onlyActive == true) //only the active categories are returned
                {
                    allCategories = dbContext.Categories.Where(c => c.IsActive == true).ToList();
                }
                else //all categories are returned
                {
                    allCategories = dbContext.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "CategoryData", "GetAllCategories");
            }

            return allCategories;
        }
    }
}
