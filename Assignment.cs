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

namespace University_Management_System
{
    public partial class Assignment : Form
    {
        private string connectionString = @"Data Source=RAIHAN-19\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True";

        public Assignment()
        {
            InitializeComponent();
            
        }

        private void Assignment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet5.Assignments' table. You can move, or remove it, as needed.
            this.assignmentsTableAdapter.Fill(this.university_Management_SystemDataSet5.Assignments);

        }
        private void LoadAssignments()
        {
            string query = "SELECT * FROM Assignments";
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvAssignments.DataSource = dt;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading assignments: " + ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            TeacherDashboard dashboard = new TeacherDashboard();
            dashboard.Show();

            // Close the current form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text) || string.IsNullOrWhiteSpace(txtAssignmentTitle.Text))
            {
                MessageBox.Show("Course Name and Assignment Title are required.");
                return;
            }

            string courseName = txtCourseName.Text.Trim();
            string assignmentTitle = txtAssignmentTitle.Text.Trim();
            DateTime submissionDeadline = dtpSubmissionDeadline.Value;

            string query = @"INSERT INTO Assignments (course_name, assignment_title, submission_deadline) 
                 VALUES (@course_name, @assignment_title, @submission_deadline)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@course_name", courseName);
                    command.Parameters.AddWithValue("@assignment_title", assignmentTitle);
                    command.Parameters.AddWithValue("@submission_deadline", submissionDeadline);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Assignment added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting assignment: " + ex.Message);
            }

        }
    
        

        private void txtCourseName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAssignmentID.Text, out int assignmentId))
            {
                MessageBox.Show("Valid Assignment ID is required.");
                return;
            }

            string courseName = txtCourseName.Text.Trim();
            string assignmentTitle = txtAssignmentTitle.Text.Trim();
            DateTime submissionDeadline = dtpSubmissionDeadline.Value;

            string query = "UPDATE Assignments SET course_name = @CourseName, assignment_title = @AssignmentTitle, submission_deadline = @SubmissionDeadline WHERE id = @AssignmentID";

            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(connectionString);
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseName", courseName);
                command.Parameters.AddWithValue("@AssignmentTitle", assignmentTitle);
                command.Parameters.AddWithValue("@SubmissionDeadline", submissionDeadline);
                command.Parameters.AddWithValue("@AssignmentID", assignmentId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Assignment updated successfully.");
                else
                    MessageBox.Show("No assignment found with this ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating assignment: " + ex.Message);
            }
            finally
            {
                if (command != null)
                    command.Dispose();

                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    connection.Dispose();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAssignmentID.Text, out int assignmentId))
            {
                MessageBox.Show("Valid Assignment ID is required for deletion.");
                return;
            }

            string query = "DELETE FROM Assignments WHERE id = @AssignmentID";

            SqlConnection connection = null;
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(connectionString);
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AssignmentID", assignmentId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Assignment deleted successfully.");
                else
                    MessageBox.Show("No assignment found with this ID.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting assignment: " + ex.Message);
            }
            finally
            {
                if (command != null)
                    command.Dispose();

                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();

                    connection.Dispose();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadAssignments();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
