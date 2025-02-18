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
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
        }
        private string connectionString = @"Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True";
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Courses_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet7.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.university_Management_SystemDataSet7.Class);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TeacherDashboard dashboard = new TeacherDashboard();
            dashboard.Show();

            // Close the current form
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(day.Text) || string.IsNullOrWhiteSpace(facultyID.Text))
            {
                MessageBox.Show("Please enter both Day and Faculty ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open();

                // Check if the Day exists in the Class table
                string checkDayQuery = "SELECT COUNT(*) FROM Class WHERE [Day] = @Day";
                SqlCommand checkDayCmd = new SqlCommand(checkDayQuery, conn);
                checkDayCmd.Parameters.AddWithValue("@Day", day.Text);
                int countDay = (int)checkDayCmd.ExecuteScalar();

                if (countDay == 0)
                {
                    MessageBox.Show("Entered Day does not exist. Please enter a valid Day.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the Faculty ID exists in the Class table
                string checkFacultyQuery = "SELECT COUNT(*) FROM Class WHERE facultyID = @facultyID";
                SqlCommand checkFacultyCmd = new SqlCommand(checkFacultyQuery, conn);
                checkFacultyCmd.Parameters.AddWithValue("@facultyID", facultyID.Text);
                int countFaculty = (int)checkFacultyCmd.ExecuteScalar();

                if (countFaculty == 0)
                {
                    MessageBox.Show("Entered Faculty ID does not exist. Please enter a valid Faculty ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Fetch data only if both Day and Faculty ID are valid
                string searchQuery = "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM], facultyID FROM Class WHERE [Day] = @Day AND facultyID = @facultyID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(searchQuery, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Day", day.Text);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@facultyID", facultyID.Text);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt; // Show data if found
                    MessageBox.Show("Search completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView1.DataSource = null; // Keep DataGridView empty if no data found
                    MessageBox.Show("No records found for the given Day and Faculty ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
