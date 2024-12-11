namespace CourseManagementSystem
{
    partial class EducatorDashboard
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
            lblWelcome = new Label();
            dgvCourses = new DataGridView();
            btnAddCourse = new Button();
            btnPostAnnouncement = new Button();
            btnViewStudents = new Button();
            btnLogout = new Button();
            btnGiveAttendance = new Button();
            btnChangePassword = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(319, 49);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(71, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToOrderColumns = true;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(192, 95);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.Size = new Size(356, 188);
            dgvCourses.TabIndex = 1;
            // 
            // btnAddCourse
            // 
            btnAddCourse.Location = new Point(634, 140);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(94, 29);
            btnAddCourse.TabIndex = 2;
            btnAddCourse.Text = "Add Course";
            btnAddCourse.UseVisualStyleBackColor = true;
            btnAddCourse.Click += btnAddCourse_Click;
            // 
            // btnPostAnnouncement
            // 
            btnPostAnnouncement.ImageAlign = ContentAlignment.TopLeft;
            btnPostAnnouncement.Location = new Point(12, 162);
            btnPostAnnouncement.Name = "btnPostAnnouncement";
            btnPostAnnouncement.Size = new Size(121, 60);
            btnPostAnnouncement.TabIndex = 3;
            btnPostAnnouncement.Text = "Post announcement";
            btnPostAnnouncement.UseVisualStyleBackColor = true;
            btnPostAnnouncement.Click += btnPostAnnouncement_Click;
            // 
            // btnViewStudents
            // 
            btnViewStudents.Location = new Point(24, 257);
            btnViewStudents.Name = "btnViewStudents";
            btnViewStudents.Size = new Size(94, 55);
            btnViewStudents.TabIndex = 4;
            btnViewStudents.Text = "View Students";
            btnViewStudents.UseVisualStyleBackColor = true;
            btnViewStudents.Click += btnViewStudents_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(634, 270);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnGiveAttendance
            // 
            btnGiveAttendance.Location = new Point(634, 209);
            btnGiveAttendance.Name = "btnGiveAttendance";
            btnGiveAttendance.Size = new Size(94, 29);
            btnGiveAttendance.TabIndex = 6;
            btnGiveAttendance.Text = "Attendence";
            btnGiveAttendance.UseVisualStyleBackColor = true;
            btnGiveAttendance.Click += btnGiveAttendance_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(24, 79);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(94, 57);
            btnChangePassword.TabIndex = 7;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // EducatorDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnChangePassword);
            Controls.Add(btnGiveAttendance);
            Controls.Add(btnLogout);
            Controls.Add(btnViewStudents);
            Controls.Add(btnPostAnnouncement);
            Controls.Add(btnAddCourse);
            Controls.Add(dgvCourses);
            Controls.Add(lblWelcome);
            Name = "EducatorDashboard";
            Text = "EducatorDashboard";
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private DataGridView dgvCourses;
        private Button btnAddCourse;
        private Button btnPostAnnouncement;
        private Button btnViewStudents;
        private Button btnLogout;
        private Button btnGiveAttendance;
        private Button btnChangePassword;
    }
}