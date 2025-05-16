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

    public partial class assignGrade : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public assignGrade()
        {
            InitializeComponent();
        }

        private void SetGrade()
        {
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();
            string query = "UPDATE registration\r\nSET Grade = @grd\r\nWHERE Std_id = @stid and Course_id=@cid;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@stid", textBox1.Text);
            cmd.Parameters.AddWithValue("@cid", textBox2.Text);
            cmd.Parameters.AddWithValue("@grd", comboBox2.Text);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Grade Successfully Assigned.");
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
        private void button1_Click(object sender, EventArgs e)
        {
            SetGrade();
        }
    }
}
