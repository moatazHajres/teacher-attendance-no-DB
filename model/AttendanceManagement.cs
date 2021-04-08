using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class AttendanceManagement
    {
        private List<Course> courses;
        private List<Teacher> teachers;
        private List<Room> rooms;
        public List<Attendance> attendances;
        private static AttendanceManagement attendance = null;

        private AttendanceManagement()
        {
            courses = new List<Course>();
            teachers = new List<Teacher>();
            rooms = new List<Room>();
            attendances = new List<Attendance>();
        }

        public static AttendanceManagement SingletonInstance()
        {
            if(attendance == null)
            {
                attendance = new AttendanceManagement();
            }

            return attendance;
        }

        public void addNewCourse(String CoursName)
        {
            courses.Add(new Course(courses.Count + 1, CoursName));
        }

        public List<Course> getAllCourses()
        {
            List<Course> temp;

            temp = courses.GetRange(0, courses.Count);

            temp.Add(new Course(0, "Add new course..."));

            return temp;

        }

        public void addNewTeacher(String TeacherName)
        {
            teachers.Add(new Teacher(teachers.Count + 1, TeacherName));
        }

        public List<Teacher> getAllTeachers()
        {
            List<Teacher> temp;

            temp = teachers.GetRange(0, teachers.Count);

            temp.Add(new Teacher(0, "Add new course..."));

            return temp;

        }

        public void addTeacher(String TeacherName)
        {
            teachers.Add(new Teacher(teachers.Count + 1, TeacherName));
        }


        public void addNewRoom(String RoomName)
        {
            rooms.Add(new Room(rooms.Count + 1, RoomName));
        }

        public List<Room> getAllRooms()
        {
            List<Room> temp;

            temp = rooms.GetRange(0, rooms.Count);

            temp.Add(new Room(0, "Add new room/lab..."));

            return temp;

        }

        public void saveAttendance(String teacher, String course, String room, String date, String startTime, String leaveTime, String comment)
        {
            attendances.Insert(0, new Attendance(teacher, course, room, date, startTime, leaveTime, comment));
        }

        public List<Attendance> GetAttendances()
        {
            return this.attendances;
        }

        public void AddEmptyRecord()
        {
            attendances.Add(new Attendance("", "", "", "", "", "", ""));
        }

    }





}
