// Program 0
// CIS 200-01/76
// Fall 2016
// Due: 9/24/2016
// By: Andrew L. Wright (students use Grading ID)

// File: Parcel.cs
// Parcel serves as the abstract base class of the Parcel hierachy.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Parcel : IComparable<Parcel>
{
    // Precondition:  None
    // Postcondition: The parcel is created with the specified values for
    //                origin address and destination address
    public Parcel(Address originAddress, Address destAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destAddress;
    }

    public Address OriginAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's origin address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's origin address has been set to the
        //                specified value
        set;
    }

    public Address DestinationAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's destination address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's destination address has been set to the
        //                specified value
        set;
    }

    // Precondition:  None
    // Postcondition: The parcel's cost has been returned
    public abstract decimal CalcCost();

    // Precondition:  None
    // Postcondition: A String with the parcel's data has been returned
    public override String ToString()
    {
        return String.Format("Origin Address:{3}{0}{3}{3}Destination Address:{3}{1}{3}Cost: {2:C}",
            OriginAddress, DestinationAddress, CalcCost(), Environment.NewLine);
    }

    //Precondition:  None
    //Postcondition: When this < parcel2, method returns negative #
    //               When this == parcel2, method returns zero
    //               When this > parcel2, method returns positive #
    public int CompareTo(Parcel parcel2)
    {
        // Ensure correct handling of null values (in .NET, null less than anything)

        if (this == null && parcel2 == null)    //Checks if both are null
            return 0;                           //Equal
        if (this == null)                       //Checks if this is null
            return -1;                          //Null is less than any actual parcel
        if (parcel2 == null)                    //Checks if parcel2 is null
            return 1;                           //Any actual parcel is greater than null

        //Compare by calc cost
        return (this.CalcCost()).CompareTo(parcel2.CalcCost());
    }
}
