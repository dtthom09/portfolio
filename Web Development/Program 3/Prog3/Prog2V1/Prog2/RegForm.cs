// Program 2
// CIS 199-01/-75
// Due: 3/6/2016
// By: Andrew L. Wright

// This application calculates the earliest registration date
// and time for an undergraduate student given their credit hours
// and last name.
// Decisions based on UofL Fall/Summer 2016 Priority Registration Schedule

// Solution 1
// This solution keeps the first letter of the last name as a string
// and uses switch logic for the times.
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
            string lastNameLetterStr; // First letter of last name, as string
            string dateStr = "Error"; // Holds date of registration
            string timeStr = "Error"; // Holds time of registration
            float creditHours;        // Entered credit hours

            if (float.TryParse(creditHrTxt.Text, out creditHours) && creditHours >= 0) // Valid hours?
            {
                lastNameStr = lastNameTxt.Text;
                if (lastNameStr.Length > 0) // Empty string?
                {
                    lastNameLetterStr = lastNameStr.Substring(0, 1); // 1 letter from position 0
                    lastNameLetterStr = lastNameLetterStr.ToUpper(); // Ensure upper case

                    // Juniors and Seniors share same schedule but different days
                    if (creditHours >= JUNIOR_HOURS)
                    {
                        if (creditHours >= SENIOR_HOURS)
                            dateStr = "March 30";
                        else // Must be juniors
                            dateStr = "March 31";

                        switch (lastNameLetterStr)
                        {
                            case "A":
                            case "B":
                            case "C":
                            case "D": timeStr = "4:00 PM";
                                break;
                            case "E":
                            case "F":
                            case "G":
                            case "H":
                            case "I": timeStr = "8:30 AM";
                                break;
                            case "J":
                            case "K":
                            case "L":
                            case "M":
                            case "N":
                            case "O": timeStr = "10:00 AM";
                                break;
                            case "P":
                            case "Q":
                            case "R":
                            case "S": timeStr = "11:30 AM";
                                break;
                            case "T":
                            case "U":
                            case "V":
                            case "W":
                            case "X":
                            case "Y":
                            case "Z": timeStr = "2:00 PM";
                                break;
                        }
                    }
                    // Sophomores and Freshmen
                    else // Must be soph/fresh
                    {
                        if (creditHours >= SOPHOMORE_HOURS)
                        {
                            // E-Q on one day
                            if ((string.Compare(lastNameLetterStr, "E") >= 0) && // >= E and
                                (string.Compare(lastNameLetterStr, "Q") <= 0))   // <= Q
                                dateStr = "April 1";
                            else // All other letters on next day
                                dateStr = "April 4";
                        }
                        else // must be freshman
                        {
                            // E-Q on one day
                            if ((string.Compare(lastNameLetterStr, "E") >= 0) && // >= E and
                                (string.Compare(lastNameLetterStr, "Q") <= 0))   // <= Q
                                dateStr = "April 5";
                            else // All other letters on next day
                                dateStr = "April 6";
                        }

                        switch (lastNameLetterStr)
                        {
                            case "A":
                            case "B": timeStr = "2:00 PM";
                                break;
                            case "C":
                            case "D": timeStr = "4:00 PM";
                                break;
                            case "E":
                            case "F": timeStr = "8:30 AM";
                                break;
                            case "G":
                            case "H":
                            case "I": timeStr = "10:00 AM";
                                break;
                            case "J":
                            case "K":
                            case "L": timeStr = "11:30 AM";
                                break;
                            case "M":
                            case "N":
                            case "O": timeStr = "2:00 PM";
                                break;
                            case "P":
                            case "Q": timeStr = "4:00 PM";
                                break;
                            case "R":
                            case "S": timeStr = "8:30 AM";
                                break;
                            case "T":
                            case "U":
                            case "V": timeStr = "10:00 AM";
                                break;
                            case "W":
                            case "X":
                            case "Y":
                            case "Z": timeStr = "11:30 AM";
                                break;
                        }
                    }

                    // Output results
                    dateTimeLbl.Text = dateStr + " at " + timeStr;
                }
                else // Empty textbox
                    MessageBox.Show("Please enter last name!");
            }
            else // Can't parse credit hours
                MessageBox.Show("Please enter valid credit hours earned!");
        }
    }
}
