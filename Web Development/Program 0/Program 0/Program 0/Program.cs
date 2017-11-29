//C1945
//9-22-16
//CIS200-01
//Program 0
//Design and implement a simple class hierarchy for package-delivery services.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    public class Address
    {
        const int MAX_ZIP = 99999;  //Max zip code value

        public string _name;        //Address name
        public string _address1;    //The address
        public string _address2;    //The second address
        public string _city;        //The city for address
        public string _state;       //The state for address
        public int _zip;            //The address zip

        //Precondition: zip is a 5 digit integer.
        //Postcondition: The address object has been initialized with the specified 
        //               name, address1, address2, city, state, and zip.
        public Address(string name, string address1, string address2, string city, string state, int zip)
        {
            Name = name;            //Set the name property.
            Address1 = address1;    //Set the 1st address property.
            Address2 = address2;    //Set the 2nd address property.
            City = city;            //Set the city property.
            State = state;          //Set the state property.
            Zip = zip;              //Set the zip property.
        }
        public string Name
        {
            //Precondition: None
            //Postcondition: The name has been returned.
            get
            {
                return _name;
            }
            //Precondition: The value is a string.
            //Postcondition: The name has been set to the specified value.
            set
            {
                _name = value;
            }
        }
        public string Address1
        {
            //Precondition: None
            //Postcondition: The address has been returned.
            get
            {
                return _address1;
            }
            //Precondition: The value is a string.
            //Postcondition: The address has been set to the specified value.
            set
            {
                _address1 = value;
            }
        }
        public string Address2
        {
            //Precondition: None
            //Postcondition: The address has been returned.
            get
            {
                return _address2;
            }
            //Precondition: The value is a string.
            //Postcondition: The address has been set to the specified value.
            set
            {
                _address2 = value;
            }
        }
        public string City
        {
            //Precondition: None
            //Postcondition: The city has been returned.
            get
            {
                return _city;
            }
            //Precondition: The value is a string.
            //Postcondition: The city has been set to the specified value.
            set
            {
                _city = value;
            }
        }
        public string State
        {
            //Precondition: None
            //Postcondition: The state has been returned.
            get
            {
                return _state;
            }
            //Precondition: The value is a string.
            //Postcondition: The state has been set to the specified value.
            set
            {
                _state = value;
            }
        }
        public int Zip
        {
            //Precondition: None
            //Postcondition: The zip has been returned.
            get
            {
                return _zip;
            }
            //Precondition: The value is a 5 digit integer.
            //Postcondition: The zip has been set to the specified value.
            set
            {
                if ((value >= 0) && (value <=MAX_ZIP))  //Validation
                _zip = value;
            }
        }
        //Precondition: None
        //Postcondition: A string is returned presenting the address.
        public override string ToString()
        {
            return string.Format( "{0} \n{1} \n{2} \n{3} {4} {5:D5}",
            Name, Address1, Address2, City, State, Zip );
        }

    }
}
