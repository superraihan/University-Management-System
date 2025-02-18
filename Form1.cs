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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f7 = new Form7();
            f7.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=RAIHAN-19\SQLEXPRESS;Initial Catalog=University_Management_System;Integrated Security=True");
            string Username, Password;
            Username = textBox1.Text;
            Password = textBox2.Text;
            try
            {

                string query = "select * from Faculty where Username = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if (dtbl.Rows.Count > 0)
                {
                    Username = textBox1.Text;
                    Password = textBox2.Text;
                    this.Hide();
                    TeacherDashboard f8 = new TeacherDashboard();
                    f8.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }

            catch
            {
                MessageBox.Show("Invalid");
            }
            finally
            {
                conn.Close();
            }
        }


private void label5_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            Form7 f = new Form7();
            f.ShowDialog();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Registration f = new Registration();
            f.ShowDialog();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
