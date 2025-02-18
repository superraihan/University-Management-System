using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace University_Management_System
{
    public partial class TeacherRegistrationForm : Form
    {
        private DateTimePicker dateTimePicker1;



        public TeacherRegistrationForm()
        {
            InitializeComponent();
            errorProvider1 = new ErrorProvider();
            errorProvider2 = new ErrorProvider();
            errorProvider3 = new ErrorProvider();
            errorProvider4 = new ErrorProvider();
            errorProvider5 = new ErrorProvider();
            errorProvider6 = new ErrorProvider();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TeacherRegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }




        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Clear previous errors
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            errorProvider6.Clear();

            bool hasError = false;

           
            if (textBox1.Text.Trim() == "")
            {
                errorProvider1.SetError(textBox1, "Please enter your name!");
                hasError = true;
            }

            
            if (!Regex.IsMatch(txtPhone.Text.Trim(), @"^\d{11}$"))
            {
                errorProvider2.SetError(txtPhone, "Phone number must be 11 digits!");
                hasError = true;
            }

            
            if (!txtEmail.Text.Trim().ToLower().EndsWith("@gmail.com"))
            {
                errorProvider3.SetError(txtEmail, "Email must be a valid @gmail.com address!");
                hasError = true;
            }

           
            if (textUsername.Text.Trim() == "")
            {
                errorProvider4.SetError(textUsername, "Please enter a username!");
                hasError = true;
            }

            
            

            
            if (textPassword.Text.Trim().Length < 6)
            {
                errorProvider6.SetError(textPassword, "Password must be at least 6 characters!");
                hasError = true;
            }

            

            // Validate Gender selection first
            if (comboBox1.SelectedItem == null)
            {
                errorProvider6.SetError(comboBox1, "Please select a gender!");
                hasError = true;
            }

            // If there is an error, stop execution
            

            if (hasError)
            {
                return;
            }

            try
            {
                string connectionString = @"Data Source=RAIHAN-19\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True";  // Replace with your actual connection string

                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                // Prepare SQL command to insert teacher registration details
                string query = @"INSERT INTO Faculty (Name, Username, Password, DOB, Phone, Email, Gender, Address)
                     VALUES (@Name, @Username, @Password, @DOB, @Phone, @Email, @Gender, @Address)";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters to avoid SQL injection
                cmd.Parameters.AddWithValue("@Name", textBox1?.Text.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Username", textUsername?.Text.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Password", textPassword?.Text.Trim() ?? "");
                cmd.Parameters.AddWithValue("@DOB", dateTimePicker1?.Value.Date ?? DateTime.Now);
                cmd.Parameters.AddWithValue("@Phone", txtPhone?.Text.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Email", txtEmail?.Text.Trim() ?? "");
                cmd.Parameters.AddWithValue("@Gender", comboBox1?.SelectedItem?.ToString() ?? "Not Specified");
                cmd.Parameters.AddWithValue("@Address", address.Text.Trim() ?? "");
               
                // Assuming Subject is entered in txtSubject

                // Execute the insert command
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if insertion is successful
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error in registration. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Close connections manually since we removed "using"
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Registration frm = new Registration();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
