using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv;
        
        public Prog2Form()
        {
            InitializeComponent();

            upv = new UserParcelView();
            
            // Test Data - Magic Numbers OK
            upv.AddAddress("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            upv.AddAddress("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            upv.AddAddress("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            upv.AddAddress("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            upv.AddAddress("Ryan Leezer", "666 Spring St", "",
                "New York CIty", "NY", 37219);    //Test Address 5
            upv.AddAddress("Jessica Lewis", "100 7th St", "",
                "Tampa", "FL", 57611);  //Test Address 6
            upv.AddAddress("Mark Hunt", "123 11th St", "Apt. 2",
                "Phoenix", "AZ", 21399);    //Test Address 7
            upv.AddAddress("Mary Gates", "2838 W Jefferson St", "",
                "Atlanta", "GA", 18042);    //Test Address 8

            upv.AddLetter(upv.AddressAt(0), upv.AddressAt(1), 3.55M);   //Letter 
            upv.AddLetter(upv.AddressAt(2), upv.AddressAt(4), 4.20M);   //Letter 2
            upv.AddLetter(upv.AddressAt(3), upv.AddressAt(6), 5.35M);   //Letter 3
        }

        //Precondition: The exit item on the menu has been clicked.
        //Postcondition: The application has been closed.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Precondition: The about item on the menu has been clicked.
        //Postcondition: Student && programs information has been displayed.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C1945\r\nCIS 200-01\r\nDue:Nov 1,2016\r\nProg2");
        }

        //Precondition: The address item on the insert menu has been clicked.
        //Postcondition: A dialog box has been displayed requesting address info.
        //               If sumitted, an address object is stored in the Address list.
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Address_Form addressForm = new Address_Form();  //Address dialog box form
            DialogResult result;                            //Result from dialog box

            result = addressForm.ShowDialog();              //Show dialog box form

            if (result == DialogResult.OK)                  //Update if user clicks OK form dialog box
            {
                upv.AddAddress(addressForm.InputName, addressForm.InputAddress, addressForm.InputAddress2,
                    addressForm.InputCity, addressForm.InputState, addressForm.InputZip);
            }
        }
        
        //Precondition: List addresses item clicked from menu.
        //Postcondition: The addresses have been displayed in the Prog2Form's text box.
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxMain.Text = String.Join("\r\n\r\n", upv.addresses);
        }

        //Precondition: List letters item clicked from menu.
        //Postcondition: The letters have been displayed in the Prog2Form's text box.
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBoxMain.Text = string.Join("\r\n\r\n", upv.parcels);
        }

        //Precondition: The letter item on the insert menu has been clicked.
        //Postcondition: A dialog box has been displayed requesting letter info.
        //               If sumitted, a letter object is stored in the Parcel list.
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Letter_Form letterForm = new Letter_Form(upv); //Letter dialog box form
            DialogResult result;                        //Result from dialog box

            result = letterForm.ShowDialog();           //Show dialog box form

            if (result == DialogResult.OK)              //Update if user clicks OK form dialog box
            {
                upv.AddLetter(letterForm.OrigAddress, letterForm.DestAddress, letterForm.FixedCost);
            }
        }
    }
}
