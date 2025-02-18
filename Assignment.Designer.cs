namespace University_Management_System
{
    partial class Assignment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assignment));
            this.label2 = new System.Windows.Forms.Label();
            this.lblCoursesID = new System.Windows.Forms.Label();
            this.lblSubmissionDeadline = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssignmentID = new System.Windows.Forms.TextBox();
            this.dtpSubmissionDeadline = new System.Windows.Forms.DateTimePicker();
            this.dgvAssignments = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtAssignmentTitle = new System.Windows.Forms.TextBox();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.btnback = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.university_Management_SystemDataSet5 = new University_Management_System.University_Management_SystemDataSet5();
            this.assignmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assignmentsTableAdapter = new University_Management_System.University_Management_SystemDataSet5TableAdapters.AssignmentsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coursenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assignmenttitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submissiondeadlineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.university_Management_SystemDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignmentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Pink;
            this.label2.Font = new System.Drawing.Font("Stencil", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(169, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Assignment Title :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblCoursesID
            // 
            this.lblCoursesID.BackColor = System.Drawing.Color.PaleVioletRed;
            this.lblCoursesID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoursesID.Location = new System.Drawing.Point(185, 122);
            this.lblCoursesID.Name = "lblCoursesID";
            this.lblCoursesID.Size = new System.Drawing.Size(191, 31);
            this.lblCoursesID.TabIndex = 3;
            this.lblCoursesID.Text = "Course Name:";
            // 
            // lblSubmissionDeadline
            // 
            this.lblSubmissionDeadline.BackColor = System.Drawing.Color.Orchid;
            this.lblSubmissionDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubmissionDeadline.Location = new System.Drawing.Point(171, 174);
            this.lblSubmissionDeadline.Name = "lblSubmissionDeadline";
            this.lblSubmissionDeadline.Size = new System.Drawing.Size(205, 37);
            this.lblSubmissionDeadline.TabIndex = 5;
            this.lblSubmissionDeadline.Text = "Submission Deadline :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumOrchid;
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAssignmentID);
            this.panel1.Controls.Add(this.dtpSubmissionDeadline);
            this.panel1.Controls.Add(this.dgvAssignments);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.txtAssignmentTitle);
            this.panel1.Controls.Add(this.txtCourseName);
            this.panel1.Controls.Add(this.btnback);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblSubmissionDeadline);
            this.panel1.Controls.Add(this.lblCoursesID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1482, 753);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Plum;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(95, 65);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(68, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.GhostWhite;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Assignment ID";
            // 
            // txtAssignmentID
            // 
            this.txtAssignmentID.Location = new System.Drawing.Point(438, 81);
            this.txtAssignmentID.Name = "txtAssignmentID";
            this.txtAssignmentID.Size = new System.Drawing.Size(210, 22);
            this.txtAssignmentID.TabIndex = 18;
            // 
            // dtpSubmissionDeadline
            // 
            this.dtpSubmissionDeadline.Location = new System.Drawing.Point(410, 178);
            this.dtpSubmissionDeadline.Name = "dtpSubmissionDeadline";
            this.dtpSubmissionDeadline.Size = new System.Drawing.Size(247, 22);
            this.dtpSubmissionDeadline.TabIndex = 17;
            // 
            // dgvAssignments
            // 
            this.dgvAssignments.AutoGenerateColumns = false;
            this.dgvAssignments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.coursenameDataGridViewTextBoxColumn,
            this.assignmenttitleDataGridViewTextBoxColumn,
            this.submissiondeadlineDataGridViewTextBoxColumn});
            this.dgvAssignments.DataSource = this.assignmentsBindingSource;
            this.dgvAssignments.Location = new System.Drawing.Point(95, 292);
            this.dgvAssignments.Name = "dgvAssignments";
            this.dgvAssignments.RowHeadersWidth = 51;
            this.dgvAssignments.RowTemplate.Height = 24;
            this.dgvAssignments.Size = new System.Drawing.Size(818, 220);
            this.dgvAssignments.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Aqua;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(134, 239);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 39);
            this.button3.TabIndex = 14;
            this.button3.Text = "ADD";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(285, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 36);
            this.button1.TabIndex = 13;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(472, 238);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 34);
            this.button2.TabIndex = 8;
            this.button2.Text = "DELETE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(689, 239);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 36);
            this.button4.TabIndex = 15;
            this.button4.Text = "VIEW";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtAssignmentTitle
            // 
            this.txtAssignmentTitle.Location = new System.Drawing.Point(438, 17);
            this.txtAssignmentTitle.Name = "txtAssignmentTitle";
            this.txtAssignmentTitle.Size = new System.Drawing.Size(244, 22);
            this.txtAssignmentTitle.TabIndex = 11;
            this.txtAssignmentTitle.TextChanged += new System.EventHandler(this.txtCourseName_TextChanged);
            // 
            // txtCourseName
            // 
            this.txtCourseName.Location = new System.Drawing.Point(423, 131);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(234, 22);
            this.txtCourseName.TabIndex = 10;
            this.txtCourseName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnback
            // 
            this.btnback.BackColor = System.Drawing.Color.Transparent;
            this.btnback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnback.BackgroundImage")));
            this.btnback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnback.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback.Location = new System.Drawing.Point(3, 3);
            this.btnback.Name = "btnback";
            this.btnback.Size = new System.Drawing.Size(68, 50);
            this.btnback.TabIndex = 7;
            this.btnback.UseVisualStyleBackColor = false;
            this.btnback.Click += new System.EventHandler(this.btnback_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Crimson;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(95, 174);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(68, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Purple;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(95, 117);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(61, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // university_Management_SystemDataSet5
            // 
            this.university_Management_SystemDataSet5.DataSetName = "University_Management_SystemDataSet5";
            this.university_Management_SystemDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // assignmentsBindingSource
            // 
            this.assignmentsBindingSource.DataMember = "Assignments";
            this.assignmentsBindingSource.DataSource = this.university_Management_SystemDataSet5;
            // 
            // assignmentsTableAdapter
            // 
            this.assignmentsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coursenameDataGridViewTextBoxColumn
            // 
            this.coursenameDataGridViewTextBoxColumn.DataPropertyName = "course_name";
            this.coursenameDataGridViewTextBoxColumn.HeaderText = "course_name";
            this.coursenameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.coursenameDataGridViewTextBoxColumn.Name = "coursenameDataGridViewTextBoxColumn";
            // 
            // assignmenttitleDataGridViewTextBoxColumn
            // 
            this.assignmenttitleDataGridViewTextBoxColumn.DataPropertyName = "assignment_title";
            this.assignmenttitleDataGridViewTextBoxColumn.HeaderText = "assignment_title";
            this.assignmenttitleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.assignmenttitleDataGridViewTextBoxColumn.Name = "assignmenttitleDataGridViewTextBoxColumn";
            // 
            // submissiondeadlineDataGridViewTextBoxColumn
            // 
            this.submissiondeadlineDataGridViewTextBoxColumn.DataPropertyName = "submission_deadline";
            this.submissiondeadlineDataGridViewTextBoxColumn.HeaderText = "submission_deadline";
            this.submissiondeadlineDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.submissiondeadlineDataGridViewTextBoxColumn.Name = "submissiondeadlineDataGridViewTextBoxColumn";
            // 
            // Assignment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.panel1);
            this.Name = "Assignment";
            this.Text = "Assignment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Assignment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.university_Management_SystemDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assignmentsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCoursesID;
        private System.Windows.Forms.Label lblSubmissionDeadline;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtAssignmentTitle;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnback;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dgvAssignments;
        private System.Windows.Forms.DateTimePicker dtpSubmissionDeadline;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtAssignmentID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
        private University_Management_SystemDataSet5 university_Management_SystemDataSet5;
        private System.Windows.Forms.BindingSource assignmentsBindingSource;
        private University_Management_SystemDataSet5TableAdapters.AssignmentsTableAdapter assignmentsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coursenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn assignmenttitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn submissiondeadlineDataGridViewTextBoxColumn;
    }
}