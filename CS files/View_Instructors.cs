using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace database_pro2
{
    public partial class View_Instructors : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        string count;
        public View_Instructors()
        {
            InitializeComponent();
            load_instructors();
            label3.Text = count;
        }


        private void load_instructors()
        {
            MySqlConnection conn1 = new MySqlConnection(connection);
            string query = "SELECT * FROM instructors";
            string count_query = "SELECT COUNT(*) FROM instructors";
            MySqlCommand cmd = new MySqlCommand(query, conn1);
            MySqlCommand cmd2 = new MySqlCommand(count_query, conn1);
            conn1.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            count = cmd2.ExecuteScalar().ToString();
            conn1.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
