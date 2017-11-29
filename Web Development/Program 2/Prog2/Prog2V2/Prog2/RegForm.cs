// Program 2
// CIS 199-01/-75
// Due: 3/6/2016
// By: Andrew L. Wright

// This application calculates the earliest registration date
// and time for an undergraduate student given their credit hours
// and last name.
// Decisions based on UofL Fall/Summer 2016 Priority Registration Schedule

// Solution 2
// This solution keeps the first letter of the last name as a char
// and uses if/else logic for the times.
// It only uses programming elements introduced in the text or
// in class.
// This solution takes advantage of the fact that there really are
// only two different time patterns used. One for juniors and seniors
// and one for sophomores and freshmen. The pattern for sophomores
// and freshmen is complicated by the fact the certain letter ranges
// get one date and other letter ranges get another date.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prog2
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void findRegTimeBtn_Click(object sender, EventArgs e)
        {
            const float SENIOR_HOURS = 90;    // Min hours for Senior
            const float JUNIOR_HOURS = 60;    // Min hours for Junior
            const float SOPHOMORE_HOURS = 30; // Min hours for Soph.

            string lastNameStr;       // Entered last name
            char lastNameLetterCh;    // First letter of last name, as char
            string dateStr = "Error"; // Holds date of registration
            string timeStr = "Error"; // Holds time of registration
            float creditHours;        // Entered credit hours

            if (float.TryParse(creditHrTxt.Text, out creditHours) && creditHours >= 0) // Valid hours?
            {
                lastNameStr = lastNameTxt.Text;
                if (lastNameStr.Length > 0) // Empty string?
                {
                    lastNameStr = lastNameStr.ToUpper(); // Ensure upper case
                    lastNameLetterCh = lastNameStr[0];   // First char of last name

                    if (char.IsLetter(lastNameLetterCh)) // Is it a letter?
                    {
                        // Juniors and Seniors share same schedule but different days
                        if (creditHours >= JUNIOR_HOURS)
                        {
                            if (creditHours >= SENIOR_HOURS)
                                dateStr = "March 30";
                            else // Must be juniors
                                dateStr = "March 31";

                            if (lastNameLetterCh <= 'D')      // A-D
                                timeStr = "4:00 PM";
                            else if (lastNameLetterCh <= 'I') // E-I
                                timeStr = "8:30 AM";
                            else if (lastNameLetterCh <= 'O') // J-O
                                timeStr = "10:00 AM";
                            else if (lastNameLetterCh <= 'S') // P-S
                                timeStr = "11:30 AM";
                            else                              // T-Z
                                timeStr = "2:00 PM";
                        }
                        // Sophomores and Freshmen
                        else // Must be soph/fresh
                        {
                            if (creditHours >= SOPHOMORE_HOURS)
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                    dateStr = "April 1";
                                else // All other letters on next day
                                    dateStr = "April 4";
                            }
                            else // must be freshman
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                    dateStr = "April 5";
                                else // All other letters on next day
                                    dateStr = "April 6";
                            }

                            if (lastNameLetterCh <= 'B')      // A-B
                                timeStr = "2:00 PM";
                            else if (lastNameLetterCh <= 'D') // C-D
                                timeStr = "4:00 PM";
                            else if (lastNameLetterCh <= 'F') // E-F
                                timeStr = "8:30 AM";
                            else if (lastNameLetterCh <= 'I') // G-I
                                timeStr = "10:00 AM";
                            else if (lastNameLetterCh <= 'L') // J-L
                                timeStr = "11:30 AM";
                            else if (lastNameLetterCh <= 'O') // M-O
                                timeStr = "2:00 PM";
                            else if (lastNameLetterCh <= 'Q') // P-Q
                                timeStr = "4:00 PM";
                            else if (lastNameLetterCh <= 'S') // R-S
                                timeStr = "8:30 AM";
                            else if (lastNameLetterCh <= 'V') // T-V
                                timeStr = "10:00 AM";
                            else                              // W-Z
                                timeStr = "11:30 AM";
                        }

                        // Output results
                        dateTimeLbl.Text = dateStr + " at " + timeStr;
                    }
                    else // First char not a letter
                        MessageBox.Show("Enter valid last name!");
                }
                else // Empty textbox
                    MessageBox.Show("Enter a last name!");
            }
            else // Can't parse credit hours
                MessageBox.Show("Please enter valid credit hours earned!");
        }
    }
}
