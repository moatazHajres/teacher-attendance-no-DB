using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    public class Attendance
    {
        public String Teacher { get; set; }
        public String Course { get; set; }
        public String Room { get; set; }
        public String Date { get; set; }
        public String StartTime { get; set; }
        public String LeaveTime { get; set; }
        public String Comment { get; set; }

        public Attendance(string teacher, string course, string room, string date, string startTime, string leaveTime, string comment)
        {
            Teacher = teacher;
            Course = course;
            Room = room;
            Date = date;
            StartTime = startTime;
            LeaveTime = leaveTime;
            Comment = comment;
        }
    }
}
