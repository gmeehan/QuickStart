﻿using System;
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
            set
            {
                try
                {
                    _categoryID = value;
                }
                catch (Exception)
                {
                    _categoryID = 0;
                }
            }
        }

        public Object Name
        {
            get { return _name; }
            set
            {
                try
                {
                    _name = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _name = "";
                }
            }
        }

        public Object Description
        {
            get { return _description; }
            set
            {
                try
                {
                    _description = Convert.ToString(value);
                }
                catch (Exception)
                {
                    _description = "";
                }
            }
        }

        public int ParentCategoryID
        {
            get { return _parentCategoryID; }
            set
            {
                try
                {
                    _parentCategoryID = value;
                }
                catch (Exception)
                {
                    _parentCategoryID = 0;
                }
            }
        }

        public Object Created
        {
            get { return _created; }
            set
            {
                try
                {
                    _created = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _created = DateTime.MinValue;
                }
            }
        }

        public Object Modified
        {
            get { return _modified; }
            set
            {
                try
                {
                    _modified = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    _modified = DateTime.MinValue;
                }
            }
        }

        public Object IsActive
        {
            get { return _isActive; }
            set
            {
                try
                {
                    _isActive = Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    _isActive = false;
                }
            }
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

                CategoryID = id;
                Name = hsh["name"];
                Description = hsh["description"];
                ParentCategoryID = Convert.ToInt32(hsh["parentcategoryid"]);
                Created = hsh["created"];
                Modified = hsh["modified"];
                IsActive = hsh["isactive"];
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
                    cat.Created = c.Created;
                    cat.Modified = c.Modified;
                    cat.IsActive = c.IsActive;
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

    //Render wrapper classes are used to display table contents in a GridView with AutoGenerateColumns = "true"
    //(This is mandatory when using anonymous-typed properties (example: the "Object" class type)
    public class RenderCategory
    {
        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private int _parentCategoryID;

        public int ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }
        private DateTime _created;

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }
        private DateTime _modified;

        public DateTime Modified
        {
            get { return _modified; }
            set { _modified = value; }
        }
        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        public RenderCategory(Category c)
        {
            CategoryID = c.CategoryID;
            Name = Convert.ToString(c.Name);
            Description = Convert.ToString(c.Description);
            ParentCategoryID = Convert.ToInt32(c.ParentCategoryID);
            Created = Convert.ToDateTime(c.Created);
            Modified = Convert.ToDateTime(c.Modified);
            IsActive = Convert.ToBoolean(c.IsActive);
        }

    }


}
