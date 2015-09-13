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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
         public string database { get { return textBox1.Text; } }


         private void button1_Click(object sender, EventArgs e)
         {
             if (checkIfExists(textBox1.Text))
             {
                 MessageBox.Show("database Found..");
                 this.Close();
             }
             else
             {
                 label2.Text = "Error Database Not Found";
             }
           
         }

         private bool checkIfExists(string dbname)
         {
             try
             {
                 SqlConnection conn = new SqlConnection("server=AAKASH-PC\\SQLEXPRESS;Initial catalog=" + dbname + "; integrated security=true");
                 conn.Open();
                 conn.Close();
             }
             catch (Exception ex)
             {
                 return false;
             }
             return true;
         }
    }
}
