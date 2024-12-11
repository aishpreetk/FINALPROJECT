using CourseManagementSystem.Models;

namespace CourseManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Fetch users from the database
            var users = DataStore.GetUsers();

            // Validate user credentials
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Role}!");

                // Navigate to appropriate dashboard
                if (user.Role == "Educator")
                {
                    this.Hide(); // Hides the login form
                    var educatorDashboard = new EducatorDashboard(user);
                    educatorDashboard.Show(); // Ensure this line exists
                }
                else if (user.Role == "student")
                {
                    this.Hide();
                    var studentDashboard = new StudentDashboard(user);
                    studentDashboard.Show(); // Ensure this line exists
                }


                else if (user.Role == "Admin")
                {
                    var adminDashboard = new Admin(user);
                    adminDashboard.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }
    }
}
