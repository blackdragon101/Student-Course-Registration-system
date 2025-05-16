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
    public partial class delete_instructor : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public delete_instructor()
        {
            InitializeComponent();
        }

        private void deleteInstructor()
        {
            bool allEnter = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Must Enter an Instructor Id");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must Enter an Instructor Name");
                allEnter = false;
            }
            if (allEnter)
            {
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();
                string remove_assignment = "Delete from course_assignments where Instructor_id=@id";
                MySqlCommand remove_assign = new MySqlCommand(remove_assignment, conn);
                remove_assign.Parameters.AddWithValue("@id", textBox2.Text);
                remove_assign.ExecuteNonQuery();
                MessageBox.Show("Instructor Assignments are getting deleted...Please wait a while!");
                string delete_query = "DELETE FROM instructors WHERE Instructor_id = @id AND Instructor_name = @name";
                string check_query = "SELECT Instructor_name FROM instructors WHERE Instructor_id = @id";
                MySqlCommand deleteCmd = new MySqlCommand(delete_query, conn);
                MySqlCommand checkCmd = new MySqlCommand(check_query, conn);
                deleteCmd.Parameters.AddWithValue("@id", textBox2.Text);
                deleteCmd.Parameters.AddWithValue("@name", textBox1.Text);
                checkCmd.Parameters.AddWithValue("@id", textBox2.Text);
                
                
                try
                {
                    string name = checkCmd.ExecuteScalar() as string;
                    if (name == textBox1.Text)
                    {
                        deleteCmd.ExecuteNonQuery();
                        MessageBox.Show("Instructor Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Instructor Information Not Valid");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Warning!!\n{e.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (!allEnter)
            {
                MessageBox.Show("Cannot delete Instructor. Enter Valid Information");
            }
        }

        private void delete_instructor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                deleteInstructor();
            }
            else
            {
                MessageBox.Show("Please check the confirmation box to delete the instructor.");
            }
            
        }
    }
}
