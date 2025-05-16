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
    public partial class Form4 : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public Form4()
        {
            InitializeComponent();
        }

        private void deleteStudent()
        {
            bool allEnter = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Must Enter a Student Id");
                allEnter = false;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must Enter a Student Name");
                allEnter = false;
            }
            if (allEnter)
            {
                MySqlConnection conn3 = new MySqlConnection(connection);
                string delete_query = "DELETE FROM students WHERE Std_id = @id and Std_name =@name";
                string check_query = "select Std_name from students where Std_id=@id";
                MySqlCommand cmd3 = new MySqlCommand(delete_query, conn3);
                MySqlCommand cmd4 = new MySqlCommand(check_query, conn3);
                cmd3.Parameters.AddWithValue("@id", textBox1.Text);
                cmd3.Parameters.AddWithValue("@name", textBox2.Text);
                cmd4.Parameters.AddWithValue("@id", textBox1.Text);
                conn3.Open();
                string name = cmd4.ExecuteScalar() as string;
                try
                {
                    if(name == textBox2.Text)
                    {
                        cmd3.ExecuteNonQuery();
                        MessageBox.Show("Student Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Student Information Not valid");
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Warning!!\n{e}");
                }
                finally
                {
                    conn3.Close();
                }
            }
            else if(allEnter == false)
            {
                MessageBox.Show("Cannot delete Student.Enter Valid Information");
            }
           
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("Warning!!!\nIf you delete a student, you cannot undo the process.");
                deleteStudent();
            }
            
        }
    }
}
