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
    public partial class CourseAssign : Form
    {
        public CourseAssign()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAssign showAssign = new ShowAssign();
            showAssign.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FindAssign fa = new FindAssign();
            fa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddAssignment addas = new AddAssignment();
            addas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteAssign da = new DeleteAssign();
            da.Show();
        }
    }
}
