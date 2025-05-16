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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            String option = comboBox1.Text;
            if (option == "Students")
            {
                Form2 f2 = new Form2();
                f2.Show();
            };
            if (option == "Instructors")
            {
                Instructor_Form inst_form = new Instructor_Form();
                inst_form.Show();
            };
            if (option == "Courses")
            {
                CoursesForm coursesForm = new CoursesForm();
                coursesForm.Show();
            };
            if (option == "Course Assignments")
            {
                CourseAssign cassign = new CourseAssign();
                cassign.Show();
            };
            if (option == "Registrations")
            {
                Registration r1 = new Registration();
                r1.Show();
            };
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }



}
