using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class Teacher
    {

        private int teacherid;
        private String teachername;

        public Teacher(int teacherid, String teachername)
        {
            this.teacherid = teacherid;
            this.teachername = teachername;
        }

        public int TeacherId
        {
            set
            {
                teacherid = value;
            }
            get
            {
                return this.teacherid;
            }

        }

        public String TeacherName
        {
            set
            {
                teachername = value;
            }
            get
            {
                return this.teachername;
            }

        }
    }
}
