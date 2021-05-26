using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week2Day3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Let's get some info about what vehicle you're getting, and perform some calculations about it!"); //basic info gathering from user
            Console.WriteLine("What make are you going to get?");
            string make = Console.ReadLine();
            carsTrucksVans vehicle1 = new carsTrucksVans(); //starting a new obj under class carsTrucksVans
            Console.WriteLine("What model is it?");
            vehicle1._model = Console.ReadLine();
            Console.WriteLine("Awesome, so you're going to get a {0} {1}! What color will it be?", make, vehicle1._model);
            vehicle1._color = Console.ReadLine();
            Console.WriteLine("Is it electric or gas or diesal?");
            vehicle1._fuel = Console.ReadLine();
            Console.WriteLine("And how many MPG or miles per charge?");
            int check() //this just makes sure they put a number in for MPG 
            {
                try
                {
                    vehicle1._MPG = Convert.ToInt32(Console.ReadLine());
                    return vehicle1._MPG;
                }
                catch
                {
                    Console.WriteLine("Please put a number.");
                            return check();
                }
            }
            check(); //caling the function
            Console.WriteLine("How many passengers can it hold?");
            vehicle1._passengers = Console.ReadLine();
            Console.WriteLine("Very cool, so far we have a {0} {1} {2} that runs on {3} and gets {4} miles per gallon or per charge, and can hold {5} passengers!", vehicle1._color, make, vehicle1._model, vehicle1._fuel, vehicle1._MPG, vehicle1._passengers);
            Console.WriteLine("Alright these next few questions are so we can do some calculations!");
            Console.Write("Initial cost is: "); //the below is setting values/making sure they are getting correct inputs 
            try
            {
                vehicle1._intlCost = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You wrote something that wasn't a number!");
            }
            Console.Write("Average yearly maintenance cost is: ");
            try
            {
                vehicle1._avgMtcCost = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You wrote something that wasn't a number!");
            }
            Console.WriteLine("How many miles will you be driving a year?");
            try
            {
                vehicle1._milesPerYear = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("You wrote something that wasn't a number!");
            }
            vehicle1.timeToTravel(); //calls a function in my cars class
            Console.WriteLine("Let's see how much your vehicle will cost per year on average!");
            Console.WriteLine(vehicle1.cost(vehicle1._intlCost, vehicle1._avgMtcCost, vehicle1._MPG, vehicle1._milesPerYear)+ " per year"); //this calls a function in my cars class
            void writeToFile() //writes everything to a file called CarInfo.txt, does overwrite anything else prior in the file though. 
            {
                StreamWriter writer1 = new StreamWriter("CarInfo.txt");
                writer1.WriteLine("Your car is a {0} {1} {2} that get's {3} MPG/MPC and cost ${4}.", vehicle1._color, make, vehicle1._model, vehicle1._MPG, vehicle1._intlCost);
                writer1.Close();
            }
            writeToFile();
            try  //below reads the file i created above 
            { 
                
                StreamReader reader1 = new StreamReader("CarInfo.txt");
                string contents = reader1.ReadToEnd();
                reader1.Close();
                Console.WriteLine(contents);
            }
            catch (Exception e) //this is just an error message if for some reason the file is inaccesable 
            {
                
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        
        
    }
}
