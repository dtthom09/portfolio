using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    public class Letter : Parcel
    {
        private decimal _fixedCost;     //fixed cost variable

        //Precondition: the address is filled out
        //Postcondition: The values are initialized for the letter
        public Letter(Address origin, Address destination, decimal fixedcost) : base( origin, destination )
        {
            FixedCost = fixedcost;  //Set the fixed cost property.
        }

        public decimal FixedCost
        {
            //Precondition: None
            //Postcondition: The fixed cost has been returned
            get
            {
                return _fixedCost;
            }
            //Precondition: value is greater than or equal to 0
            //Postcondition: The fixed cost has been set to the specified value.
            set
            {
                if (value >= 0)     //Validation
                _fixedCost = value;
            }
        }
        //Precondition: none
        //Postcondition: The cost is returned.
            public override decimal CalcCost()
        {
            return FixedCost;
        }
        //Precondition: none
        //Postcondition: a string is returned displaying the details of the address
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
