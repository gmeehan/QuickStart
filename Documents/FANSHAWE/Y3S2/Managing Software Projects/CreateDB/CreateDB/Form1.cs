using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace CreateDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class MyDVDs : DataContext
        {
            public Table<DVD> DVDs;
            public MyDVDs(string connection) : base(connection) { }
        }

        [Table(Name = "DVDTable")]
        public class DVD
        {
            [Column(IsPrimaryKey = true)]
            public string Title;
            [Column]
            public string Rating;
        }

        public void CreateDatabase(string location)
        {
            MyDVDs db = new MyDVDs(location);
            if (db.DatabaseExists())
            {
                if (MessageBox.Show("Database already exists. Recreate?", "Recreate Database?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.DeleteDatabase();
                    db.CreateDatabase();
                    MessageBox.Show("Database Created!");
                }
                else
                {
                    MessageBox.Show("Database Not Created");
                }
            }
            else
            {
                db.CreateDatabase();
                MessageBox.Show("Database Created!");
            }
        }

        public string ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog1.SelectedPath;
            }
            return "";
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            string location = ChooseFolder().Trim();
            if (location != "")
            {
                if (location[location.Length - 1] == '\\')
                {
                    location += "test2.mdf";
                }
                else
                {
                    location += "\\test2.mdf";
                }
                try
                {
                    CreateDatabase(location);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter the location you would like your database created");
            }
        }
    }
}
