using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // VALIDATION: Check for missing inputs
            if (string.IsNullOrWhiteSpace(cmbReportType.Text))
            {
                MessageBox.Show("Please select a report type before generating.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // PERFORMANCE FIX

            string reportType = cmbReportType.Text;
            string studentId = txtReportStudentId.Text;
            StringBuilder report = new StringBuilder();

            report.AppendLine("===== ULMS REPORT =====");
            report.AppendLine("Report Type: " + reportType);
            report.AppendLine("Student ID Filter: " + (string.IsNullOrWhiteSpace(studentId) ? "All Students" : studentId));
            report.AppendLine("Generated On: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            report.AppendLine(new string('-', 25));

            if (reportType == "Student Summary Report")
            {
                report.AppendLine("Student Name: [Dynamic Name]");
                report.AppendLine("Programme: Software Engineering");
                report.AppendLine("Status: Active");
            }
            else if (reportType == "Marks Report")
            {
                double s1 = 78, s2 = 65, s3 = 80;
                // Correct average calculation (Sum / Count)
                double actualAverage = (s1 + s2 + s3) / 3;

                report.AppendLine($"Subject 1: {s1}");
                report.AppendLine($"Subject 2: {s2}");
                report.AppendLine($"Subject 3: {s3}");
                report.AppendLine($"Average: {actualAverage:F2}"); 
            }
            else if (reportType == "Enrollment Report")
            {
                report.AppendLine("Course 1: Programming 1");
                report.AppendLine("Course 2: Database Systems");
                report.AppendLine("Semester: Semester 1");
            }

            txtReportOutput.Text = report.ToString();
            MessageBox.Show("Report generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = -1;
            txtReportStudentId.Clear();
            txtReportOutput.Clear();
            txtReportStudentId.Focus();
        }

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
