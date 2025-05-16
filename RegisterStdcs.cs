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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace database_pro2
{
    public partial class RegisterStdcs : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public RegisterStdcs()
        {
            InitializeComponent();
        }

        private void registerStd()
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            int semester;
            if (comboBox2.Text == "1")
            {
                semester = 1;
            }
            else if (comboBox2.Text == "2")
            {
                semester = 2;
            }
            else if (comboBox2.Text == "3")
            {
                semester = 3;
            }
            else if (comboBox2.Text == "4")
            {
                semester = 4;
            }
            else if (comboBox2.Text == "5")
            {
                semester = 5;
            }
            else if (comboBox2.Text == "6")
            {
                semester = 6;
            }
            else if (comboBox2.Text == "7")
            {
                semester = 7;
            }
            else if (comboBox2.Text == "8")
            {
                semester = 8;
            }
            else
            {
                semester = 0;
            }
            string query = "Insert into registration(std_id,course_id,Semester) values(@stid,@cid,@sem);";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@stid", textBox1.Text);
            cmd.Parameters.AddWithValue("@cid", textBox2.Text);
            cmd.Parameters.AddWithValue("@sem", semester);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration Successful");
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registerStd();
        }
    }
}
