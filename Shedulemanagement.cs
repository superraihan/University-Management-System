using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Data.SqlClient;

namespace University_Management_System
{
    public partial class schedulemanagement : Form
    {
        public schedulemanagement()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // SQL query to fetch the data from the Exam table
            string query = "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM] FROM Exam";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            try
            {
                conn.Open(); // Open connection

                // Fill DataTable with query results
                dataAdapter.Fill(dt);

                // Check if data is available
                if (dt.Rows.Count > 0)
                {
                    // Assuming you have a DataGridView named dataGridView1 to display the data
                    dataGridView1.DataSource = dt; // Bind the data to DataGridView
                }
                else
                {
                    MessageBox.Show("No data available to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Show any error that occurs during data fetching
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void LoadData1()
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // SQL query to fetch the data from the Class table including FacultyID
            string query = "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM], [facultyID] FROM Class";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            try
            {
                conn.Open(); // Open connection

                // Fill DataTable with query results
                dataAdapter.Fill(dt);

                // Check if data is available
                if (dt.Rows.Count > 0)
                {
                    // Assuming you have a DataGridView named dataGridView2 to display the data
                    dataGridView2.DataSource = dt; // Bind the data to DataGridView
                }
                else
                {
                    MessageBox.Show("No data available to display.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Show any error that occurs during data fetching
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void schedulemanagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet6.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter1.Fill(this.university_Management_SystemDataSet6.Class);
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet4.Class' table. You can move, or remove it, as needed.
            this.classTableAdapter.Fill(this.university_Management_SystemDataSet4.Class);
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet3.Exam' table. You can move, or remove it, as needed.
            this.examTableAdapter.Fill(this.university_Management_SystemDataSet3.Exam);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the day text box is empty
            if (string.IsNullOrWhiteSpace(day.Text))
            {
                MessageBox.Show("You must add a day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if 1stXM, 2ndXM, 3rdXM are the same
            if (firstxm.Text == secondxm.Text || secondxm.Text == thirdxm.Text || firstxm.Text == thirdxm.Text)
            {
                MessageBox.Show("Same course name cannot be added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // Check if the Day already exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Exam WHERE [Day] = @Day";  // Count rows with the same Day

            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@Day", day.Text); // Use the Day value entered by the user

            try
            {
                conn.Open();

                // Execute the query to check if the Day already exists
                int count = (int)checkCmd.ExecuteScalar(); // Count how many rows match

                if (count > 0)
                {
                    // If the Day exists, show an error message
                    MessageBox.Show("This day already exists, please insert a different day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If no duplicate, proceed with inserting the data
                string query = "INSERT INTO Exam ([Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM]) " +
                               "VALUES (@Day, @AMto10AM, @AMto12PM, @PMto4PM)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Day", day.Text);
                cmd.Parameters.AddWithValue("@AMto10AM", firstxm.Text);
                cmd.Parameters.AddWithValue("@AMto12PM", secondxm.Text);
                cmd.Parameters.AddWithValue("@PMto4PM", thirdxm.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Shedule added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData(); // Reload the data after adding
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure connection is closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            string query;

            // If the day field is empty, show all data
            if (string.IsNullOrWhiteSpace(day.Text))
            {
                query = "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM] FROM Exam";
            }
            else
            {
                query = "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM] FROM Exam WHERE [Day] = @Day";
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            if (!string.IsNullOrWhiteSpace(day.Text))
            {
                // Add parameter only if filtering by Day
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Day", day.Text);
            }

            try
            {
                conn.Open();
                dataAdapter.Fill(dt);

                // Assuming you have a DataGridView named dataGridView1
                dataGridView1.DataSource = dt;


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

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(classday.Text))
            {
                MessageBox.Show("You must add a day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if 1stXM, 2ndXM, 3rdXM are the same
            if (firstclass.Text == secondclass.Text || secondclass.Text == thirdclass.Text || thirdclass.Text == firstclass.Text)
            {
                MessageBox.Show("Same course name cannot be added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if Faculty ID is entered
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Please enter Faculty ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open();

                // Check if the Faculty ID exists
                string facultyCheckQuery = "SELECT COUNT(*) FROM Faculty WHERE facultyID = @facultyID";
                SqlCommand facultyCheckCmd = new SqlCommand(facultyCheckQuery, conn);
                facultyCheckCmd.Parameters.AddWithValue("@facultyID", id.Text);
                int facultyExists = (int)facultyCheckCmd.ExecuteScalar();

                if (facultyExists == 0)
                {
                    MessageBox.Show("Please enter a valid Faculty ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the Day already exists
                string checkQuery = "SELECT COUNT(*) FROM Class WHERE [Day] = @Day";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Day", classday.Text);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("This day already exists, please insert a different day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Insert the data into the Class table
                string query = "INSERT INTO Class ([Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM], facultyID) " +
                               "VALUES (@Day, @AMto10AM, @AMto12PM, @PMto4PM, @facultyID)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Day", classday.Text);
                cmd.Parameters.AddWithValue("@AMto10AM", firstclass.Text);
                cmd.Parameters.AddWithValue("@AMto12PM", secondclass.Text);
                cmd.Parameters.AddWithValue("@PMto4PM", thirdclass.Text);
                cmd.Parameters.AddWithValue("@facultyID", id.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Class added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData1(); // Reload the data after adding
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }


        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if the day text box is empty
            if (string.IsNullOrWhiteSpace(day.Text))
            {
                MessageBox.Show("You must add a day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // Check if the Day exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Exam WHERE [Day] = @Day";  // Count rows with the same Day

            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@Day", day.Text); // Use the Day value entered by the user

            try
            {
                conn.Open(); // Open connection

                // Execute the query to check if the Day already exists
                int count = (int)checkCmd.ExecuteScalar(); // Count how many rows match

                if (count == 0)
                {
                    // If the Day doesn't exist, show an error message
                    MessageBox.Show("This day does not exist. Please add a new day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construct the base update query
                string updateQuery = "UPDATE Exam SET ";

                // List to hold parameters dynamically
                List<SqlParameter> parameters = new List<SqlParameter>();

                // Check if each time slot has a value, and append the appropriate part to the query
                if (!string.IsNullOrWhiteSpace(firstxm.Text))
                {
                    updateQuery += "[8 AM TO 10 AM] = @AMto10AM, ";
                    parameters.Add(new SqlParameter("@AMto10AM", firstxm.Text));
                }

                if (!string.IsNullOrWhiteSpace(secondxm.Text))
                {
                    updateQuery += "[10 AM TO 12 PM] = @AMto12PM, ";
                    parameters.Add(new SqlParameter("@AMto12PM", secondxm.Text));
                }

                if (!string.IsNullOrWhiteSpace(thirdxm.Text))
                {
                    updateQuery += "[2 PM TO 4 PM] = @PMto4PM, ";
                    parameters.Add(new SqlParameter("@PMto4PM", thirdxm.Text));
                }

                // Remove the trailing comma and space
                updateQuery = updateQuery.TrimEnd(',', ' ') + " WHERE [Day] = @Day";

                // Add the Day parameter
                parameters.Add(new SqlParameter("@Day", day.Text));

                // Set up the command with the dynamic query and parameters
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddRange(parameters.ToArray());

                // Execute the update command
                updateCmd.ExecuteNonQuery();
                MessageBox.Show("shedule updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the data after update
                LoadData();
            }
            catch (Exception ex)
            {
                // Show any error that occurs during the update
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Check if the day text box is empty
            if (string.IsNullOrWhiteSpace(classday.Text))
            {
                MessageBox.Show("You must add a day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the FacultyID text box is empty
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("You must enter a Faculty ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open(); // Open connection

                // Check if the Day exists in the Class table
                string checkQuery = "SELECT COUNT(*) FROM Class WHERE [Day] = @Day";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Day", classday.Text);

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    // If the Day doesn't exist, show an error message
                    MessageBox.Show("This day does not exist. Please add a new day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if FacultyID exists in the Faculty table
                string facultyCheckQuery = "SELECT COUNT(*) FROM Faculty WHERE facultyID = @facultyID";
                SqlCommand facultyCheckCmd = new SqlCommand(facultyCheckQuery, conn);
                facultyCheckCmd.Parameters.AddWithValue("@facultyID", id.Text);

                int facultyExists = (int)facultyCheckCmd.ExecuteScalar();

                if (facultyExists == 0)
                {
                    // If FacultyID doesn't exist, show an error message
                    MessageBox.Show("Invalid Faculty ID. Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construct the base update query
                string updateQuery = "UPDATE Class SET ";

                // List to hold parameters dynamically
                List<SqlParameter> parameters = new List<SqlParameter>();

                // Check if each time slot has a value, and append the appropriate part to the query
                if (!string.IsNullOrWhiteSpace(firstclass.Text))
                {
                    updateQuery += "[8 AM TO 10 AM] = @AMto10AM, ";
                    parameters.Add(new SqlParameter("@AMto10AM", firstclass.Text));
                }

                if (!string.IsNullOrWhiteSpace(secondclass.Text))
                {
                    updateQuery += "[10 AM TO 12 PM] = @AMto12PM, ";
                    parameters.Add(new SqlParameter("@AMto12PM", secondclass.Text));
                }

                if (!string.IsNullOrWhiteSpace(thirdclass.Text))
                {
                    updateQuery += "[2 PM TO 4 PM] = @PMto4PM, ";
                    parameters.Add(new SqlParameter("@PMto4PM", thirdclass.Text));
                }

                if (!string.IsNullOrWhiteSpace(id.Text))
                {
                    updateQuery += "[facultyID] = @facultyID, ";
                    parameters.Add(new SqlParameter("@facultyID", id.Text));
                }

                // Remove the trailing comma and space
                updateQuery = updateQuery.TrimEnd(',', ' ') + " WHERE [Day] = @Day";

                // Add the Day parameter
                parameters.Add(new SqlParameter("@Day", classday.Text));

                // Set up the command with the dynamic query and parameters
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddRange(parameters.ToArray());

                // Execute the update command
                updateCmd.ExecuteNonQuery();
                MessageBox.Show("Class updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the data after update
                LoadData1();
            }
            catch (Exception ex)
            {
                // Show any error that occurs during the update
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(day.Text))
            {
                MessageBox.Show("Please select a day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // Check if the Day exists in the database
            string checkQuery = "SELECT COUNT(*) FROM Exam WHERE [Day] = @Day";  // Count rows with the same Day

            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@Day", day.Text); // Use the Day value entered by the user

            try
            {
                conn.Open(); // Open connection

                // Execute the query to check if the Day exists
                int count = (int)checkCmd.ExecuteScalar(); // Count how many rows match

                if (count == 0)
                {
                    // If the Day doesn't exist, show an error message
                    MessageBox.Show("This day does not exist. Please insert another day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If Day exists, proceed with deleting the data
                string deleteQuery = "DELETE FROM Exam WHERE [Day] = @Day";

                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@Day", day.Text);

                // Execute the delete command
                deleteCmd.ExecuteNonQuery();
                MessageBox.Show("Exam deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload the data after deletion
                LoadData();
            }
            catch (Exception ex)
            {
                // Show any error that occurs during the delete operation
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Check if the day text box is empty
            if (string.IsNullOrWhiteSpace(classday.Text))
            {
                MessageBox.Show("Please select a day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if the FacultyID text box is empty
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("You must enter a Faculty ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open(); // Open connection

                // Check if the Day exists in the Class table
                string checkQuery = "SELECT COUNT(*) FROM Class WHERE [Day] = @Day";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Day", classday.Text);

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    // If the Day doesn't exist, show an error message
                    MessageBox.Show("This day does not exist. Please insert another day.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if FacultyID exists in the Faculty table
                string facultyCheckQuery = "SELECT COUNT(*) FROM Faculty WHERE facultyID = @facultyID";
                SqlCommand facultyCheckCmd = new SqlCommand(facultyCheckQuery, conn);
                facultyCheckCmd.Parameters.AddWithValue("@facultyID", id.Text);

                int facultyExists = (int)facultyCheckCmd.ExecuteScalar();

                if (facultyExists == 0)
                {
                    // If FacultyID doesn't exist, show an error message
                    MessageBox.Show("Invalid Faculty ID. Please enter a valid ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If both Day and FacultyID exist, proceed with deletion
                string deleteQuery = "DELETE FROM Class WHERE [Day] = @Day AND facultyID = @facultyID";

                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@Day", classday.Text);
                deleteCmd.Parameters.AddWithValue("@facultyID", id.Text);

                // Execute the delete command
                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Class deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No matching class found for this Faculty ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Reload the data after deletion
                LoadData1();
            }
            catch (Exception ex)
            {
                // Show any error that occurs during the delete operation
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is always closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open();

                // Query to fetch all or filtered data from Class table
                string classQuery = string.IsNullOrWhiteSpace(classday.Text)
                    ? "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM], facultyID FROM Class"
                    : "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM], facultyID FROM Class WHERE [Day] = @Day";

                SqlDataAdapter classAdapter = new SqlDataAdapter(classQuery, conn);
                DataTable classTable = new DataTable();

                if (!string.IsNullOrWhiteSpace(classday.Text))
                {
                    classAdapter.SelectCommand.Parameters.AddWithValue("@Day", classday.Text);
                }

                classAdapter.Fill(classTable);
                dataGridView2.DataSource = classTable; // Bind data to DataGridView

                MessageBox.Show("Data displayed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchday.Text))
            {
                MessageBox.Show("Please enter a day to search.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            try
            {
                conn.Open();

                // Check if the day exists in Exam
                string checkQuery = "SELECT COUNT(*) FROM Exam WHERE [Day] = @Day";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@Day", searchday.Text);
                int countExam = (int)checkCmd.ExecuteScalar();

                // Check if the day exists in Class
                string checkQuery1 = "SELECT COUNT(*) FROM Class WHERE [Day] = @Day";
                SqlCommand checkCmd1 = new SqlCommand(checkQuery1, conn);
                checkCmd1.Parameters.AddWithValue("@Day", searchday.Text);
                int countClass = (int)checkCmd1.ExecuteScalar();

                // If the day is not found in both tables
                if (countExam == 0 && countClass == 0)
                {
                    MessageBox.Show("No records found for this day.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Query to fetch data from Exam
                string searchQuery = "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM] FROM Exam WHERE [Day] = @Day";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(searchQuery, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@Day", searchday.Text);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt; // Display results in dataGridView1

                // Query to fetch data from Class
                string searchQuery1 = "SELECT [Day], [8 AM TO 10 AM], [10 AM TO 12 PM], [2 PM TO 4 PM],facultyID  FROM Class WHERE [Day] = @Day";
                SqlDataAdapter dataAdapter1 = new SqlDataAdapter(searchQuery1, conn);
                dataAdapter1.SelectCommand.Parameters.AddWithValue("@Day", searchday.Text);
                DataTable dt1 = new DataTable();
                dataAdapter1.Fill(dt1);
                dataGridView2.DataSource = dt1; // Display results in dataGridView2

                MessageBox.Show("Search completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    
