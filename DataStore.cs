using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace CourseManagementSystem
{
    public static class DataStore
    {
        // Connection string for the database
        private static readonly string connectionString = "Server=YUVIKASLAPTOP\\SQLEX_YUVIKA; Database=CourseManagement; User Id=Yuvika; Password=123; TrustServerCertificate=True;";


        // Fetch all users from the database
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT UserID, Username, Password, Role FROM Users";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserID = (int)reader["UserID"],
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = reader["Role"].ToString()
                            });
                        }
                    }
                }
            }

            return users;
        }

        // Fetch all courses from the database
        public static List<Course> GetCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT CourseID, CourseName, Description, Schedule, EducatorID FROM Courses";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Course
                            {
                                CourseID = (int)reader["CourseID"],
                                CourseName = reader["CourseName"].ToString(),
                                Description = reader["Description"].ToString(),
                                Schedule = reader["Schedule"].ToString(),
                                EducatorID = (int)reader["EducatorID"]
                            });
                        }
                    }
                }
            }

            return courses;
        }

        // Fetch all announcements from the database
        public static List<Announcement> GetAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT AnnouncementID, CourseID, Title, Content, CreatedDate FROM Announcements";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            announcements.Add(new Announcement
                            {
                                AnnouncementID = (int)reader["AnnouncementID"],
                                CourseID = (int)reader["CourseID"],
                                                                Content = reader["Content"].ToString(),
                               
                            });
                        }
                    }
                }
            }

            return announcements;
        }

        // Fetch all enrollments from the database
        public static List<Enrollment> GetEnrollments()
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT EnrollmentID, UserID, CourseID, EnrollmentDate FROM Enrollments";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            enrollments.Add(new Enrollment
                            {
                                EnrollmentID = (int)reader["EnrollmentID"],
                                UserID = (int)reader["UserID"],
                                CourseID = (int)reader["CourseID"],
                                
                            });
                        }
                    }
                }
            }

            return enrollments;
        }

        // Fetch all attendance records (if needed)
        public static List<Attendance> GetAttendance()
        {
            var attendanceRecords = new List<Attendance>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT AttendanceID, UserID, CourseID, Status, Date FROM Attendance", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        attendanceRecords.Add(new Attendance
                        {
                            AttendanceID = (int)reader["AttendanceID"],
                            UserID = (int)reader["UserID"],
                            CourseID = (int)reader["CourseID"],
                            Status = reader["Status"].ToString(),
                            Date = (DateTime)reader["Date"]
                        });
                    }
                }
            }
            return attendanceRecords;
        }

        public static void AddUser(User user)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, @Role)", conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdateUser(User user)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Users SET Username = @Username, Role = @Role WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@UserID", user.UserID);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteUser(int userId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.ExecuteNonQuery();
            }
        }
        public static void AddCourse(Course course)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Courses (CourseName, Description, Schedule, EducatorID) VALUES (@CourseName, @Description, @Schedule, @EducatorID)", conn);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@Schedule", course.Schedule);
                cmd.Parameters.AddWithValue("@EducatorID", course.EducatorID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddAnnouncement(Announcement announcement)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Announcements (CourseID, Content, CreatedDate) VALUES (@CourseID, @Content, @CreatedDate)", conn);
                cmd.Parameters.AddWithValue("@CourseID", announcement.CourseID);
                cmd.Parameters.AddWithValue("@Content", announcement.Content);
                cmd.Parameters.AddWithValue("@CreatedDate", announcement.DatePosted);
                cmd.ExecuteNonQuery();
            }
        }
        public static void AddEnrollment(Enrollment enrollment)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Enrollments (UserID, CourseID, EnrollmentDate) VALUES (@UserID, @CourseID, @EnrollmentDate)", conn);
                cmd.Parameters.AddWithValue("@UserID", enrollment.UserID);
                cmd.Parameters.AddWithValue("@CourseID", enrollment.CourseID);
                cmd.Parameters.AddWithValue("@EnrollmentDate", enrollment.EnrollmentDate ?? DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        public static void AddAttendance(Attendance attendance)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Attendance (UserID, CourseID, Status, Date) VALUES (@UserID, @CourseID, @Status, @Date)", conn);
                cmd.Parameters.AddWithValue("@UserID", attendance.UserID);
                cmd.Parameters.AddWithValue("@CourseID", attendance.CourseID);
                cmd.Parameters.AddWithValue("@Status", attendance.Status);
                cmd.Parameters.AddWithValue("@Date", attendance.Date);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UpdatePassword(int userId, string newPassword)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // SQL command to update the password
                var cmd = new SqlCommand("UPDATE Users SET Password = @Password WHERE UserID = @UserID", conn);
                cmd.Parameters.AddWithValue("@Password", newPassword);
                cmd.Parameters.AddWithValue("@UserID", userId);

                cmd.ExecuteNonQuery();
            }
        }






    }
}
