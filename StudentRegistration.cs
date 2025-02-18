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
namespace University_Management_System
{
    public partial class StudentRegistration : Form
    {

        string emailpattern = "^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";

        string passpattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$";

        public StudentRegistration()

        {

            InitializeComponent();

        }



        private void button4_Click(object sender, EventArgs e)

        {

            Registration registration = new Registration();

            registration.ShowDialog();

            this.Close();

        }

        private void txtname_Leave(object sender, EventArgs e)

        {

            if (string.IsNullOrEmpty(txtname.Text) == true)

            {

                txtname.Focus();

                errorProvider1.SetError(this.txtname, " Pls Fill Name");

            }

            else

            {

                errorProvider1.Clear();

            }

        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)

        {

            char ch = e.KeyChar;

            if (char.IsLetter(ch) == true)

            {

                e.Handled = false;

            }

            else if (ch == 8)

            {

                e.Handled = false;

            }

            else if (ch == 32)

            {

                e.Handled = false;

            }
            else

            {

                e.Handled = true;

            }

        }



        private void txtstudentid_Leave(object sender, EventArgs e)

        {

            if (string.IsNullOrEmpty(txtstudentid.Text) == true)

            {

                txtstudentid.Focus();

                errorProvider2.SetError(this.txtstudentid, " Pls Fill Student ID ");

            }

            else

            {

                errorProvider2.Clear();

            }

        }

        private void txtstudentid_KeyPress(object sender, KeyPressEventArgs e)

        {

            char ch = e.KeyChar;

            if (char.IsDigit(ch) == true)

            {

                e.Handled = false;

            }

            else if (ch == 8)

            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true;

            }

        }



        private void txtpassword_Leave(object sender, EventArgs e)

        {

            if (!Regex.IsMatch(txtpassword.Text, passpattern))

            {

                txtpassword.Focus();

                errorProvider3.SetError(txtpassword, "Please enter a strong password (min 8 chars, 1 uppercase, 1 lowercase, 1 digit, 1 special char)");

            }

            else

            {

                errorProvider3.Clear();

            }

        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)

        {

        }

        private void txtemail_Leave(object sender, EventArgs e)

        {

            if (Regex.IsMatch(txtemail.Text, emailpattern) == false)

            {

                txtpassword.Focus();

                errorProvider4.SetError(this.txtemail, " Pls Enter  Valid Email");

            }

            else

            {

                errorProvider4.Clear();

            }

        }

        private void txtphnonenumber_Leave(object sender, EventArgs e)

        {

            if (string.IsNullOrEmpty(txtphnonenumber.Text) == true)

            {

                txtphnonenumber.Focus();

                errorProvider5.SetError(this.txtphnonenumber, " Pls Fill Phone Number ");

            }

            else

            {

                errorProvider5.Clear();

            }

        }

        private void txtphnonenumber_KeyPress(object sender, KeyPressEventArgs e)

        {

            char ch = e.KeyChar;

            if (char.IsDigit(ch) == true)

            {

                e.Handled = false;

            }

            else if (ch == 8)

            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true;

            }

        }

        private void txtaddress_Leave(object sender, EventArgs e)

        {

            if (string.IsNullOrEmpty(txtaddress.Text) == true)

            {

                txtaddress.Focus();

                errorProvider6.SetError(this.txtaddress, " pls Fill Address ");

            }

            else

            {

                errorProvider6.Clear();

            }

        }

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)

        {

            char ch = e.KeyChar;

            if (char.IsLetter(ch) == true)

            {

                e.Handled = false;

            }

            else if (ch == 8)

            {

                e.Handled = false;

            }

            else if (ch == 32)

            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true;

            }

        }

        
        private void txtcountry_KeyPress(object sender, KeyPressEventArgs e)

        {

            char ch = e.KeyChar;

            if (char.IsLetter(ch) == true)

            {

                e.Handled = false;

            }

            else if (ch == 8)

            {

                e.Handled = false;

            }

            else if (ch == 32)

            {

                e.Handled = false;

            }

            else

            {

                e.Handled = true;

            }

        }

        

        private void btnsubmit_Click(object sender, EventArgs e)

        {

            if (string.IsNullOrEmpty(txtname.Text) == true)

            {

                txtname.Focus();

                errorProvider1.SetError(this.txtname, " Pls Fill Name");

            }

            else if (string.IsNullOrEmpty(txtstudentid.Text) == true)

            {

                txtstudentid.Focus();

                errorProvider2.SetError(this.txtstudentid, " Pls Fill Student ID ");

            }

            else if (Regex.IsMatch(txtpassword.Text, passpattern) == false)

            {

                txtpassword.Focus();

                errorProvider3.SetError(this.txtpassword, " Pls Enter Strong Password ");

            }

            else if (Regex.IsMatch(txtemail.Text, emailpattern) == false)

            {

                txtpassword.Focus();

                errorProvider4.SetError(this.txtemail, " Pls Enter  Valid Email");

            }

            else if (string.IsNullOrEmpty(txtphnonenumber.Text) == true)

            {

                txtphnonenumber.Focus();

                errorProvider5.SetError(this.txtphnonenumber, " Pls Fill Phone Number ");

            }

            else if (string.IsNullOrEmpty(txtaddress.Text) == true)

            {

                txtaddress.Focus();

                errorProvider6.SetError(this.txtaddress, " pls Fill Address ");

            }
            else

            {

                MessageBox.Show("Student Registration Successfully");

            }

            SqlConnection conn = new SqlConnection("Data Source=RAIHAN-19\\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");
            conn.Open();
            SqlCommand cnn = new SqlCommand("insert into student (name,username,password,email,gender,Phone_no,Address, date_of_birth, department) values(@name,@username,@password,@email,@gender,@Phone_no,@Address,@date_of_birth,@department)", conn);
            cnn.Parameters.AddWithValue("@name", (txtname.Text));
            cnn.Parameters.AddWithValue("@username", (txtname.Text));
            cnn.Parameters.AddWithValue("@password", (txtpassword.Text));
            cnn.Parameters.AddWithValue("@email", (txtemail.Text));
            cnn.Parameters.AddWithValue("@gender", (cmbgender.Text));
            cnn.Parameters.AddWithValue("@phone_no", (txtphnonenumber.Text));
            cnn.Parameters.AddWithValue("@date_of_birth", (datedob.Text));
            cnn.Parameters.AddWithValue("@address", (txtaddress.Text));
            cnn.Parameters.AddWithValue("@department", (cmbdepartment.Text));
            
            cnn.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show(" Registration Successful ");
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();

        }

        private void btnreset_Click(object sender, EventArgs e)

        {

            txtname.Clear();

            txtstudentid.Clear();

            txtpassword.Clear();

            txtemail.Clear();

            txtphnonenumber.Clear();

            txtaddress.Clear();

            

            cmbdepartment.Items.Clear();

            txtname.Focus();

        }

        private void pictureBox1_Click(object sender, EventArgs e)

        {

        }

        private void StudentRegistration_Load(object sender, EventArgs e)

        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }

}

