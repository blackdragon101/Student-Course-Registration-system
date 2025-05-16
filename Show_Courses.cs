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
    public partial class Show_Courses : Form
    {
        string connectionString = "server=localhost;user id=root;password=Myfirstdb101@fatima ;database= regis_system_database";
        public Show_Courses()
        {
            InitializeComponent();
            DisplayCombinedData();

        }

        private void DisplayCombinedData()
        {
            DataTable coursesTable = new DataTable();
            DataTable totalEnrolledTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Fetch courses
                    string coursesQuery = "SELECT Course_id, Course_name, Credit_hrs, Department FROM courses";
                    using (MySqlCommand cmd = new MySqlCommand(coursesQuery, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(coursesTable);
                    }

                    // Fetch total enrolled
                    string totalEnrolledQuery = @"
                        SELECT 
                            courses.Course_id,
                            courses.Course_name, 
                            courses.Department,
                            COUNT(registration.Std_id) AS Total_Students_Enrolled
                        FROM courses
                        LEFT JOIN registration ON registration.Course_id = courses.Course_id
                        GROUP BY courses.Course_id, courses.Course_name, courses.Department;";
                    using (MySqlCommand cmd = new MySqlCommand(totalEnrolledQuery, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(totalEnrolledTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data from the database: " + ex.Message);
                    return;
                }
            }

            // Normalize Course_name (to be safe)
            foreach (DataRow row in coursesTable.Rows)
                row["Course_name"] = row["Course_name"].ToString().Trim().ToLower();

            foreach (DataRow row in totalEnrolledTable.Rows)
                row["Course_name"] = row["Course_name"].ToString().Trim().ToLower();

            // Merge data
            var mergedData = from course in coursesTable.AsEnumerable()
                             join enrolled in totalEnrolledTable.AsEnumerable()
                             on course.Field<string>("Course_name") equals enrolled.Field<string>("Course_name") into joined
                             from enrolled in joined.DefaultIfEmpty()
                             select new
                             {
                                 Course_id = course.Field<int>("Course_id"),
                                 Course_name = course.Field<string>("Course_name"),
                                 Credit_hrs = course.Field<int>("Credit_hrs"),
                                 Department = course.Field<string>("Department"),
                                 Total_Students_Enrolled = enrolled == null || enrolled.IsNull("Total_Students_Enrolled")
                                     ? 0
                                     : Convert.ToInt64(enrolled["Total_Students_Enrolled"])
                             };

            // Create merged table
            DataTable mergedTable = new DataTable();
            mergedTable.Columns.Add("Course_id", typeof(int));
            mergedTable.Columns.Add("Course_name", typeof(string));
            mergedTable.Columns.Add("Credit_hrs", typeof(int));
            mergedTable.Columns.Add("Department", typeof(string));
            mergedTable.Columns.Add("Total_Students_Enrolled", typeof(long));

            foreach (var row in mergedData)
            {
                mergedTable.Rows.Add(row.Course_id, row.Course_name, row.Credit_hrs, row.Department, row.Total_Students_Enrolled);
            }

            // Bind to DataGridView
            dataGridView1.DataSource = mergedTable;
            dataGridView1.Refresh();
        }




        private void Show_Courses_Load(object sender, EventArgs e)
        {

        }
    }
}
