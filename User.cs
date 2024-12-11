using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; } = string.Empty; // Default value added
        public string Password { get; set; } = string.Empty; // Default value added
        public string Role { get; set; } = string.Empty; // Default value added
    }


}
