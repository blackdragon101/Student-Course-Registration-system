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
    public partial class DeleteAssign : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public DeleteAssign()
        {
            InitializeComponent();
        }

        private void delAssign()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must enter both Course ID and Assignment ID");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                string query = "DELETE FROM course_assignments WHERE Course_id = @course_id and Assignment_id = @assign_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@course_id", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@assign_id", textBox2.Text.Trim());
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Assignment deleted successfully");
                else
                    MessageBox.Show("No matching assignment found for deletion");
            }
        }

        private void DeleteAssign_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            delAssign();
        }
    }
}
