using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CourseManagementSystem;

namespace CourseManagementSystem
{
    public partial class Admin : Form
    {
        public Admin(User user)
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {user.Username}";
            LoadUsers();
            LoadCourses();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            btnAddUser.Click += BtnAddUser_Click;
            btnEditUser.Click += BtnEditUser_Click;
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnViewEnrollments.Click += btnViewEnrollments_Click;


        }

        private void BtnAddUser_Click(object? sender, EventArgs e)
        {
            // Collect username
            string username = Microsoft.VisualBasic.Interaction.InputBox("Enter Username:", "Add User", string.Empty, -1, -1)?.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.");
                return;
            }

            // Collect role
            string role = Microsoft.VisualBasic.Interaction.InputBox("Enter Role:", "Add User", string.Empty, -1, -1)?.Trim();
            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Role cannot be empty.");
                return;
            }

            try
            {
                // Add user directly via SQL
                DataStore.AddUser(new User
                {
                    Username = username,
                    Role = role,
                    Password = "default123" // Example default password
                });
                MessageBox.Show("User added successfully.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditUser_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to edit.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

            // Prompt for new username
            string username = Microsoft.VisualBasic.Interaction.InputBox("Enter new Username:", "Edit User", dgvUsers.SelectedRows[0].Cells["Username"].Value?.ToString() ?? string.Empty, -1, -1)?.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username cannot be empty.");
                return;
            }

            // Prompt for new role
            string role = Microsoft.VisualBasic.Interaction.InputBox("Enter new Role:", "Edit User", dgvUsers.SelectedRows[0].Cells["Role"].Value?.ToString() ?? string.Empty, -1, -1)?.Trim();
            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Role cannot be empty.");
                return;
            }

            try
            {
                DataStore.UpdateUser(new User
                {
                    UserID = userId,
                    Username = username,
                    Role = role
                });
                MessageBox.Show("User updated successfully.");
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeleteUser_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            string username = dgvUsers.SelectedRows[0].Cells["Username"].Value?.ToString() ?? "Unknown User";

            if (MessageBox.Show($"Are you sure you want to delete {username}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DataStore.DeleteUser(userId);
                    MessageBox.Show("User deleted successfully.");
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadCourses()
        {
            try
            {
                var courses = DataStore.GetCourses();
                dgvCourses.DataSource = courses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUsers()
        {
            try
            {
                dgvUsers.DataSource = DataStore.GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                // Close the current form
                this.Hide(); // Hide instead of Close to ensure smooth transition

                // Open the login form
                Login loginForm = new Login();
                loginForm.ShowDialog(); // Use ShowDialog for a modal login window
                this.Close(); // Close the admin form completely after login is displayed
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEnrollments()
        {
            try
            {
                var enrollments = DataStore.GetEnrollments(); // Fetch enrollments from the database
                var users = DataStore.GetUsers(); // Fetch user details
                var courses = DataStore.GetCourses(); // Fetch course details

                // Join enrollments with users and courses for display
                var enrollmentDetails = enrollments
                    .Join(users, e => e.UserID, u => u.UserID, (e, u) => new { e.CourseID, u.UserID, u.Username })
                    .Join(courses, e => e.CourseID, c => c.CourseID, (e, c) => new
                    {
                        c.CourseID,
                        c.CourseName,
                        c.Description,
                        c.Schedule,
                        e.UserID,
                        e.Username
                    })
                    .ToList();

                dgvCourses.DataSource = enrollmentDetails; // Bind the result to the grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading enrollments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnViewEnrollments_Click(object sender, EventArgs e)
        {
            LoadEnrollments();
        }



    }
}
