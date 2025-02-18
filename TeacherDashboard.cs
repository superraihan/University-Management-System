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
    public partial class TeacherDashboard : Form
    {
        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void TeacherDashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create and show the CoursesForm
            Courses coursesForm = new Courses();
            coursesForm.Show();  // This will open the CoursesForm

            //Hide the TeacherDashboard form
            this.Hide();  // This hides the TeacherDashboard form
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AssignmentSegment_Click(object sender, EventArgs e)
        {
            // Create and show the AssignmentsForm
            Assignment assignmentsForm = new Assignment();
            assignmentsForm.Show();

            // Hide the TeacherDashboard form
            this.Hide();
        }

        private void AttendenceManagement_Click(object sender, EventArgs e)
        {
        
        }


        private void StudentReport_Click(object sender, EventArgs e)
        {
            // Create and show the PerformanceForm
            StudentReport performanceForm = new StudentReport();
            performanceForm.Show();

            // Hide the TeacherDashboard form
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            
            form1.Show();
            this.Hide();
                         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            
            Personal_Information  p = new Personal_Information();
            p.Show();

            // Hide the TeacherDashboard form
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
