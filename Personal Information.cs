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
    public partial class Personal_Information : Form
    {
        private string connectionString = @"Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True";
        public Personal_Information()
        {
            InitializeComponent();
        }

        private void Personal_Information_Load(object sender, EventArgs e)
        {
            LoadTeacherData();
        }

        private void LoadTeacherData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT name, designation, gender, department, username, email, contact_no, address FROM teachers";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvInfo.DataSource = dt;


                dgvInfo.Columns["name"].ReadOnly = true;
                dgvInfo.Columns["designation"].ReadOnly = true;
                dgvInfo.Columns["gender"].ReadOnly = true;
                dgvInfo.Columns["department"].ReadOnly = true;
            }


            EnableEditing(false);
        }


        private void EnableEditing(bool enable)
        {
            textBoxUsername.ReadOnly = !enable;
            textBoxEmail.ReadOnly = !enable;
            textBoxContact.ReadOnly = !enable;
            textBoxAddress.ReadOnly = !enable;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeacherDashboard dashboard = new TeacherDashboard();
            dashboard.Show();

            // Close the current form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInfo.Rows[e.RowIndex];

                // Load values into textboxes
                textBoxUsername.Text = row.Cells["username"].Value?.ToString() ?? "";
                textBoxEmail.Text = row.Cells["email"].Value?.ToString() ?? "";
                textBoxContact.Text = row.Cells["contact_no"].Value?.ToString() ?? "";
                textBoxAddress.Text = row.Cells["address"].Value?.ToString() ?? "";

                // Disable editing unless the "Edit" button is clicked
                EnableEditing(false);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                if (dgvInfo.SelectedRows.Count > 0)
                {
                    EnableEditing(true); // Enable textboxes for editing
                    btnEdit.Text = "Update"; // Change button text to "Update"
                    isEditing = true; // Switch to edit mode
                }
                else
                {
                    MessageBox.Show("Please select a row to edit.");
                }
            }
            else // If in edit mode, save updates
            {
                if (dgvInfo.SelectedRows.Count > 0)
                {
                    // Get the name from the selected row (this is used to identify the teacher in the database)
                    string name = dgvInfo.SelectedRows[0].Cells["name"].Value.ToString();

                    string username = textBoxUsername.Text;
                    string email = textBoxEmail.Text;
                    string contact = textBoxContact.Text;
                    string address = textBoxAddress.Text;

                    // Update teacher data in the database
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE teachers SET username = @username, email = @email, contact_no = @contact, address = @address WHERE name = @name";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@contact", contact);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@name", name);

                        con.Open();
                        cmd.ExecuteNonQuery(); // Execute the update command
                        con.Close();
                    }

                    MessageBox.Show("Information updated successfully!");

                    // Reload the teacher data in the grid after the update
                    LoadTeacherData();

                    EnableEditing(false); // Disable editing
                    btnEdit.Text = "Edit"; // Reset the button text to "Edit"
                    isEditing = false; // Switch back to view mode
                }
                else
                {
                    MessageBox.Show("Please select a row to update.");
                }
            }
        }
    
                private bool isEditing = false;

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void Personal_Information_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'university_Management_SystemDataSet12.Faculty' table. You can move, or remove it, as needed.
            this.facultyTableAdapter.Fill(this.university_Management_SystemDataSet12.Faculty);

        }
    }
            
    }


            
    
    

