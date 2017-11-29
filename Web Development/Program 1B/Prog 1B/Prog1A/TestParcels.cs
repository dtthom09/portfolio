// Prog 1B
// CIS 200-01
// Fall 2016
// Due: 10/17/2016
// By: Andrew L. Wright &
//By: C1945

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It uses LINQ tp sort different parcels based on different requirments.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Ryan Leezer", "666 Spring St", "",
                "New York CIty", "NY", 37219);    //Test Address 5
            Address a6 = new Address("Jessica Lewis", "100 7th St", "",
                "Tampa", "FL", 57611);  //Test Address 6
            Address a7 = new Address("Mark Hunt", "123 11th St", "Apt. 2",
                "Phoenix", "AZ", 21399);    //Test Address 7
            Address a8 = new Address("Mary Gates", "2838 W Jefferson St", "",
                "Atlanta", "GA", 18042);    //Test Address 8

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object 1
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object 1
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object 1
                85, 7.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object 1
                80.5, TwoDayAirPackage.Delivery.Saver);
            Letter letter2 = new Letter(a6, a8, 2.50M);                             //Letter test object 2
            GroundPackage gp2 = new GroundPackage(a1, a6, 7, 5, 5, 10);             //Ground test object 2
            NextDayAirPackage ndap2 = new NextDayAirPackage(a3, a8, 20, 18, 15,     //Next Day test object 2
                40, 5.5M);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a2, a7, 40, 30, 30,       //Two Day test object 2
                61, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(gp1);
            parcels.Add(ndap1);
            parcels.Add(tdap1);
            parcels.Add(letter2);
            parcels.Add(gp2);
            parcels.Add(ndap2);
            parcels.Add(tdap2);

            //LINQ query sorted by destination address zip
            var sortDestZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            // Display the query thorugh a foreach loop.
            Console.WriteLine("Parcels sorted by dest zip:");
            Console.WriteLine("=============================");
            foreach (var P in sortDestZip)
                Console.WriteLine(P.DestinationAddress.Zip);
            Console.WriteLine();

            //LINQ query sorted by cost
            var sortByCost =
                from p in parcels
                orderby p.CalcCost()
                select p;

            // Display the query thorugh a foreach loop.
            Console.WriteLine("Parcels sorted by cost:");
            Console.WriteLine("=============================");
            foreach (var P in sortByCost)
                Console.WriteLine(P.CalcCost());
            Console.WriteLine();

            //LINQ query sorted by type, then cost
            var sortByTypeCost =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending    
                select p;

            // Display the query thorugh a foreach loop.
            Console.WriteLine("Parcels sorted by type, then cost:");
            Console.WriteLine("====================================");
            foreach (var P in sortByTypeCost)
                Console.WriteLine(P.GetType() + ": " + P.CalcCost());
            Console.WriteLine();

            //LINQ query sorted by the weight of heavy Air Packages
            var sortByAirPackageWeight =
                from p in parcels
                where p is AirPackage
                let P =(AirPackage)p
                where P.IsHeavy() ==true
                orderby P.Weight descending
                select P;

            // Display the query thorugh a foreach loop.
            Console.WriteLine("Heavy Air Packages sorted by weight:");
            Console.WriteLine("====================================");
            foreach (var P in sortByAirPackageWeight)
                Console.WriteLine(P.Weight);
            Pause();
       }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
