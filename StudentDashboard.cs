using CourseManagementSystem.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseManagementSystem
{
    public partial class StudentDashboard : Form
    {
        private User currentUser;

        public StudentDashboard(User loggedInUser)
        {
            InitializeComponent();
            currentUser = loggedInUser;
            lblWelcome.Text = $"Welcome, {currentUser.Username}!";
            LoadEnrolledCourses();
        }

        // Load enrolled courses into the DataGridView
        private void LoadEnrolledCourses()
        {
            try
            {
                var enrollments = DataStore.GetEnrollments();
                var courses = DataStore.GetCourses();

                var enrolledCourses = enrollments
                    .Where(e => e.UserID == currentUser.UserID)
                    .Join(courses, e => e.CourseID, c => c.CourseID, (e, c) => new
                    {
                        c.CourseID,
                        c.CourseName,
                        c.Description,
                        c.Schedule
                    })
                    .ToList();

                dgvEnrolledCourses.DataSource = enrolledCourses;
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // View Announcements
        private void btnViewAnnouncements_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEnrolledCourses.SelectedRows.Count > 0)
                {
                    int selectedCourseID = Convert.ToInt32(dgvEnrolledCourses.SelectedRows[0].Cells["CourseID"].Value);
                    var announcements = DataStore.GetAnnouncements()
                        .Where(a => a.CourseID == selectedCourseID)
                        .Select(a => $"{a.Content} (Posted on: {a.DatePosted})")
                        .ToList();

                    if (announcements.Any())
                    {
                        string message = string.Join("\n", announcements);
                        MessageBox.Show(message, "Announcements");
                    }
                    else
                    {
                        MessageBox.Show("No announcements available for the selected course.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a course to view announcements.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading announcements: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Track Attendance
        private void btnTrackAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEnrolledCourses.SelectedRows.Count > 0)
                {
                    int selectedCourseID = Convert.ToInt32(dgvEnrolledCourses.SelectedRows[0].Cells["CourseID"].Value);
                    var attendanceRecords = DataStore.GetAttendance()
                        .Where(a => a.UserID == currentUser.UserID && a.CourseID == selectedCourseID)
                        .Select(a => $"{a.Date}: {a.Status}")
                        .ToList();

                    if (attendanceRecords.Any())
                    {
                        string message = string.Join("\n", attendanceRecords);
                        MessageBox.Show(message, "Attendance Records");
                    }
                    else
                    {
                        MessageBox.Show("No attendance records available for the selected course.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a course to view attendance.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendance: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Enroll in a Course
        private void btnEnrollInCourse_Click(object sender, EventArgs e)
        {
            try
            {
                var courses = DataStore.GetCourses();

                // Filter courses that the student is not already enrolled in
                var enrollments = DataStore.GetEnrollments().Where(e => e.UserID == currentUser.UserID).Select(e => e.CourseID).ToList();
                var availableCourses = courses.Where(c => !enrollments.Contains(c.CourseID)).ToList();

                if (availableCourses.Any())
                {
                    // Prompt the student to select a course
                    string courseNames = string.Join("\n", availableCourses.Select(c => $"{c.CourseID}: {c.CourseName}"));
                    string input = Microsoft.VisualBasic.Interaction.InputBox($"Available Courses:\n{courseNames}\n\nEnter Course ID to Enroll:", "Enroll in Course", "");

                    if (int.TryParse(input, out int selectedCourseID))
                    {
                        var selectedCourse = availableCourses.FirstOrDefault(c => c.CourseID == selectedCourseID);
                        if (selectedCourse != null)
                        {
                            // Enroll the student in the selected course
                            DataStore.AddEnrollment(new Enrollment
                            {
                                UserID = currentUser.UserID,
                                CourseID = selectedCourseID,
                                EnrollmentDate = DateTime.Now
                            });

                            MessageBox.Show($"Successfully enrolled in {selectedCourse.CourseName}!", "Enrollment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEnrolledCourses(); // Refresh enrolled courses
                        }
                        else
                        {
                            MessageBox.Show("Invalid Course ID. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid Course ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No courses available for enrollment.", "No Courses Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                // Prompt for the current password
                string currentPassword = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter your current password:", "Change Password", "", -1, -1)?.Trim();

                // Validate the current password
                if (string.IsNullOrWhiteSpace(currentPassword) || currentPassword != currentUser.Password)
                {
                    MessageBox.Show("Incorrect current password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Prompt for the new password
                string newPassword = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter your new password:", "Change Password", "", -1, -1)?.Trim();

                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                {
                    MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Prompt for password confirmation
                string confirmPassword = Microsoft.VisualBasic.Interaction.InputBox(
                    "Confirm your new password:", "Change Password", "", -1, -1)?.Trim();

                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the password in the database
                DataStore.UpdatePassword(currentUser.UserID, newPassword);

                // Update the currentUser object with the new password
                currentUser.Password = newPassword;

                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Logout
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                Login loginForm = new Login();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
