using MySql.Data.MySqlClient;
using System;
using System.CodeDom;
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
    public partial class updateStd : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public updateStd()
        {
            InitializeComponent();
        }

        private void UpdateStudent()
        {
            bool allFull = true;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Must Enter a Student Id");
                allFull = false;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Must Enter a Student Name");
                allFull = false;
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Must Enter a Student Name");
                allFull = false;
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Must Enter a Student Email");
                allFull = false;
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Must Enter a Student Semester");
                allFull = false;
            }
            else if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("Must Enter a Student Department");
                allFull = false;
            }
            if(allFull)
            {
                MySqlConnection conn4 = new MySqlConnection(connection);
                string update_query = "UPDATE students SET Std_name=@name, Email=@email, Department=@depart, Semester=@sem WHERE Std_id=@id and Std_name =@prevname";
                MySqlCommand cmd5 = new MySqlCommand(update_query, conn4);
                conn4.Open();
                string check_student = "Select Std_name from students where Std_id=@id";
                MySqlCommand cmd6 = new MySqlCommand(check_student, conn4);
                cmd6.Parameters.AddWithValue("@id", textBox1.Text);
                string name = cmd6.ExecuteScalar() as string;
                if (name == textBox2.Text)
                {
                    int semester;
                    if (comboBox1.Text == "1st")
                    {
                        semester = 1;
                    }
                    else if (comboBox1.Text == "2nd")
                    {
                        semester = 2;
                    }
                    else if (comboBox1.Text == "3rd")
                    {
                        semester = 3;
                    }
                    else if (comboBox1.Text == "4th")
                    {
                        semester = 4;
                    }
                    else if (comboBox1.Text == "5th")
                    {
                        semester = 5;
                    }
                    else if (comboBox1.Text == "6th")
                    {
                        semester = 6;
                    }
                    else if (comboBox1.Text == "7th")
                    {
                        semester = 7;
                    }
                    else if (comboBox1.Text == "8th")
                    {
                        semester = 8;
                    }
                    else
                    {
                        semester = 0;
                    }
                    cmd5.Parameters.AddWithValue("@id", textBox1.Text);
                    cmd5.Parameters.AddWithValue("@prevname", textBox2.Text);
                    cmd5.Parameters.AddWithValue("@name", textBox3.Text);
                    cmd5.Parameters.AddWithValue("@email", textBox4.Text);
                    cmd5.Parameters.AddWithValue("@depart", comboBox2.Text);
                    cmd5.Parameters.AddWithValue("@sem", semester);
                    try
                    {
                        cmd5.ExecuteNonQuery();
                        MessageBox.Show("Student Updated Successfully");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Warning!!\n{e}");
                    }
                    finally
                    {
                        conn4.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Student Information Not valid");
                }
            }
            else
            {
                MessageBox.Show("Please Enter All Information.Cannot leave any field empty!!");
            }


        }

        private void updateStd_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateStudent();
        }
    }
}
