using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace University_Management_System
{
    public partial class StudentReport : Form
    {
        public StudentReport()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True
";


        private void button1_Click(object sender, EventArgs e)
        {
            TeacherDashboard dashboard = new TeacherDashboard();
            dashboard.Show();

            
            this.Hide(); ;
        }

        private void StudentReport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string StudentName = textBox3.Text.Trim();
            string CourseName = maskedTextBox1.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(maskedTextBox2.Text))
            {
                MessageBox.Show("Please enter the data.");
                return;
            }

            int AssignmentMarks;

           
            bool isAssignmentValid = int.TryParse(textBox1.Text.Trim(), out AssignmentMarks);
            

            
            if (!isAssignmentValid )
            {
                MessageBox.Show("Please enter valid numerical values for marks.");
                return;
            }
            string ExamGrades = maskedTextBox2.Text.Trim();  // Store as string

            if (string.IsNullOrWhiteSpace(ExamGrades))
            {
                MessageBox.Show("Please enter a valid exam grade.");
                return;
            }

            
            


            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                conn.Open();
                string query = "INSERT INTO student_marks (StudentName, CourseName, AssignmentMarks, ExamGrades) VALUES (@name, @course, @assign, @exam)";

                cmd.Connection = conn;
                cmd.CommandText = query;

                
                cmd.Parameters.AddWithValue("@name", StudentName);
                cmd.Parameters.AddWithValue("@course", CourseName);
                cmd.Parameters.AddWithValue("@assign", AssignmentMarks);
                cmd.Parameters.AddWithValue("@exam", ExamGrades);

                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Marks uploaded successfully!");
                }
                else
                {
                    MessageBox.Show("Error uploading marks.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string searchName = textBox3.Text.Trim(); // Student Name
            string searchCourse = maskedTextBox1.Text.Trim(); // Course Name

            // Ensure both fields are not empty before proceeding with the search
            if (string.IsNullOrWhiteSpace(searchName) && string.IsNullOrWhiteSpace(searchCourse))
            {
                MessageBox.Show("Please enter a student name or course name to search.");
                return;
            }

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dt = new DataTable();

            try
            {
                conn.Open();

                // Build the query to search based on both StudentName and CourseName
                string query = "SELECT * FROM student_marks WHERE StudentName LIKE @name AND CourseName LIKE @course";
                cmd = new SqlCommand(query, conn);

                // Add parameters for both StudentName and CourseName search
                cmd.Parameters.AddWithValue("@name", "%" + searchName + "%");
                cmd.Parameters.AddWithValue("@course", "%" + searchCourse + "%");

                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);

                // Check if any data was found and display in the DataGridView
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No matching records found.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                cmd.Dispose();
                adapter.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
