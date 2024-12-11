using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public int UserID { get; set; }
        public int CourseID { get; set; }
        public DateTime Date { get; set; }

        public string Status { get; set; }
    }

}
