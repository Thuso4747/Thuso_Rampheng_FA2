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
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            // Initialize the record object to store data
            MarkRecord record = new MarkRecord();

            try
            {
                //DATA CAPTURE
                record.StudentId = txtMarkStudentId.Text;
                record.StudentName = txtMarkStudentName.Text;

                //INPUT VALIDATION (Handling Missing Data)
                if (string.IsNullOrWhiteSpace(txtSubject1.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject2.Text) ||
                    string.IsNullOrWhiteSpace(txtSubject3.Text))
                {
                    MessageBox.Show("Please ensure all subject marks are entered.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //NUMERIC CONVERSION
                record.Subject1 = Convert.ToDouble(txtSubject1.Text);
                record.Subject2 = Convert.ToDouble(txtSubject2.Text);
                record.Subject3 = Convert.ToDouble(txtSubject3.Text);

                // MARKS BOUNDARY VALIDATION (0 - 100)
                if (record.Subject1 < 0 || record.Subject1 > 100 ||
                    record.Subject2 < 0 || record.Subject2 > 100 ||
                    record.Subject3 < 0 || record.Subject3 > 100)
                {
                    MessageBox.Show("Marks must be between 0 and 100.", "Boundary Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //CORRECT CALCULATION (BODMAS/PEMDAS)
                record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;

                // Rounding to 2 decimal places for professional output 
                record.Average = Math.Round(record.Average, 2);

                //RESULT STATUS LOGIC
                if (record.Average >= 50)
                {
                    record.ResultStatus = "PASS";
                }
                else
                {
                    record.ResultStatus = "FAIL";
                }

                // OUTPUT DISPLAY
                txtMarksOutput.Text =
                    "Marks processed successfully!" + Environment.NewLine +
                    "Student ID: " + record.StudentId + Environment.NewLine +
                    "Student Name: " + record.StudentName + Environment.NewLine +
                    "Subject 1: " + record.Subject1 + Environment.NewLine +
                    "Subject 2: " + record.Subject2 + Environment.NewLine +
                    "Subject 3: " + record.Subject3 + Environment.NewLine +
                    "Average: " + record.Average.ToString("F2") + Environment.NewLine +
                    "Final Result: " + record.ResultStatus;
            }
            catch (FormatException)
            {
                // Handle non-numeric input 
                MessageBox.Show("Please enter a numeric value for all marks.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // General safety net for unexpected runtime issues
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
