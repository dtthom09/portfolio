//Program 1A
//CIS200-01
//Due date:10-10-16
//Grading ID: C1945
//Next day air package is a concrete derived class of air package
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NextDayAirPackage : AirPackage
{
    private decimal Express_Fee; //Express fee for next day
    

    //Precondition: none
    //Postcondition: Package is created with the specified values for origin address, destination address, length
    //               width, height, and weight
    public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal expressfee) 
        : base(originAddress, destAddress, length, width, height, weight)
    {
        ExpressFee = expressfee;
    }
    public decimal ExpressFee
    {
        //Precondition: none
        //Postcondition: The express fee is returned
        get
        {
            return Express_Fee;
        }
        //Precondition: none
        //Postcondition: The express fee is assigned to value
        private set
        {
            Express_Fee = value;
        }
    }
    //Precondition: none
    //Postcondition: The next day air package's cost has been returned
    public override decimal CalcCost()
    {
        const double DIM_FACTOR = .40;      //Dimension coefficient in cost equation
        const double WEIGHT_FACTOR = .30;   //Weight coefficient in cost equation
        const double EXTRA_FEE = .25;       //Extra fee for large or heavy package
        decimal BaseCost;                   //Variable to hold the base cost.

        BaseCost = Convert.ToDecimal(DIM_FACTOR * (Length + Width + Height) + WEIGHT_FACTOR * (Weight)) + ExpressFee;
        if (IsHeavy() == true)
        {
            BaseCost= BaseCost + Convert.ToDecimal(EXTRA_FEE * (Weight));
        }
        if (IsLarge() == true)
        {
            BaseCost = BaseCost + Convert.ToDecimal(EXTRA_FEE * (Length + Width + Height));
        }
        return BaseCost;
    }
    //Precondition: none
    //Postcondition: A string with the next day air package's data has been returned
    public override string ToString()
    {
        return $"NextDayAirPackage{Environment.NewLine}{base.ToString()}Express Fee: {ExpressFee}";
    }
}

