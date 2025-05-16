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
    public partial class AddAssignment : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public AddAssignment()
        {
            InitializeComponent();
        }

        private void addAssignment()
        {
            int semester;
            MySqlConnection conn = new MySqlConnection(connection);
            string query = "INSERT INTO course_assignments (Course_id,Instructor_id,Semester) VALUES (@c_id, @inst_id, @semester)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            if (comboBox1.Text == "1")
            {
                semester = 1;
            }
            else if (comboBox1.Text == "2")
            {
                semester = 2;
            }
            else if (comboBox1.Text == "3")
            {
                semester = 3;
            }
            else if (comboBox1.Text == "4")
            {
                semester = 4;
            }
            else if (comboBox1.Text == "5")
            {
                semester = 5;
            }
            else if (comboBox1.Text == "6")
            {
                semester = 6;
            }
            else if (comboBox1.Text == "7")
            {
                semester = 7;
            }
            else if (comboBox1.Text == "8")
            {
                semester = 8;
            }
            else
            {
                semester = 0;
            }
            cmd.Parameters.AddWithValue("@c_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@inst_id", textBox2.Text);
            cmd.Parameters.AddWithValue("@semester", semester);
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Assignment added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            addAssignment();
        }
    }
}


