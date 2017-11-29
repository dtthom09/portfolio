//Program 1A
//CIS200-01
//Due date:10-10-16
//Grading ID: C1945
//The package class is an abstract derived class of parcel.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Package : Parcel
{
    //backing fields
    public double _Length;  //Package's length
    public double _Width;   //Package's Width
    public double _Height;  //Package's Height
    public double _Weight;  //Package's Weight
        
    //Precondition: length > 0, width > 0, height > 0, weight > 0
    //Postcondition: Package is created with the specified values for origin address, destination address, length
    //               width, height, and weight
    public Package( Address originAddress, Address destAddress, double length, double width, double height, double weight) 
        : base(originAddress, destAddress)
    {
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;
    }
    public double Length
    {
        //Precondition: none
        //Postcondition: The Package's length has been returned.
        get
        {
            return _Length;
        }
        //Precondition: value > 0
        //Postcondition: The package's length value has been set to the specified value.
        set
        {
            if (value > 0)
                _Length = value;
            else
                throw new ArgumentOutOfRangeException("Length", value, "Length must be >= 0");
        }
    }
    public double Width
    {
        //Precondition: none
        //Postcondition: The Package's width has been returned.
        get
        {
            return _Width;
        }
        //Precondition: value > 0
        //Postcondition: The package's width value has been set to the specified value.
        set
        {
            if (value > 0)
                _Width = value;
            else
                throw new ArgumentOutOfRangeException("Width", value, "Width must be >= 0");
        }
    }
    public double Height
    {
        //Precondition: none
        //Postcondition: The Package's height has been returned.
        get
        {
            return _Height;
        }
        //Precondition: value > 0
        //Postcondition: The package's height value has been set to the specified value.
        set
        {
            if (value > 0)
                _Height = value;
            else
                throw new ArgumentOutOfRangeException("Height", value, "Height must be >= 0");
        }
    }
    public double Weight
    {
        //Precondition: none
        //Postcondition: The Package's weight has been returned.
        get
        {
            return _Weight;
        }
        //Precondition: value > 0
        //Postcondition: The package's weight value has been set to the specified value.
        set
        {
            if (value > 0)
                _Weight = value;
            else
                throw new ArgumentOutOfRangeException("Weight", value, "Weight must be >= 0");
        }
    }
    //Precondition: none
    //Postcondition: A string with the Package's data has been returned
    public override string ToString()
    {
        return $"{base.ToString()}\r\n\r\nPackage dimensions: {Environment.NewLine}Length: {Length}{Environment.NewLine}Width: {Width}{Environment.NewLine}Height: {Height}{Environment.NewLine}Weight: {Weight}{Environment.NewLine}";
    }
}
