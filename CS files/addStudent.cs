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
    public partial class addStudent : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public addStudent()
        {
            InitializeComponent();
            
        }

        private void addStudentdb()
        {
            MySqlConnection conn2 = new MySqlConnection(connection);
            int semester;
            if (comboBox2.Text == "1st")
            {
                semester = 1;
            }
            else if (comboBox2.Text == "2nd")
            {
                semester = 2;
            }
            else if (comboBox2.Text == "3rd")
            {
                semester = 3;
            }
            else if (comboBox2.Text == "4th")
            {
                semester = 4;
            }
            else if (comboBox2.Text == "5th")
            {
                semester = 5;
            }
            else if (comboBox2.Text == "6th")
            {
                semester = 6;
            }
            else if (comboBox2.Text == "7th")
            {
                semester = 7;
            }
            else if (comboBox2.Text == "8th")
            {
                semester = 8;
            }
            else
            {
                semester = 0;
            }
            bool isValid = true;
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Please Select Semester");
                isValid = false;
            }
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please Enter Student Name");
                isValid = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please Enter Student Email");
                isValid = false;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please Select Department");
                isValid = false;
            }

            if (isValid)
            {
                string add_query = $"INSERT INTO students (Std_name,Email,Department,Semester) VAlUES (@name,@email,@depart,@sem)";
                MySqlCommand cmd = new MySqlCommand(add_query, conn2);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@depart", comboBox1.Text);
                cmd.Parameters.AddWithValue("@sem", semester);

                conn2.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Added Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn2.Close();
                }
            }
            else if (!isValid)
            {
                MessageBox.Show("Cannot Add Student");
            }
            
        }

        private void addStudent_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addStudentdb();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
