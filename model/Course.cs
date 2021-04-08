using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class Course
    {
        private int courseid;
        private String coursename;

        public Course(int courseid, String coursename)
        {
            this.courseid = courseid;
            this.coursename = coursename;
        }

        public int CourseId
        {
            set
            {
                courseid = value;
            }
            get
            {
                return this.courseid;
            }

        }

        public String CourseName
        {
            set
            {
                coursename = value;
            }
            get
            {
                return this.coursename;
            }

        }
    }
}
