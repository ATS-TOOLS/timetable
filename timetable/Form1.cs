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
    public partial class Form1 : Form
    {
        string databasename;
        string type;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            databasename = f3.database;
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            databasename = f2.databasename;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           SqlConnection conn = new SqlConnection("server=AAKASH-PC\\SQLEXPRESS;Initial catalog="+databasename+"; integrated security=true");
            conn.Open();
            SqlCommand comd4 = new SqlCommand("insert into rooms(name, type) VALUES('"+this.textBox1.Text+"', '"+type+"') ", conn);
            comd4.ExecuteNonQuery();
            conn.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            type = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            type = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("server=AAKASH-PC\\SQLEXPRESS;Initial catalog=" + databasename + "; integrated security=true");
            conn.Open();
            SqlCommand cmdDataBase = new SqlCommand("select * from rooms ;", conn);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmdDataBase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dbdataset;
                dataGridView1.DataSource = bsource;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }

      

    }
}
