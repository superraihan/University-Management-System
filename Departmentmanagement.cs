using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Net;

namespace University_Management_System
{
    public partial class Departmentmanagement : Form
    {
        public Departmentmanagement()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");
            conn.Open();
            string query = "select * from Course";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        private void LoadData1()
        {
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");
            conn.Open();
            string query1 = "select * from Department";
            SqlDataAdapter sda1 = new SqlDataAdapter(query1, conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            dataGridView3.DataSource = dt1;
            conn.Close();
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Departmentmanagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet11.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter.Fill(this.university_Management_SystemDataSet11.Course);
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet2.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.university_Management_SystemDataSet2.Department);
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet1.Course' table. You can move, or remove it, as needed.
            this.courseTableAdapter1.Fill(this.university_Management_SystemDataSet1.Course);
            // TODO: This line of code loads data into the 'uMSDataSet2.Course' table. You can move, or remove it, as needed.
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");
            conn.Open();

            // Trim spaces from text inputs
            string departmentName = department.Text.Trim();
            string courseName = Course.Text.Trim();
            string facultyID = faculty.Text.Trim();

            // Validate Faculty ID
            if (string.IsNullOrWhiteSpace(facultyID))
            {
                MessageBox.Show("Please enter Faculty ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            // Check if Faculty ID exists in the Faculty table
            SqlCommand checkFacultyCmd = new SqlCommand("SELECT COUNT(*) FROM Faculty WHERE facultyID = @facultyID", conn);
            checkFacultyCmd.Parameters.AddWithValue("@facultyID", facultyID);
            int facultyCount = (int)checkFacultyCmd.ExecuteScalar();

            if (facultyCount == 0)
            {
                MessageBox.Show("Entered Faculty ID does not exist. Please enter a valid Faculty ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                return;
            }

            // If Course name is empty, insert only into Department table
            if (string.IsNullOrWhiteSpace(courseName))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Department (DepartmentName) VALUES (@DepartmentName)", conn);
                cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                
                cmd.ExecuteNonQuery();

                MessageBox.Show("Department inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData1();
            }
            else
            {
                // Check if the department exists before inserting the course
                SqlCommand checkDeptCmd = new SqlCommand("SELECT COUNT(*) FROM Department WHERE DepartmentName = @DepartmentName", conn);
                checkDeptCmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                int deptCount = (int)checkDeptCmd.ExecuteScalar();

                // If department does not exist, insert it first
                if (deptCount == 0)
                {
                    SqlCommand insertDeptCmd = new SqlCommand("INSERT INTO Department (DepartmentName) VALUES (@DepartmentName)", conn);
                    insertDeptCmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    
                    insertDeptCmd.ExecuteNonQuery();
                }

                // Insert into Course table with valid DepartmentName and FacultyID
                SqlCommand insertCourseCmd = new SqlCommand("INSERT INTO Course (CourseName, DepartmentName, facultyID) VALUES (@CourseName, @DepartmentName, @facultyID)", conn);
                insertCourseCmd.Parameters.AddWithValue("@CourseName", courseName);
                insertCourseCmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                insertCourseCmd.Parameters.AddWithValue("@facultyID", facultyID);
                insertCourseCmd.ExecuteNonQuery();

                MessageBox.Show("Course inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                LoadData1();
            }

            conn.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open();

                // Trim to remove extra spaces
                string courseName = Course.Text.Trim();
                string departmentName = department.Text.Trim(); // Assuming you have a textbox for department

                // If both fields are empty, prompt the user
                if (string.IsNullOrWhiteSpace(courseName) && string.IsNullOrWhiteSpace(departmentName))
                {
                    MessageBox.Show("Please select a course or department.");
                    return;
                }

                SqlCommand cmd;
                bool departmentExists = false;
                bool courseExists = false;

                // Check if department exists
                if (!string.IsNullOrWhiteSpace(departmentName))
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM Department WHERE DepartmentName = @DepartmentName", conn);
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    departmentExists = (int)cmd.ExecuteScalar() > 0;
                }

                // Check if course exists
                if (!string.IsNullOrWhiteSpace(courseName))
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM Course WHERE CourseName = @CourseName", conn);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    courseExists = (int)cmd.ExecuteScalar() > 0;
                }

                // If department does not exist and is being deleted, show error
                if (!string.IsNullOrWhiteSpace(departmentName) && !departmentExists)
                {
                    MessageBox.Show("Invalid department name.");
                    return;
                }

                // If course does not exist and is being deleted, show error
                if (!string.IsNullOrWhiteSpace(courseName) && !courseExists)
                {
                    MessageBox.Show("Invalid course name.");
                    return;
                }

                // If only the course name is provided, delete only the course
                if (!string.IsNullOrWhiteSpace(courseName) && string.IsNullOrWhiteSpace(departmentName))
                {
                    cmd = new SqlCommand("DELETE FROM Course WHERE CourseName = @CourseName", conn);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course deleted successfully.");
                }
                // If only the department name is provided, delete department and related courses
                else if (string.IsNullOrWhiteSpace(courseName) && !string.IsNullOrWhiteSpace(departmentName))
                {
                    cmd = new SqlCommand("DELETE FROM Course WHERE DepartmentName = @DepartmentName", conn);
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE FROM Department WHERE DepartmentName = @DepartmentName", conn);
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Department and related courses deleted successfully.");
                }
                // If both course and department are provided, delete only the course
                else
                {
                    cmd = new SqlCommand("DELETE FROM Course WHERE CourseName = @CourseName AND DepartmentName = @DepartmentName", conn);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Course deleted successfully.");
                }

                // Refresh Data
                LoadData();
                LoadData1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed properly
            }


        }

        

        private void course_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");
            conn.Open();

            // Trim spaces from text inputs
            string departmentName = department.Text.Trim();
            string courseName = Course.Text.Trim();
            string facultyID = faculty.Text.Trim();

            // Validate Faculty ID
            if (string.IsNullOrWhiteSpace(facultyID))
            {
                MessageBox.Show("Please enter Faculty ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            // Check if Faculty ID exists in the Faculty table
            SqlCommand checkFacultyCmd = new SqlCommand("SELECT COUNT(*) FROM Faculty WHERE facultyID = @facultyID", conn);
            checkFacultyCmd.Parameters.AddWithValue("@facultyID", facultyID);
            int facultyCount = (int)checkFacultyCmd.ExecuteScalar();

            if (facultyCount == 0)
            {
                MessageBox.Show("Entered Faculty ID does not exist. Please enter a valid Faculty ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                return;
            }

            // Ensure at least one field is provided for update
            if (string.IsNullOrWhiteSpace(departmentName) && string.IsNullOrWhiteSpace(courseName))
            {
                MessageBox.Show("Please enter at least one field (Department or Course) to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            // Update Department if DepartmentName is provided
            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                SqlCommand updateDeptCmd = new SqlCommand("UPDATE Department SET DepartmentName = @DepartmentName WHERE facultyID = @facultyID", conn);
                updateDeptCmd.Parameters.AddWithValue("@DepartmentName", departmentName);
                updateDeptCmd.Parameters.AddWithValue("@facultyID", facultyID);
                int rowsAffected = updateDeptCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Department updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching department found for the given Faculty ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            // Update Course if CourseName is provided
            if (!string.IsNullOrWhiteSpace(courseName))
            {
                SqlCommand updateCourseCmd = new SqlCommand("UPDATE Course SET CourseName = @CourseName WHERE facultyID = @facultyID", conn);
                updateCourseCmd.Parameters.AddWithValue("@CourseName", courseName);
                updateCourseCmd.Parameters.AddWithValue("@facultyID", facultyID);
                int rowsAffected = updateCourseCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Course updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching course found for the given Faculty ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            conn.Close();
            LoadData(); // Reload updated data
            LoadData1();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open();

                // SQL Query to fetch all records from Faculty, Department, and Course tables
                string query = "SELECT f.facultyID, f.Name AS FacultyName, f.Email, f.Phone, f.Gender, f.Salary, " +
                               "d.DepartmentName, c.CourseName " +
                               "FROM Faculty f " +
                               "LEFT JOIN Department d ON f.facultyID = d.facultyID " +
                               "LEFT JOIN Course c ON f.facultyID = c.facultyID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Bind data to DataGridView
                dataGridView1.DataSource = dt;

                // Show success message
                MessageBox.Show("Data loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure connection is closed
            }

        }

        private void search_Click(object sender, EventArgs e)
        {
            // Trim spaces and check if Department Name is empty
            if (string.IsNullOrWhiteSpace(searchbox.Text))
            {
                MessageBox.Show("Please enter a Department Name to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open();

                // Check if the department exists
                string checkQuery = "SELECT COUNT(*) FROM Department WHERE DepartmentName = @DepartmentName";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@DepartmentName", searchbox.Text.Trim());

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Entered Department Name does not exist. Please enter a valid Department Name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fetch records from Faculty, Department, and Course tables for the given Department
                string searchQuery = "SELECT * FROM Course WHERE DepartmentName = @DepartmentName";


                SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@DepartmentName", searchbox.Text.Trim());

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                string searchQuery1 = "SELECT * FROM Department WHERE DepartmentName = @DepartmentName";


                SqlDataAdapter adapter1 = new SqlDataAdapter(searchQuery, conn);
                adapter1.SelectCommand.Parameters.AddWithValue("@DepartmentName", searchbox.Text.Trim());

                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);

                // Bind data to DataGridView
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView3.DataSource = dt1;
                    MessageBox.Show("Search completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView3.DataSource = null;
                    MessageBox.Show("No records found for the given Department Name.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Close the connection
            }

        }
    }
    
}
