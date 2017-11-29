//Program 1A
//CIS200-01
//Due date:10-10-16
//Grading ID: C1945
//The air package class is an abstract derived class of package.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AirPackage : Package
{
    const double HEAVY_AIRPACKAGE = 75;     //Const to determine if a package is heavy
    const double LARGE_AIRPACKAGE = 100;    //Const to determine if a package is large

    //Precondition: none
    //Postcondition: Package is created with the specified values for origin address, destination address, length
    //               width, height, and weight
    public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight) 
        : base(originAddress, destAddress, length, width, height, weight)
    {

    }
    //Precondition: none
    //Postcondition: Determines if package is heavy
    public bool IsHeavy()
    {
        if (Weight >= HEAVY_AIRPACKAGE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Precondition: none
    //Postcondition: Determines if package is large
    public bool IsLarge()
    {
        if (Length+Width+Height >= LARGE_AIRPACKAGE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //Precondition: none
    //Postcondition: A string with the air package's data has been returned
    public override string ToString()
    {
        if (IsHeavy() == true && IsLarge() == true)
        {
            return $"Heavy and Large Package{Environment.NewLine}{base.ToString()}";
        }
        else if (IsHeavy() == true)
        {
            return $"Heavy Package{Environment.NewLine}{base.ToString()}";
        }
        else if (IsLarge() == true)
        {
            return $"Large Package{Environment.NewLine}{base.ToString()}";
        }
        else
        {
            return $"{Environment.NewLine}{base.ToString()}";
        }
    }
}
