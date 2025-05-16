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
    public partial class CoursesForm : Form
    {
        public CoursesForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Course add_Course = new Add_Course();
            add_Course.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Show_Courses sc = new Show_Courses();
            sc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewCourseInfo vci = new ViewCourseInfo();
            vci.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteCourse dc = new deleteCourse();
            dc.Show();
        }
    }
}
