using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace timetable
{
    public partial class Form2 : Form
    {
        public string databasename { get { return textBox1.Text; } }

        public Form2()
        {
            InitializeComponent();
        }

        private bool checkdb(string dbname)
        {
         try
         {
            SqlConnection conn = new SqlConnection("server=AAKASH-PC\\SQLEXPRESS;Initial catalog="+dbname+"; integrated security=true");
            conn.Open();
            conn.Close();
         }
         catch(Exception ex)
         {
             return false; 
         }
         return true;
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkdb(textBox1.Text) == true)
            {
                label2.Text = "database exists";
            }
            else
            {
                SqlConnection conn = new SqlConnection("server=AAKASH-PC\\SQLEXPRESS;database=master; integrated security=SSPI");
                conn.Open();
                SqlCommand comd1 = new SqlCommand("create database " + textBox1.Text, conn);
                comd1.ExecuteNonQuery();
                SqlCommand comd2 = new SqlCommand("use " + textBox1.Text, conn);
                comd2.ExecuteNonQuery();
                SqlCommand comd3 = new SqlCommand("create table rooms (id int IDENTITY(1,1) PRIMARY KEY,name varchar(255), type tinyint) ",conn);
                comd3.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("database created..");
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

      
    }
}
