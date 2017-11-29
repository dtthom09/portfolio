// Program 2
// CIS 199-01/-75
// Due: 3/6/2016
// By: Andrew L. Wright

// This application calculates the earliest registration date
// and time for an undergraduate student given their credit hours
// and last name.
// Decisions based on UofL Fall/Summer 2016 Priority Registration Schedule

// Solution 4
// This solution keeps the first letter of the last name as a char
// and uses if/else logic for the times, using ORs where possible.
// It uses defined strings for the dates and times to make it easier
// to maintain.
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

            const string DAY1 = "March 30";  // 1st day of registration
            const string DAY2 = "March 31";  // 2nd day of registration
            const string DAY3 = "April 1";   // 3rd day of registration
            const string DAY4 = "April 4";   // 4th day of registration
            const string DAY5 = "April 5";   // 5th day of registration
            const string DAY6 = "April 6";   // 6th day of registration

            const string TIME1 = "8:30 AM";  // 1st time block
            const string TIME2 = "10:00 AM"; // 2nd time block
            const string TIME3 = "11:30 AM"; // 3rd time block
            const string TIME4 = "2:00 PM";  // 4th time block
            const string TIME5 = "4:00 PM";  // 5th time block

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
                                dateStr = DAY1;
                            else // Must be juniors
                                dateStr = DAY2;

                            if (lastNameLetterCh <= 'D')      // A-D
                                timeStr = TIME5;
                            else if (lastNameLetterCh <= 'I') // E-I
                                timeStr = TIME1;
                            else if (lastNameLetterCh <= 'O') // J-O
                                timeStr = TIME2;
                            else if (lastNameLetterCh <= 'S') // P-S
                                timeStr = TIME3;
                            else                              // T-Z
                                timeStr = TIME4;
                        }
                        // Sophomores and Freshmen
                        else // Must be soph/fresh
                        {
                            if (creditHours >= SOPHOMORE_HOURS)
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                    dateStr = DAY3;
                                else // All other letters on next day
                                    dateStr = DAY4;
                            }
                            else // must be freshman
                            {
                                // E-Q on one day
                                if ((lastNameLetterCh >= 'E') && // >= E and
                                    (lastNameLetterCh <= 'Q'))   // <= Q
                                    dateStr = DAY5;
                                else // All other letters on next day
                                    dateStr = DAY6;
                            }

                            if ((lastNameLetterCh <= 'B') ||      // A-B
                                ((lastNameLetterCh >= 'M') &&
                                (lastNameLetterCh <= 'O')))       // M-O
                                timeStr = TIME4;
                            else if ((lastNameLetterCh <= 'D') || // C-D
                                ((lastNameLetterCh >= 'P') &&
                                (lastNameLetterCh <= 'Q')))       // P-Q
                                timeStr = TIME5;
                            else if ((lastNameLetterCh <= 'F') || // E-F
                                ((lastNameLetterCh >= 'R') &&
                                (lastNameLetterCh <= 'S')))       // R-S
                                timeStr = TIME1;
                            else if ((lastNameLetterCh <= 'I') || // G-I
                                ((lastNameLetterCh >= 'T') &&
                                (lastNameLetterCh <= 'V')))       // T-V
                                timeStr = TIME2;
                            else                                  // J-L, W-Z
                                timeStr = TIME3;
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
