using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    public abstract class Parcel
    {
        public Address OriginAddress
        {
            //Precondition: address is filled out
            //Postcondition: The origin address is returned
            get;
            //Precondition: address is filled out
            //Postcondition: The origin address is set to the specified value
            set;
        }
        public Address DestinationAddress
        {
            //Precondition: address is filled out
            //Postcondition: The destination address is returned
            get;
            //Precondition: address is filled out
            //Postcondition: The destination address is set to the specified value
            set;
        }
        //Precondition: The address is filled out
        //Postcondition: The values are initialized for the parcel
        public Parcel(Address origin, Address destination)
        {
            OriginAddress = origin;             //Set the origin property
            DestinationAddress = destination;   //Set the destination property
        }
        //Precondition: none
        //Postcondition: The cost is returned
        public abstract decimal CalcCost();

        //Precondition: none
        //Postcondition: A string is returned displaying the details of the address.
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
