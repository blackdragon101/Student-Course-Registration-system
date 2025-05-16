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
    public partial class add_Instructor : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";

        public add_Instructor()
        {
            InitializeComponent();
        }

        private void add_instructor()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter instructor name");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter instructor email");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Please select a department");
                isValid = false;
            }
            if (isValid)
            {
                MySqlConnection conn2 = new MySqlConnection(connection);
                string add_query = "INSERT INTO instructors (Instructor_name, Email, Department) VALUES (@instructor_name, @instructor_email, @depart)";
                MySqlCommand cmd = new MySqlCommand(add_query, conn2);
                cmd.Parameters.AddWithValue("@instructor_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@instructor_email", textBox2.Text);
                cmd.Parameters.AddWithValue("@depart", comboBox1.Text);
                conn2.Open();
                cmd.ExecuteNonQuery();
                conn2.Close();
                MessageBox.Show("Instructor added successfully");
            }
            else
            {
                MessageBox.Show("Please fill in all fields...Cannot add instructor.");

            }
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_instructor();
        }
    }
}
