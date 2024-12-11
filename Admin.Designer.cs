using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseManagementSystem
{
    partial class Admin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            dgvCourses = new DataGridView();
            dgvUsers = new DataGridView();
            btnAddUser = new Button();
            btnEditUser = new Button();
            btnDeleteUser = new Button();
            btnViewEnrollments = new Button();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F);
            lblWelcome.Location = new Point(320, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(156, 28);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome Admin";
            // 
            // dgvCourses
            // 
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.Location = new Point(30, 70);
            dgvCourses.Name = "dgvCourses";
            dgvCourses.RowHeadersWidth = 51;
            dgvCourses.Size = new Size(340, 200);
            dgvCourses.TabIndex = 1;
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(420, 70);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.Size = new Size(340, 200);
            dgvUsers.TabIndex = 2;
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(50, 300);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(120, 35);
            btnAddUser.TabIndex = 3;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(50, 350);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(120, 35);
            btnEditUser.TabIndex = 4;
            btnEditUser.Text = "Edit User";
            btnEditUser.UseVisualStyleBackColor = true;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(50, 400);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(120, 35);
            btnDeleteUser.TabIndex = 5;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // btnViewEnrollments
            // 
            btnViewEnrollments.Location = new Point(550, 300);
            btnViewEnrollments.Name = "btnViewEnrollments";
            btnViewEnrollments.Size = new Size(140, 40);
            btnViewEnrollments.TabIndex = 6;
            btnViewEnrollments.Text = "View Enrollments";
            btnViewEnrollments.UseVisualStyleBackColor = true;
            btnViewEnrollments.Click += btnViewEnrollments_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(550, 360);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 40);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWelcome);
            Controls.Add(dgvCourses);
            Controls.Add(dgvUsers);
            Controls.Add(btnAddUser);
            Controls.Add(btnEditUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnViewEnrollments);
            Controls.Add(btnLogout);
            Name = "Admin";
            Text = "Admin";
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private DataGridView dgvCourses;
        private DataGridView dgvUsers;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnDeleteUser;
        private Button btnViewEnrollments;
        private Button btnLogout;
    }
}
