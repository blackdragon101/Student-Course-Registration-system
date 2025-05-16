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
    public partial class Instructor_Form : Form
    {
        public Instructor_Form()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delete_instructor deleteins1 = new delete_instructor();
            deleteins1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_Instructors view_Instructors = new View_Instructors();
            view_Instructors.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_Instructor addins1 = new add_Instructor();
            addins1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            update_instructor inst1 = new update_instructor();
            inst1.ShowDialog();
        }
    }
}
