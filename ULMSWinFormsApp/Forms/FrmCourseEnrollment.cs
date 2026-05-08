using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmCourseEnrollment : Form
    {
        public FrmCourseEnrollment()
        {
            InitializeComponent();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            // VALIDATION: Ensure no fields are empty
            if (string.IsNullOrWhiteSpace(txtEnrollStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtEnrollStudentName.Text) ||
                string.IsNullOrWhiteSpace(cmbCourse.Text) ||
                string.IsNullOrWhiteSpace(cmbSemester.Text))
            {
                MessageBox.Show("All fields are required for enrollment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stops the enrollment from proceeding
            }

            // DATA CAPTURE
            Enrollment enrollment = new Enrollment
            {
                StudentId = txtEnrollStudentId.Text.Trim(),
                StudentName = txtEnrollStudentName.Text.Trim(),
                CourseName = cmbCourse.Text,
                Semester = cmbSemester.Text
            };

            // SUCCESS FEEDBACK
            MessageBox.Show("Student enrolled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // OUTPUT DISPLAY
            txtEnrollmentOutput.Text =
                "Enrollment completed successfully!" + Environment.NewLine +
                "Student ID: " + enrollment.StudentId + Environment.NewLine +
                "Student Name: " + enrollment.StudentName + Environment.NewLine +
                "Course: " + enrollment.CourseName + Environment.NewLine +
                "Semester: " + enrollment.Semester;
        }

        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            txtEnrollStudentId.Clear();
            txtEnrollStudentName.Clear();
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtEnrollmentOutput.Clear();
            txtEnrollStudentId.Focus();
        }

        private void btnBackEnrollment_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
