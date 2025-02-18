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
using System.Data.Sql;

namespace University_Management_System
{
    public partial class Form4 : Form
    {
        SqlCommand cnn;
        SqlConnection con;
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }   

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form3 frm = new Form3();
            frm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for empty fields and provide specific messages
                if (string.IsNullOrWhiteSpace(name.Text))
                {
                    MessageBox.Show("Please enter your Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(username.Text))
                {
                    MessageBox.Show("Please enter your Username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(password.Text))
                {
                    MessageBox.Show("Please enter your Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(email.Text))
                {
                    MessageBox.Show("Please enter your Email.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!email.Text.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Please enter a valid Gmail address (must end with @gmail.com).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(genderr.Text))
                {
                    MessageBox.Show("Please select your Gender.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(phnnumber.Text))
                {
                    MessageBox.Show("Please enter your Phone Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!phnnumber.Text.StartsWith("01") || phnnumber.Text.Length != 11)
                {
                    MessageBox.Show("Phone number must start with '01' and be 11 digits long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(dob.Text))
                {
                    MessageBox.Show("Please enter your Date of Birth.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(address.Text))
                {
                    MessageBox.Show("Please enter your Address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate email format

                // Validate phone number format


                // Database connection
                using (SqlConnection con = new SqlConnection(@"Data Source=RAIHAN-19\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True"))
                {
                    con.Open();
                    SqlCommand cnn = new SqlCommand("INSERT INTO Admin (Name, Username, Password, Email, Gender, PhoneNumber, DOB, Address) VALUES (@Name, @Username, @Password, @Email, @Gender, @PhoneNumber, @DOB, @Address)", con);
                    cnn.Parameters.AddWithValue("@Name", name.Text);
                    cnn.Parameters.AddWithValue("@Username", username.Text);
                    cnn.Parameters.AddWithValue("@Password", password.Text);
                    cnn.Parameters.AddWithValue("@Email", email.Text);
                    cnn.Parameters.AddWithValue("@Gender", genderr.Text);
                    cnn.Parameters.AddWithValue("@PhoneNumber", phnnumber.Text);
                    cnn.Parameters.AddWithValue("@DOB", dob.Text);
                    cnn.Parameters.AddWithValue("@Address", address.Text);

                    cnn.ExecuteNonQuery();
                }

                MessageBox.Show("Registration Successful");
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during registration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_Validating(object sender, CancelEventArgs e)
        {
            
            
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
