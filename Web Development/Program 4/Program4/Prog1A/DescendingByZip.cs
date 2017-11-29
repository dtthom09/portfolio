//Prog4
//Grading ID: C1945
//Due date: 11-29-16
//CIS200-01
//This program explores ways of comparing objects in a class by using ICombarable
//and sorting these objects in different orders.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    public class DescendingByZip : Comparer<Parcel>
    {
        //Precondition:  None
        //Postcondition: Overrides compare and orders parcels by desc zip
        //               When parcel1 < parcel2, method returns positive #
        //               When parcel1 == parcel2, method returns zero
        //               When parcel1 > parcel2, method returns negative #
        public override int Compare(Parcel parcel1, Parcel parcel2)
        {
            //Ensure correct handling of null values (in .NET, null less than anything)
            if (parcel1 == null && parcel2 == null) //Checks if both are null
                return 0;                           //Equal
            if (parcel1 == null)                    //Checks if parcel1 is null
                return -1;                          //Null is less than any actual parcel
            if (parcel2 == null)                    //Checks if parcel2 is null
                return 1;                           //Any actual parcel is greater than null

            //Reverses natural order, so descending
            return (-1)*(parcel1.DestinationAddress.Zip).CompareTo(parcel2.DestinationAddress.Zip);
        }
    }
}
