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
    public partial class Address_Form : Form
    {
        int zip;    //Variable to hold the zip

        //Precondition: none
        //Postcondition: The Address_Form GUI is initialized
        public Address_Form()
        {
            InitializeComponent();
        }
        internal string InputName
        {
            //Precondition: none
            //Postcondition: Text in InputName is returned
            get
            {
                return textBox_Name.Text;
            }
        }
        internal string InputAddress
        {
            //Precondition: none
            //Postcondition: Text in InputAddress is returned
            get
            {
                return textBox_Address1.Text;
            }
        }
        internal string InputAddress2
        {
            //Precondition: none
            //Postcondition: Text in InputAddress2 is returned
            get
            {
                return textBox_Address2.Text;
            }
        }
        internal string InputCity
        {
            //Precondition: none
            //Postcondition: Text in InputCity is returned
            get
            {
                return textBox_City.Text;
            }
        }
        internal string InputState
        {
            //Precondition: none
            //Postcondition: Text in InputState is returned
            get
            {
                return comboBox_State.Text;
            }
        }
        internal int InputZip
        {
            //Precondition: none
            //Postcondition: Text in InputZip is returned
            get
            {
                return zip;
            }
        }
        //Precondition: User has clicked button_AddressEnter
        //Postcondition: If all info is validated, Address Form is dismissed
        private void button_AddressEnter_Click(object sender, EventArgs e)
        {
            

            if (textBox_Name.Text.Length>0)
            {
                if (textBox_Address1.Text.Length>0)
                {
                    if (textBox_City.Text.Length>0)
                    {
                        if((textBox_Zip.Text.Length>4) && textBox_Zip.Text.Length<6)    //Checks for a 5 digit zipcode
                        {
                            if (int.TryParse(textBox_Zip.Text, out zip))
                            {
                                if (this.ValidateChildren())
                                    this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                errorProviderAddress.SetError(textBox_Zip, "Enter a valid zipcode");    //Set error message
                            }
                        }
                        else
                        {
                            errorProviderAddress.SetError(textBox_Zip, "Enter a 5 digit zipcode");  //Set error message
                        } 
                    }
                    else
                    {
                        errorProviderAddress.SetError(textBox_City, "Enter a city");    //Set error message
                    }
                }
                else
                {
                    errorProviderAddress.SetError(textBox_Address1, "Enter an address");    //Set error message
                }
            }
            else
            {
                errorProviderAddress.SetError(textBox_Name, "Enter a name");    //Set error message
            }
        }
    }
}
