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
    public partial class ShowAssign : Form
    {
        string conn = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";

        public ShowAssign()
        {
            InitializeComponent();
        }

        private void ShowAssignments()
        {
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            string query = "select courses.Course_id,courses.Course_name,instructors.Instructor_name,course_assignments.Semester from course_assignments\r\njoin instructors\r\non course_assignments.Instructor_id = instructors.Instructor_id\r\njoin courses\r\non courses.Course_id = course_assignments.Course_id";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Course ID";
            dataGridView1.Columns[1].HeaderText = "Course Name";
            dataGridView1.Columns[2].HeaderText = "Instructor Name";
            dataGridView1.Columns[3].HeaderText = "Semester";
            connection.Close();
        }

        private void ShowAssign_Load(object sender, EventArgs e)
        {
            ShowAssignments();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
