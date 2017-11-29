//Program 1A
//CIS200-01
//Due date:10-10-16
//Grading ID: C1945
//Ground package is a concrete derived class of package
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GroundPackage : Package    
{
    //Precondition: length > 0, width > 0, height > 0, weight > 0
    //Postcondition: Package is created with the specified values for origin address, destination address, length
    //               width, height, and weight
    public GroundPackage( Address originAddress, Address destAddress, double length, double width, double height, double weight) 
        : base(originAddress, destAddress, length, width, height, weight)
    {
        
    }

    public int ZoneDistance
    {
        //Precondition: none
        //Postcondition: The ground package's zone distance is returned.
        //                The zone distance is the positive difference between the
        //                first digit of the origin zip code and the first
        //                digit of the destination zip code.
        get
        {
            const int FIRST_DIGIT_FACTOR = 10000;   //Denominator to extract 1st digit
            int dist;                               //Calculated zone distance

            dist = Math.Abs((originAddress.Zip / FIRST_DIGIT_FACTOR) - (DestinationAddress.Zip / FIRST_DIGIT_FACTOR));

            return dist;
        }
    }
    //Precondition: none
    //Postcondition: The ground package's cost has been returned
    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .20;   //Dimension coefficient in cost equation
        const double WEIGHT_FACTOR = .5; //Weight coefficient in cost equation

        return Convert.ToDecimal(DIM_FACTOR * (Length + Width + Height) + WEIGHT_FACTOR * (ZoneDistance + 1) * Weight);
    }
    //Precondition: none
    //Postcondition: A string with the groud package's data has been returned
    public override string ToString()
    {
        return $"GroundPackage{Environment.NewLine}{base.ToString()}Zone Distance: {ZoneDistance}";
    }
}

