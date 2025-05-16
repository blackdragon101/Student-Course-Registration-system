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
    public partial class deleteCourse : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public deleteCourse()
        {
            InitializeComponent();
        }

        private void delCourse()
        {
            bool allEnter = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Must Enter a Course Name");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must Enter a Course ID");
                allEnter = false;
            }
            if (allEnter) {
                MySqlConnection conn = new MySqlConnection(connection);
                string check_Query = "Select Course_name from Courses where Course_id=@id";
                string query = "DELETE FROM courses WHERE Course_name = @course_name and Course_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlCommand check_cmd = new MySqlCommand(check_Query, conn);
                check_cmd.Parameters.AddWithValue("@id", textBox2.Text);

                conn.Open();
                string name = check_cmd.ExecuteScalar() as string;
                if(name == textBox1.Text)
                {
                    cmd.Parameters.AddWithValue("@course_name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@id", textBox2.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Course deleted successfully");
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
                else if(name != textBox1.Text)
                {
                    MessageBox.Show("Invalid Information....cannot delete Course!!");
                }
                
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            delCourse();
        }
    }
}
