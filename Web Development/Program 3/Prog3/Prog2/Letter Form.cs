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
    public partial class Letter_Form : Form
    {
        private UserParcelView userParcel;

        //Precondition:  None
        //Postcondition: The Letter_Form GUI is initialized
        public Letter_Form(UserParcelView upv)
        {
            InitializeComponent();
            userParcel = upv;
            //For each orig address and dest address, display the name in the combobox.
            foreach (Address a in userParcel.addresses)
            {
                comboBox_Origin.Items.Add(a.Name);
                comboBox_Dest.Items.Add(a.Name);
            }
        }
        decimal fixedCost = 0.00M;  //Variable to hold the fixed cost
        internal Address OrigAddress
        {
            //Precondition: none
            //Postcondition: Text in OrigAddress is returned 
            get
            {
                return userParcel.AddressAt(comboBox_Origin.SelectedIndex);
            }
        }
        internal Address DestAddress
        {
            //Precondition: none
            //Postcondition: Text in DestAddress is returned
            get
            {
                return userParcel.AddressAt(comboBox_Dest.SelectedIndex);
            }
        }
        internal decimal FixedCost
        {
            //Precondition: none
            //Postcondition: Text in FixedCost is returned
            get
            {
                return fixedCost;
            }
        }
        //Precondition: User has clicked buttonOK
        //Postcondition: If all info is validated, Letter Form is dismissed
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBox_Origin.SelectedIndex >=0)
            {
                if ((comboBox_Dest.SelectedIndex >=0) && comboBox_Origin.SelectedItem != comboBox_Dest.SelectedItem)    //Making sure orig address and dest address are different.
                {
                    if ((decimal.TryParse(textBox_Fixed.Text, out fixedCost))  && fixedCost>0)  //Fixed cost has to be a positive number.
                    {
                        if (this.ValidateChildren())
                            this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        errorProvider_Letter.SetError(textBox_Fixed, "Enter a positive decimal number");    //Set error message
                    }
                }
                else
                {
                    errorProvider_Letter.SetError(comboBox_Dest, "Select a valid destination address"); //Set error message
                }
            }
            else
            {
                errorProvider_Letter.SetError(comboBox_Origin, "Select a origin address");  //Set error message
            }
        }
    }
}
