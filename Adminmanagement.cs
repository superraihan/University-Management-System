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
    public partial class Adminmanagement : Form
    {
        public Adminmanagement()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");
            conn.Open();
            string query = "select * from Admin";
           SqlDataAdapter sda = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }
        
        private void Adminmanagement_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet.Admin' table. You can move, or remove it, as needed.
            this.adminTableAdapter2.Fill(this.university_Management_SystemDataSet.Admin);
          


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                // Check if the ID field is filled
                if (!string.IsNullOrWhiteSpace(admin_id.Text)) // Assuming 'admin_id' is the TextBox for ID
                {
                    MessageBox.Show("Cannot insert ID. It is auto-generated.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validation for empty fields
                if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(username.Text) ||
                    string.IsNullOrWhiteSpace(password.Text) || string.IsNullOrWhiteSpace(email.Text) ||
                    string.IsNullOrWhiteSpace(phnnumber.Text) || string.IsNullOrWhiteSpace(gender.Text) ||
                    string.IsNullOrWhiteSpace(dob.Text) || string.IsNullOrWhiteSpace(address.Text) ||
                    string.IsNullOrWhiteSpace(salary.Text))
                {
                    MessageBox.Show("Please fill up all information.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Email validation
                if (!email.Text.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Email must be a valid Gmail address (e.g., example@gmail.com).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Phone number validation
                if (!phnnumber.Text.StartsWith("01") || phnnumber.Text.Length != 11 || !long.TryParse(phnnumber.Text, out _))
                {
                    MessageBox.Show("Phone number must start with '01' and be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // If all validations pass, proceed with database operations
                SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Admin(Name, Username, Password, Email, Gender, PhoneNumber, DOB, Address, Salary) VALUES(@Name, @Username, @Password, @Email, @Gender, @PhoneNumber, @DOB, @Address, @Salary)", conn);

                    cmd.Parameters.AddWithValue("@Name", name.Text);
                    cmd.Parameters.AddWithValue("@Username", username.Text);
                    cmd.Parameters.AddWithValue("@Password", password.Text);
                    cmd.Parameters.AddWithValue("@Email", email.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phnnumber.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender.Text);
                    cmd.Parameters.AddWithValue("@DOB", dob.Text);
                    cmd.Parameters.AddWithValue("@Address", address.Text);
                    cmd.Parameters.AddWithValue("@Salary", salary.Text);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Refresh the data
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during database operation: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

            conn.Open();
            string query = "select * from Admin";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            conn.Close();
            LoadData();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate if ID is provided
                if (string.IsNullOrWhiteSpace(admin_id.Text))
                {
                    MessageBox.Show("Please insert an ID first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // List to store SQL fields that need to be updated
                List<string> updateFields = new List<string>();
                Dictionary<string, string> parameters = new Dictionary<string, string>();

                // Check each field and add it to the update list if filled
                if (!string.IsNullOrWhiteSpace(name.Text))
                {
                    updateFields.Add("Name = @Name");
                    parameters.Add("@Name", name.Text);
                }
                if (!string.IsNullOrWhiteSpace(username.Text))
                {
                    updateFields.Add("Username = @Username");
                    parameters.Add("@Username", username.Text);
                }
                if (!string.IsNullOrWhiteSpace(password.Text))
                {
                    updateFields.Add("Password = @Password");
                    parameters.Add("@Password", password.Text);
                }
                if (!string.IsNullOrWhiteSpace(email.Text))
                {
                    updateFields.Add("Email = @Email");
                    parameters.Add("@Email", email.Text);
                }
                if (!string.IsNullOrWhiteSpace(phnnumber.Text))
                {
                    updateFields.Add("PhoneNumber = @PhoneNumber");
                    parameters.Add("@PhoneNumber", phnnumber.Text);
                }
                if (!string.IsNullOrWhiteSpace(gender.Text))
                {
                    updateFields.Add("Gender = @Gender");
                    parameters.Add("@Gender", gender.Text);
                }
                if (!string.IsNullOrWhiteSpace(dob.Text))
                {
                    updateFields.Add("DOB = @DOB");
                    parameters.Add("@DOB", dob.Text);
                }
                if (!string.IsNullOrWhiteSpace(address.Text))
                {
                    updateFields.Add("Address = @Address");
                    parameters.Add("@Address", address.Text);
                }
                if (!string.IsNullOrWhiteSpace(salary.Text))
                {
                    updateFields.Add("Salary = @Salary");
                    parameters.Add("@Salary", salary.Text);
                }

                // If no fields are filled except ID, show a warning
                if (updateFields.Count == 0)
                {
                    MessageBox.Show("Cannot update ID alone. Please fill at least one other field to update.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Build the dynamic SQL update statement
                string updateQuery = $"UPDATE Admin SET {string.Join(", ", updateFields)} WHERE Admin_id = @Admin_id";

                // Database connection
                using (SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True"))
                {
                    try
                    {
                        conn.Open();

                        // Create and execute the update command
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Admin_id", admin_id.Text);

                            // Add only the required parameters
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }

                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Only show success if rows were actually affected
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadData(); // Refresh the data
                            }
                            else
                            {
                                MessageBox.Show("No record found with the provided ID or no changes were made.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if the ID field is empty or contains only spaces
                if (string.IsNullOrWhiteSpace(admin_id.Text))
                {
                    MessageBox.Show("Please insert an ID first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Database connection
                SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");

                try
                {
                    conn.Open();

                    // Execute delete command
                    SqlCommand cmd = new SqlCommand("DELETE FROM Admin WHERE Admin_id = @Admin_id", conn);
                    cmd.Parameters.AddWithValue("@Admin_id", admin_id.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close(); // No need to check connection state before closing

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Refresh the data
                    }
                    else
                    {
                        MessageBox.Show("No record found with the provided ID. Please insert a valid ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close(); // Just close it directly
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

           


        }

        private void search_Click(object sender, EventArgs e)
        {

            try
            {
                // Validate if ID is provided
                if (string.IsNullOrWhiteSpace(searchbox.Text))
                {
                    MessageBox.Show("Please enter an ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the input is a valid integer
                if (!int.TryParse(searchbox.Text, out int adminId))
                {
                    MessageBox.Show("Can Serach only by ID, Please enter a valid ID to search.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Database connection
                using (SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True"))
                {
                    conn.Open();

                    // Create the SQL command to search by Admin_id
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Admin WHERE Admin_id = @Admin_id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Admin_id", adminId);

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        // Check if any records were found
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt; // Bind the results to the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("No record found with the provided ID. Please enter a valid ID.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
