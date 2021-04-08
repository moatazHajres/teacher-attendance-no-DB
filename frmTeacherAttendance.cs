using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherAttendance.helper;
using TeacherAttendance.model;

namespace TeacherAttendance
{
    public partial class frmTeacherAttendance : Form
    {
        private AttendanceManagement attendance;
        BindingList<Attendance> source;
        private int selectedRowIndex;
        public frmTeacherAttendance()
        {
            InitializeComponent();
        }

        private void FrmTeacherAttendance_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            selectedRowIndex = -1;
            attendance = AttendanceManagement.SingletonInstance();
            attendance.AddEmptyRecord();
            source = new BindingList<Attendance>(attendance.GetAttendances());
            dataGridView1.DataSource = source;
            ShowCourses();
            ShowTeachers();
            ShowRooms();
        }

        /*private void CmbCourses_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }*/

        private void ShowCourses()
        {
            cmbCourses.DataSource = null;
            cmbCourses.DisplayMember = "CourseName";
            cmbCourses.ValueMember = "CourseId";
            cmbCourses.DataSource = attendance.getAllCourses();
            cmbCourses.SelectedIndex = -1;
        }

        private void ShowTeachers()
        {
            cmbTeacherName.DataSource = null;
            cmbTeacherName.DisplayMember = "TeacherName";
            cmbTeacherName.ValueMember = "TeacherId";
            cmbTeacherName.DataSource = attendance.getAllTeachers();
            cmbTeacherName.SelectedIndex = -1;

        }

        private void ShowRooms()
        {
            cmbRoom.DataSource = null;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
            cmbRoom.DataSource = attendance.getAllRooms();
            cmbRoom.SelectedIndex = -1;

        }
        private void CmbCourses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            

            string value = "";
            

            int id = ((Course)((ComboBox)sender).SelectedItem).CourseId;

            if(id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New course", "New course name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewCourse(value.Trim());
                    ShowCourses();
                }


            }
        }

        private void CmbTeacherName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string value = "";

            int id = ((Teacher)((ComboBox)sender).SelectedItem).TeacherId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New teacher", "New teacher name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewTeacher(value.Trim());
                    ShowTeachers();
                }


            }


        }

        private void CmbRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string value = "";

            int id = ((Room)((ComboBox)sender).SelectedItem).RoomId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New Room/Lab", "New Room/Lab name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewRoom(value.Trim());
                    ShowRooms();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cmbRoom.SelectedIndex == -1 || cmbCourses.SelectedIndex == -1 || cmbTeacherName.SelectedIndex == -1)
            {
                MessageBox.Show("Please check your inputs");

                return;
            }

            attendance.saveAttendance(cmbTeacherName.Text, cmbCourses.Text, cmbRoom.Text, dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, textBox2.Text);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = source;
            resetFields();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selectedRowIndex = e.RowIndex;
                btnUpdate.Enabled = true;
                cmbTeacherName.Text = dataGridView1.Rows[e.RowIndex].Cells["Teacher"].Value.ToString();
                cmbCourses.Text = dataGridView1.Rows[e.RowIndex].Cells["Course"].Value.ToString();
                cmbRoom.Text = dataGridView1.Rows[e.RowIndex].Cells["Room"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells["StartTime"].Value.ToString();
                dateTimePicker3.Text = dataGridView1.Rows[e.RowIndex].Cells["LeaveTime"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Comment"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[selectedRowIndex].Cells["Teacher"].Value = cmbTeacherName.Text;
            dataGridView1.Rows[selectedRowIndex].Cells["Course"].Value = cmbCourses.Text;
            dataGridView1.Rows[selectedRowIndex].Cells["Room"].Value = cmbRoom.Text;
            dataGridView1.Rows[selectedRowIndex].Cells["Date"].Value = dateTimePicker1.Text;
            dataGridView1.Rows[selectedRowIndex].Cells["StartTime"].Value = dateTimePicker2.Text;
            dataGridView1.Rows[selectedRowIndex].Cells["LeaveTime"].Value = dateTimePicker3.Text;
            dataGridView1.Rows[selectedRowIndex].Cells["Comment"].Value = textBox2.Text;

            MessageBox.Show("Data Updated Successfully !");
            btnUpdate.Enabled = false;
            selectedRowIndex = -1;
            resetFields();
        }

        public void resetFields()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctrl).Clear();

                } else if (ctrl.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;
                }
            }
        }
    }
}
