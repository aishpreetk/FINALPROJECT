namespace CourseManagementSystem
{
    partial class StudentDashboard
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
            dgvEnrolledCourses = new DataGridView();
            btnViewAnnouncements = new Button();
            btnTrackAttendance = new Button();
            btnLogOut = new Button();
            btnEnrollInCourse = new Button();
            btnChangePassword = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEnrolledCourses).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(313, 51);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(71, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome";
            // 
            // dgvEnrolledCourses
            // 
            dgvEnrolledCourses.AllowUserToOrderColumns = true;
            dgvEnrolledCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEnrolledCourses.Location = new Point(148, 106);
            dgvEnrolledCourses.Name = "dgvEnrolledCourses";
            dgvEnrolledCourses.RowHeadersWidth = 51;
            dgvEnrolledCourses.Size = new Size(476, 188);
            dgvEnrolledCourses.TabIndex = 1;
            // 
            // btnViewAnnouncements
            // 
            btnViewAnnouncements.Location = new Point(112, 322);
            btnViewAnnouncements.Name = "btnViewAnnouncements";
            btnViewAnnouncements.Size = new Size(119, 29);
            btnViewAnnouncements.TabIndex = 2;
            btnViewAnnouncements.Text = "Announcements";
            btnViewAnnouncements.UseVisualStyleBackColor = true;
            btnViewAnnouncements.Click += btnViewAnnouncements_Click;
            // 
            // btnTrackAttendance
            // 
            btnTrackAttendance.Location = new Point(123, 371);
            btnTrackAttendance.Name = "btnTrackAttendance";
            btnTrackAttendance.Size = new Size(94, 29);
            btnTrackAttendance.TabIndex = 3;
            btnTrackAttendance.Text = "Attendence";
            btnTrackAttendance.UseVisualStyleBackColor = true;
            btnTrackAttendance.Click += btnTrackAttendance_Click;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(346, 409);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(94, 29);
            btnLogOut.TabIndex = 4;
            btnLogOut.Text = "logout";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnLogOut_Click;
            // 
            // btnEnrollInCourse
            // 
            btnEnrollInCourse.Location = new Point(530, 309);
            btnEnrollInCourse.Name = "btnEnrollInCourse";
            btnEnrollInCourse.Size = new Size(94, 29);
            btnEnrollInCourse.TabIndex = 5;
            btnEnrollInCourse.Text = "enrol";
            btnEnrollInCourse.UseVisualStyleBackColor = true;
            btnEnrollInCourse.Click += btnEnrollInCourse_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.Location = new Point(530, 348);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(94, 52);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = true;
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnChangePassword);
            Controls.Add(btnEnrollInCourse);
            Controls.Add(btnLogOut);
            Controls.Add(btnTrackAttendance);
            Controls.Add(btnViewAnnouncements);
            Controls.Add(dgvEnrolledCourses);
            Controls.Add(lblWelcome);
            Name = "StudentDashboard";
            Text = "StudentDashboard";
            ((System.ComponentModel.ISupportInitialize)dgvEnrolledCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private DataGridView dgvEnrolledCourses;
        private Button btnViewAnnouncements;
        private Button btnTrackAttendance;
        private Button btnLogOut;
        private Button btnEnrollInCourse;
        private Button btnChangePassword;
    }
}