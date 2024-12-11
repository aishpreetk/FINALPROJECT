using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementSystem
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public int CourseID { get; set; }
        public string Content { get; set; } = string.Empty; // Default value added
        public DateTime DatePosted { get; set; }
    }

}
