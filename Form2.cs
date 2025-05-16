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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Dock = DockStyle.Fill; // Ensures it fills the panel
            panel2.Controls.Add(axWindowsMediaPlayer1); // Add it to the panel if not already added
            axWindowsMediaPlayer1.URL = "C:\\Users\\ATIF TRADERS\\Downloads\\Black and Yellow Handwritten Doodles Education and Youth Development Mobile Video.mp4";
            axWindowsMediaPlayer1.uiMode = "none"; // Hides the controls
            axWindowsMediaPlayer1.settings.setMode("loop", true); // Enable looping
            axWindowsMediaPlayer1.Ctlcontrols.play(); // Start playing the video

            
        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();
            ff.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addStudent addStudent = new addStudent();
            addStudent.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 deleteStd = new Form4();
            deleteStd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateStd updateStd = new updateStd();
            updateStd.ShowDialog();
        }
    }
}
