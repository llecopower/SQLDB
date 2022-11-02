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
using System.Data;

namespace SQLDB
{
    public partial class Form1 : Form
    {

        //connection string
         


        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP_ALEX;Initial Catalog=sqldb;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            disp_data();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void disp_data()
        { 
        
            //Open DataBase
            conn.Open();

            //
            SqlCommand cmd = conn.CreateCommand();

            //Says that will be the type of the commands(Always use text to avoid convertions)
            cmd.CommandType = CommandType.Text;

            //Type the SQL Query itself
            cmd.CommandText = "SELECT * FROM table_db";

            //This trigger the Query
            cmd.ExecuteNonQuery();


            //I need to add the Attributes from the SERVER DB to MY PC MEMORY
            DataTable dt = new DataTable();

            //format the data attribute to C#  Understands
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // ALL THE MAGIC HAPPENS HERE!!!. The function will put
            //all the infor from the Computer memory that was in OUR SQL Server to C#
            //to be visible at the Front end

            da.Fill(dt);

            //DataGrid View component that will Load itseld the data ALREADY transformed from SQL to C#

            dataGridViewDB.DataSource = dt;

            conn.Close();
        
        
        }
        
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO table_db VALUES('" + textBoxName.Text + "'," + "'" + textBoxCity.Text + "', '" + textBoxCountry.Text + "')";
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Record Saved Successfully into the DB");
            disp_data();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM table_db WHERE name = '"+textBoxName.Text+"'";
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Record Deleted Successfully into the DB");
            disp_data();
        }

        private void dataGridViewDB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
