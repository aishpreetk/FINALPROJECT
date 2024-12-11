using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; } = string.Empty; // Default value added
        public string Description { get; set; } = string.Empty; // Default value added
        public string Schedule { get; set; } = string.Empty; // Default value added
        public int EducatorID { get; set; }
    }

}
