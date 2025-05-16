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
    public partial class Registration : Form
    {
        string connection = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterStdcs registerStdcs = new RegisterStdcs();
            registerStdcs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UnregStd unregStd = new UnregStd();
            unregStd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            assignGrade assignGrade = new assignGrade();
            assignGrade.Show();
        }
    }
}
