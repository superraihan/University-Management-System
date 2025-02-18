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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace University_Management_System
{
    public partial class Facultymanagement : Form
    {
        public Facultymanagement()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // SQL query to fetch data from Faculty table
            string query = "SELECT facultyID, Name, Username, Email, Gender, DOB, Phone, Address, Salary FROM Faculty";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();

            try
            {
                conn.Open(); // Open connection
                dataAdapter.Fill(dataTable); // Fill data into DataTable

                // Set DataGridView's DataSource to the DataTable
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void Facultymanagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet8.Faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter.Fill(this.university_Management_SystemDataSet8.Faculty);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("ID cannot be added manually. It is auto-generated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(username.Text) ||
                string.IsNullOrWhiteSpace(password.Text) ||
                string.IsNullOrWhiteSpace(email.Text) ||
                string.IsNullOrWhiteSpace(gender.Text) ||
                string.IsNullOrWhiteSpace(dob.Text) ||
                string.IsNullOrWhiteSpace(phonenumber.Text) ||
                string.IsNullOrWhiteSpace(address.Text) ||
                string.IsNullOrWhiteSpace(salary.Text))
            {
                MessageBox.Show("Please fill up all the fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // SQL Insert Query
            string query = "INSERT INTO Faculty (Name, Username, Password, Email, Gender, DOB, Phone, Address, Salary) " +
                           "VALUES (@Name, @Username, @Password, @Email, @Gender, @DOB, @Phone, @Address, @Salary)";

            SqlCommand cmd = new SqlCommand(query, conn);

            // Add parameterized values to prevent SQL Injection
            cmd.Parameters.AddWithValue("@Name", name.Text);
            cmd.Parameters.AddWithValue("@Username", username.Text);
            cmd.Parameters.AddWithValue("@Password", password.Text);
            cmd.Parameters.AddWithValue("@Email", email.Text);
            cmd.Parameters.AddWithValue("@Gender", gender.Text);
            cmd.Parameters.AddWithValue("@DOB", dob.Text);
            cmd.Parameters.AddWithValue("@Phone", phonenumber.Text);
            cmd.Parameters.AddWithValue("@Address", address.Text);

            cmd.Parameters.AddWithValue("@Salary", salary.Text);
            
           

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Faculty added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear fields after successful insertion
                ClearFields();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose(); // Dispose the command object
                conn.Close();  // Close the connection
            }
            LoadData();
        }

        // Method to clear all input fields after adding
        private void ClearFields()
        {
            name.Text = "";
            username.Text = "";
            password.Text = "";
            email.Text = "";
            gender.SelectedIndex = -1;
            dob.Text = "";
            phonenumber.Text = "";
            address.Text = "";
            salary.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Check if ID is provided
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Please enter the Faculty ID to delete.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // SQL query to check if the Faculty ID exists
            string checkQuery = "SELECT COUNT(*) FROM Faculty WHERE facultyID = @facultyID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@facultyID", id.Text);

            try
            {
                conn.Open();

                // Check if the Faculty ID exists
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Faculty ID not found. Please enter a valid Faculty ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // If Faculty ID exists, proceed with deletion
                string deleteQuery = "DELETE FROM Faculty WHERE facultyID = @facultyID";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                deleteCmd.Parameters.AddWithValue("@facultyID", id.Text);

                // Execute delete query
                deleteCmd.ExecuteNonQuery();
                MessageBox.Show("Faculty deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reload data after deletion
                LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure the connection is always closed
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Check if Faculty ID is provided
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Please enter the Faculty ID to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // SQL query to check if the Faculty ID exists
            string checkQuery = "SELECT COUNT(*) FROM Faculty WHERE facultyID = @FacultyID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@FacultyID", id.Text);

            try
            {
                conn.Open();

                // Check if the Faculty ID exists
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Faculty ID not found. Please enter a valid Faculty ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // SQL query to update Faculty record
                string updateQuery = "UPDATE Faculty SET ";

                // Build the update query dynamically based on which fields are filled
                List<SqlParameter> parameters = new List<SqlParameter>();

                // Add parameters if fields are filled
                if (!string.IsNullOrWhiteSpace(name.Text))
                {
                    updateQuery += "[Name] = @Name, ";
                    parameters.Add(new SqlParameter("@Name", name.Text));
                }
                if (!string.IsNullOrWhiteSpace(username.Text))
                {
                    updateQuery += "[Username] = @Username, ";
                    parameters.Add(new SqlParameter("@Username", username.Text));
                }
                if (!string.IsNullOrWhiteSpace(password.Text))
                {
                    updateQuery += "[Password] = @Password, ";
                    parameters.Add(new SqlParameter("@Password", password.Text));
                }
                if (!string.IsNullOrWhiteSpace(email.Text))
                {
                    updateQuery += "[Email] = @Email, ";
                    parameters.Add(new SqlParameter("@Email", email.Text));
                }
                if (!string.IsNullOrWhiteSpace(gender.Text))
                {
                    updateQuery += "[Gender] = @Gender, ";
                    parameters.Add(new SqlParameter("@Gender", gender.Text));
                }
                if (!string.IsNullOrWhiteSpace(dob.Text))
                {
                    updateQuery += "[DOB] = @DOB, ";
                    parameters.Add(new SqlParameter("@DOB", dob.Text));
                }
                if (!string.IsNullOrWhiteSpace(phonenumber.Text))
                {
                    updateQuery += "[Phone] = @Phone, ";
                    parameters.Add(new SqlParameter("@Phone", phonenumber.Text));
                }
                if (!string.IsNullOrWhiteSpace(address.Text))
                {
                    updateQuery += "[Address] = @Address, ";
                    parameters.Add(new SqlParameter("@Address", address.Text));
                }
                if (!string.IsNullOrWhiteSpace(salary.Text))
                {
                    updateQuery += "[Salary] = @Salary, ";
                    parameters.Add(new SqlParameter("@Salary", salary.Text));
                }

                // Remove the last comma and space from the query
                updateQuery = updateQuery.TrimEnd(',', ' ');

                // Add condition to update the record for specific Faculty ID
                updateQuery += " WHERE facultyID = @FacultyID";
                parameters.Add(new SqlParameter("@FacultyID", id.Text));

                // Execute the update query
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);

                // Add the parameters to the update command
                updateCmd.Parameters.AddRange(parameters.ToArray());

                // Execute the update command
                updateCmd.ExecuteNonQuery();
                MessageBox.Show("Faculty updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the fields after update
                ClearFields();

                // Reload data after update
                LoadData();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure the connection is always closed
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // SQL query to select all data from the Faculty table
            string query = "SELECT facultyID, [Name], [Username], [Password], [Email], [Gender], [DOB], [Phone], [Address], [Salary] FROM Faculty";

            // Create a SqlDataAdapter to retrieve data
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

            // Create a DataTable to hold the data
            DataTable facultyTable = new DataTable();

            try
            {
                conn.Open();

                // Fill the DataTable with data from the Faculty table
                dataAdapter.Fill(facultyTable);

                // Bind the data to the DataGridView to display
                dataGridView1.DataSource = facultyTable;

                MessageBox.Show("Faculty data displayed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed after use
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
           
           
            if (string.IsNullOrWhiteSpace(searchbox.Text))
            {
                MessageBox.Show("Please enter a Faculty ID to search.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL connection string
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            // Query to check if the Faculty ID exists
            string checkQuery = "SELECT COUNT(*) FROM Faculty WHERE facultyID = @FacultyID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
            checkCmd.Parameters.AddWithValue("@FacultyID", searchbox.Text);

            try
            {
                conn.Open();

                // Execute the query to check if the Faculty ID exists
                int count = (int)checkCmd.ExecuteScalar();

                // If the Faculty ID does not exist
                if (count == 0)
                {
                    MessageBox.Show("Entered Faculty ID does not exist. Please enter a valid Faculty ID.",
                                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Query to fetch data for the entered Faculty ID
                string searchQuery = "SELECT facultyID, [Name], [Username], [Password], [Email], [Gender], [DOB], [Phone], [Address], [Salary] FROM Faculty WHERE facultyID = @facultyID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(searchQuery, conn);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@facultyID", searchbox.Text);

                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                // If data is found, display in the DataGridView
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt; // Bind the data to DataGridView
                    MessageBox.Show("Search completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView1.DataSource = null; // Clear DataGridView if no data found
                    MessageBox.Show("No records found for the given Faculty ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Ensure the connection is closed
            }
        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}