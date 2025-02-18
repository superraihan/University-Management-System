using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management_System
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        public void loadform(object Form)
        {
            if (this.Mainpanel.Controls.Count > 0)
            {
                this.Mainpanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.Mainpanel.Controls.Add(f);
            this.Mainpanel.Tag = f;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new StudentProfileForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new CourseForm());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new EnrollmentForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new GradeForm());
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            loadform(new ExamForm());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadform(new CourseMaterialForm());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadform(new PaymentForm());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            loadform(new NotificationForm());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            loadform(new DiscussionForm());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();


        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}
