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
    public partial class update_instructor : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";

        private void updateInstructor()
        {
            bool allEnter = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Must Enter a Instructor Name");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must Enter a Instructor Id");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Must Enter a Instructor Email");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Must Enter a Instructor Department");
                allEnter = false;
            }
            if (allEnter)
            {
                MySqlConnection conn2 = new MySqlConnection(connection);
                string check_query = "Select Instructor_name from instructors where Instructor_id = @id";
                string update_query = "UPDATE instructors SET Instructor_name = @instructor_name, Email = @instructor_email, Department = @depart WHERE Instructor_id = @id";
                MySqlCommand cmd = new MySqlCommand(update_query, conn2);
                MySqlCommand cmd2 = new MySqlCommand(check_query, conn2);
                cmd.Parameters.AddWithValue("@instructor_name", textBox4.Text);
                cmd.Parameters.AddWithValue("@instructor_email", textBox3.Text);
                cmd.Parameters.AddWithValue("@depart", comboBox1.Text);
                cmd.Parameters.AddWithValue("@id", textBox2.Text);
                cmd2.Parameters.AddWithValue("@id", textBox2.Text);
                conn2.Open();
                string name = cmd2.ExecuteScalar() as string;
                if (name == textBox1.Text)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Instructor updated successfully");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error: " + e.Message);
                    }
                    finally
                    {
                        conn2.Close();
                    }
                }
                else if (name != textBox1.Text)
                {
                    MessageBox.Show("Instructor Information Not Valid");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields...Cannot update instructor.");
            }   
        }

        public update_instructor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateInstructor();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
