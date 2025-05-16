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
    public partial class Add_Course : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";

        public Add_Course()
        {
            InitializeComponent();
        }

        private void add_Course_func()
        {
            bool allEnter = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Must Enter a Course Name");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Must Enter a Course Credit Hours");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Must Enter a Course Department");
                allEnter = false;
            }
            if (allEnter) {
                MySqlConnection mySqlConnection = new MySqlConnection(connection);
                string query = "INSERT INTO courses (Course_name,Credit_hrs,Department) VALUES (@course_name, @credit, @depart)";
                MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
                cmd.Parameters.AddWithValue("@course_name", textBox1.Text);
                cmd.Parameters.AddWithValue("@credit", comboBox1.Text);
                cmd.Parameters.AddWithValue("@depart", comboBox2.Text);
                mySqlConnection.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course added successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    mySqlConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_Course_func();
        }
    }
}
