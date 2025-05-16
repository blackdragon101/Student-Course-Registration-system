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
    public partial class ViewCourseInfo : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public ViewCourseInfo()
        {
            InitializeComponent();
        }

        private void Show_Course_information()
        {
            bool allEnter = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Must Enter a Course ID");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must Enter a Course Name");
                allEnter = false;
            }
            if (allEnter)
            {
                try
                {
                    MySqlConnection conn1 = new MySqlConnection(connection);
                    string query = "SELECT courses.Course_name,students.Std_id,students.Std_name FROM courses JOIN registration ON registration.Course_id = courses.Course_id JOIN students ON registration.Std_id = students.Std_id  where Course_name = @name and courses.Course_id =@id ORDER BY courses.Course_name, students.Std_name;";
                    string check_Query = "SELECT Course_name FROM courses WHERE Course_id = @id";
                    MySqlCommand cmd2 = new MySqlCommand(check_Query, conn1);
                    MySqlCommand cmd = new MySqlCommand(query, conn1);
                    conn1.Open();
                    cmd2.Parameters.AddWithValue("@id", textBox1.Text);
                    string name = cmd2.ExecuteScalar() as string;
                    if (name == textBox2.Text)
                    {
                        cmd.Parameters.AddWithValue("@name", textBox2.Text);
                        cmd.Parameters.AddWithValue("@id", textBox1.Text);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns[0].HeaderText = "Course Name";
                        dataGridView1.Columns[1].HeaderText = "Student ID";
                        dataGridView1.Columns[2].HeaderText = "Student Name";
                        conn1.Close();
                    }
                    else
                    {
                        MessageBox.Show("InValid Information");
                        return;
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show_Course_information();
        }
    }
}
