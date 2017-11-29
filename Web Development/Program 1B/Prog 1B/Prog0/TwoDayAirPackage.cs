//Program 1A
//CIS200-01
//Due date:10-10-16
//Grading ID: C1945
//Two day air package is a concrete derived class of air package
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TwoDayAirPackage : AirPackage
{
    

    public enum Delivery    //Defines 3 choice enumeration for delivery
    {
        Early, Saver
    }

    //Precondition: none
    //Postcondition: Package is created with the specified values for origin address, destination address, length
    //               width, height, weight, and Delivery
    public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, 
        Delivery d) : base(originAddress, destAddress, length, width, height, weight)
    {
        DeliveryType = d;
    }
    public Delivery DeliveryType
    {
        //Precondition: none
        //Postcondition: The delivery type is retrieved
        get;
        //Precondition: none
        //Postcondition: The delerery type is set to the value
        set;
    }
    //Precondition: none
    //Postcondition: The two day air package's cost has been returned
    public override decimal CalcCost()
    {
        decimal BaseCost;                   //TwoDayAirPackage's base cost
        const double EXTRA_FEE = .25;       //Extra fee for two day air 
        const decimal SAVER_FACTOR = .9m;   //Multiplier for saver two day air package

        BaseCost = Convert.ToDecimal(EXTRA_FEE * (Length + Width + Height) + EXTRA_FEE * (Weight));
        if (DeliveryType == Delivery.Saver)
        {
            BaseCost = BaseCost * SAVER_FACTOR;
        }
        return BaseCost;
    }
    //Precondition: none
    //Postcondition: A string with the two day air package's data has been returned.
    public override string ToString()
    {
        return $"TwoDayAirPackage{Environment.NewLine}Delivery Type: {DeliveryType}\r\n{base.ToString()}";
    }
}

