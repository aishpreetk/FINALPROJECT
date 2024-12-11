using CourseManagementSystem.Utilities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseManagementSystem
{
    public partial class EducatorDashboard : Form
    {
        private User currentUser;

        public EducatorDashboard(User loggedInUser)
        {
            InitializeComponent();
            currentUser = loggedInUser;
            lblWelcome.Text = $"Welcome, {currentUser.Username}!";
            LoadCourses();
        }

        // Load courses taught by the educator
        private void LoadCourses()
        {
            try
            {
                var educatorCourses = DataStore.GetCourses()
                    .Where(c => c.EducatorID == currentUser.UserID)
                    .Select(c => new
                    {
                        c.CourseID,
                        c.CourseName,
                        c.Description,
                        c.Schedule
                    }).ToList();

                dgvCourses.DataSource = educatorCourses;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading courses: {ex.Message}");
            }
        }

        // Add a new course
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            string courseName = Prompt.ShowDialog("Enter Course Name:", "Add Course") ?? string.Empty;
            string description = Prompt.ShowDialog("Enter Course Description:", "Add Course") ?? string.Empty;
            string schedule = Prompt.ShowDialog("Enter Schedule (e.g., MWF 10-11 AM):", "Add Course") ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(courseName) && !string.IsNullOrWhiteSpace(description) && !string.IsNullOrWhiteSpace(schedule))
            {
                var newCourse = new Course
                {
                    CourseName = courseName,
                    Description = description,
                    Schedule = schedule,
                    EducatorID = currentUser.UserID
                };

                DataStore.AddCourse(newCourse);
                MessageBox.Show("Course added successfully!");
                LoadCourses();
            }
            else
            {
                MessageBox.Show("All fields are required to add a course.");
            }
        }

        // Post an announcement
        private void btnPostAnnouncement_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                int selectedCourseID = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["CourseID"].Value);
                string announcementContent = Prompt.ShowDialog("Enter Announcement Content:", "Post Announcement") ?? string.Empty;

                if (!string.IsNullOrWhiteSpace(announcementContent))
                {
                    var newAnnouncement = new Announcement
                    {
                        CourseID = selectedCourseID,
                        Content = announcementContent,
                        DatePosted = DateTime.Now
                    };

                    DataStore.AddAnnouncement(newAnnouncement);
                    MessageBox.Show("Announcement posted successfully!");
                }
                else
                {
                    MessageBox.Show("Announcement content cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to post an announcement.");
            }
        }

        // View enrolled students
        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                int selectedCourseID = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["CourseID"].Value);

                var enrolledStudents = DataStore.GetEnrollments()
                    .Where(e => e.CourseID == selectedCourseID)
                    .Join(DataStore.GetUsers(), e => e.UserID, u => u.UserID, (e, u) => u)
                    .Select(u => new
                    {
                        u.UserID,
                        u.Username
                    }).ToList();

                if (enrolledStudents.Any())
                {
                    string message = string.Join("\n", enrolledStudents.Select(s => $"ID: {s.UserID}, Name: {s.Username}"));
                    MessageBox.Show(message, "Enrolled Students");
                }
                else
                {
                    MessageBox.Show("No students are enrolled in this course.");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to view enrolled students.");
            }
        }

        // Mark attendance
        private void btnGiveAttendance_Click(object sender, EventArgs e)
        {
            if (dgvCourses.SelectedRows.Count > 0)
            {
                int selectedCourseID = Convert.ToInt32(dgvCourses.SelectedRows[0].Cells["CourseID"].Value);

                // Fetch enrolled students for the selected course
                var enrolledStudents = DataStore.GetEnrollments()
                    .Where(e => e.CourseID == selectedCourseID)
                    .Join(DataStore.GetUsers(), e => e.UserID, u => u.UserID, (e, u) => u)
                    .ToList();

                if (enrolledStudents.Any())
                {
                    string studentNames = string.Join("\n", enrolledStudents.Select(s => $"{s.UserID}: {s.Username}"));
                    string input = Microsoft.VisualBasic.Interaction.InputBox($"Enrolled Students:\n{studentNames}\n\nEnter Student ID to Mark Attendance:", "Mark Attendance", "");

                    if (int.TryParse(input, out int selectedStudentID))
                    {
                        var selectedStudent = enrolledStudents.FirstOrDefault(s => s.UserID == selectedStudentID);
                        if (selectedStudent != null)
                        {
                            // Ask for attendance status
                            string status = Microsoft.VisualBasic.Interaction.InputBox("Enter Attendance Status (Present/Absent):", "Mark Attendance", "Present");

                            if (!string.IsNullOrWhiteSpace(status) && (status.ToLower() == "present" || status.ToLower() == "absent"))
                            {
                                DataStore.AddAttendance(new Attendance
                                {
                                    UserID = selectedStudent.UserID,
                                    CourseID = selectedCourseID,
                                    Status = status,
                                    Date = DateTime.Now
                                });

                                MessageBox.Show($"Attendance marked as '{status}' for {selectedStudent.Username}!", "Attendance Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Invalid status. Please enter 'Present' or 'Absent'.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Student ID.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid input. Please enter a valid Student ID.");
                    }
                }
                else
                {
                    MessageBox.Show("No students are enrolled in this course.");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to mark attendance.");
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
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Close the dashboard
            Login loginForm = new Login(); // Navigate back to login form
            loginForm.Show();
        }
    }
}
