using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_0
{
    public class Test
    {
        public static void Main(string[] args)
        {
            //Initialize the address and letter objects
            Address address1 =
                new Address("Jerry Seinfeld", "939 West Spring St","1299 4th St", "New York City", "New York", 38456);
            Address address2 =
                new Address("Elaine Benes", "3724 blue trail Rd","789 Northpole Dr", "New York City", "NewYork", 34723);
            Address address3 =
                new Address("George Costanza", "777 7th St","666 South Hampton Blvd", "New York City", "New York", 34772);
            Address address4 =
                new Address("Cosmo Kramer", "474 Main St","100 New Cut Dr", "New York City", "New York", 74587);
            Letter letter1 =
                new Letter(address1, address2, 10);
            Letter letter2 =
                new Letter(address2, address4, 15);
            Letter letter3 =
                new Letter(address3, address4, 10);

            //Create an item list for the letters
            List<Parcel> items = new List<Parcel>();
            items.Add(letter1);
            items.Add(letter2);
            items.Add(letter3);

            //Display the letters
            Console.WriteLine("Origin Address, Destination Address, and Cost:\n");
            Console.WriteLine("Origin Address: {0} \nDelivery Address: {1} \nFixed Cost: {2:C}", letter1.OriginAddress, letter1.DestinationAddress, letter1.CalcCost());
            Console.WriteLine("\nOrigin Address: {0} \nDelivery Address: {1} \nFixed Cost: {2:C}", letter2.OriginAddress,letter2.DestinationAddress, letter2.CalcCost());
            Console.WriteLine("\nOrigin Address: {0} \nDelivery Address: {1} \nFixed Cost: {2:C}", letter3.OriginAddress,letter3.DestinationAddress, letter3.CalcCost());
            
        }   
    }
}
