using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace database_pro2
{
    public partial class Form3 : Form
    {
        public int count = 0;
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public Form3()
        {
            InitializeComponent();
            loadStudents();
            label4.Text = count.ToString();
        }

        private void loadStudents()
        {
            string query = "SELECT * FROM students";
            string query2 = "SELECT COUNT(*) FROM students";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlCommand cmd2 = new MySqlCommand(query2, conn);
            conn.Open();
            count = Convert.ToInt32(cmd2.ExecuteScalar());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
      
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // This label is used to display the count of students
        }
    }
}
