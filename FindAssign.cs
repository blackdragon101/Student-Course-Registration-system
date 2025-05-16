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
    public partial class FindAssign : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public FindAssign()
        {
            InitializeComponent();
        }

        private void find_Assign()
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
                MySqlConnection conn = new MySqlConnection(connection);
                string query = "select courses.Course_id,courses.Course_name,instructors.Instructor_name,course_assignments.Semester from course_assignments\r\njoin instructors\r\non course_assignments.Instructor_id = instructors.Instructor_id\r\njoin courses\r\non courses.Course_id = course_assignments.Course_id\r\nwhere course_assignments.Course_id=@courseId and courses.Course_name = @course_name;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@courseId", textBox1.Text);
                cmd.Parameters.AddWithValue("@course_name", textBox2.Text);
                conn.Open();
                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].HeaderText = "Course ID";
                    dataGridView1.Columns[1].HeaderText = "Course Name";
                    dataGridView1.Columns[2].HeaderText = "Instructor Name";
                    dataGridView1.Columns[3].HeaderText = "Semester";
                 
                    conn.Close();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the fields.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            find_Assign();
        }
    }
}
