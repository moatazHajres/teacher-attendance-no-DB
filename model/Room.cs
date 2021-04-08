using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class Room
    {

        private int roomid;
        private String roomname;

        public Room(int roomid, String roomname)
        {
            this.roomid = roomid;
            this.roomname = roomname;
        }

        public int RoomId
        {
            set
            {
                roomid = value;
            }
            get
            {
                return this.roomid;
            }

        }

        public String RoomName
        {
            set
            {
                roomname = value;
            }
            get
            {
                return this.roomname;
            }

        }
    }

}

