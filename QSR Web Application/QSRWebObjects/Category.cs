using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using QSRDataObjects; //Connect web layer to data layer

namespace QSRWebObjects
{
    public class Category : ErrorLogger
    {
        private int _categoryID;
        private string _name;
        private string _description;
        private int _parentCategoryID;
        private DateTime _created;
        private DateTime _modified;
        private bool _isActive;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        /// <summary>
        /// Purpose: Grabs category information based on ID
        /// Accepts: Int
        /// Returns: Nothing
        /// </summary>
        public void GetCategoryByID(int id)
        {
            try
            {
                CategoryData data = new CategoryData();
                Hashtable hsh = new Hashtable();

                hsh = data.GetCategoryByID(id);

                _categoryID = id;
                try{ _name = hsh["name"].ToString(); } catch (Exception){ _name = ""; }
                try{ _description = hsh["description"].ToString(); } catch (Exception){ _description = ""; }
                try{ _parentCategoryID = Convert.ToInt32(hsh["parentcategoryid"]); } catch (Exception){ _parentCategoryID = 0; }
                try{ _created = Convert.ToDateTime(hsh["created"]); } catch (Exception){ _created = DateTime.MinValue; }
                try{ _modified = Convert.ToDateTime(hsh["modified"]); } catch (Exception){ _modified = DateTime.MinValue; }
                try{ _isActive = Convert.ToBoolean(hsh["isactive"]); } catch (Exception){ _isActive = false; }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Category", "GetCategoryByID");
            }
        }

        /// <summary>
        /// Purpose: Grabs all categories
        /// Accepts: Boolean
        /// Returns: List<Category>
        /// </summary>
        public List<Category> GetAllCategories(bool onlyActive)
        {
            List<Category> categories = new List<Category>();
            try
            {
                CategoryData data = new CategoryData();
                List<QSRDataObjects.Category> dataCategories = data.GetAllCategories(onlyActive);

                foreach (QSRDataObjects.Category c in dataCategories)
                {
                    Category cat = new Category();
                    cat.CategoryID = c.CategoryID;
                    cat.Name = c.Name;
                    cat.Description = c.Description;
                    cat.ParentCategoryID = Convert.ToInt32(c.ParentCategoryID);
                    cat.Created = Convert.ToDateTime(c.Created);
                    cat.Modified = Convert.ToDateTime(c.Modified);
                    cat.IsActive = Convert.ToBoolean(c.IsActive);
                    categories.Add(cat);
                }
            }
            catch (Exception ex)
            {
                ErrorRoutine(ex, "Category", "GetAllCategories");
            }
            return categories;
        }

    }
}
