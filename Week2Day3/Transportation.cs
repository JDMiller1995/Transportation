using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day3
{
    abstract class Transportation //abstract class for transportation methods, could be road, water, air, etc. Should have all these values and the functions could work
    {
        protected string color;
        protected int avgMtcCost; //avg maintanence cost over a year
        protected int avgSpeed; //avg speed it can/will travel
        protected int intlCost; //initial investment cost
        public int _intlCost // the get set below are all set up so that we can assign these values
        {
            get
            {
                return intlCost;
            }
            set
            {
                intlCost = value;
            }
        }
        public int _avgSpeed
        {
            get
            {
                return avgSpeed;
            }
            set
            {
                avgSpeed = value;
            }
        }
        public string _color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public int _avgMtcCost
        {
            get
            {
                return avgMtcCost;
            }
            set
            {
                avgMtcCost = value;
            }
        }
        public abstract void timeToTravel(); //we'll use this to perform basic calcs like how long will this take to get somewhere

        public virtual string cost() //this will be an avg yearly cost 
        {
            int i = 0;
            string message = "Your car's average yearly cost is: ";
            return message ;
        }
    }
    abstract class Road : Transportation //abstract class for road transportation methods, any method of road transportation should have these attributes
    {
        protected string fuel; //diesal, electric, gas, human power, etc
        protected int wheels;
        protected int milesPerYear; //miles driven per year

        public int _milesPerYear
        {
            get
            {
                return milesPerYear;
            }
            set
            {
                milesPerYear = value;
            }
        }
        public int _wheels
        {
            get
            {
                return wheels;
            }
            set
            {
                wheels = value;
            }
        }
        public string _fuel
        {
            get
            {
                return fuel;
            }
            set
            {
                fuel = value;
            }
        }
        public override void timeToTravel() //so we can also carry these above functions
        {
            int i = 0;
        }
        public override string cost()
        {
            string message = "Your car will cost $";
            return message;
        }
    }
    class carsTrucksVans : Road //this class isn't abstract, it's for the named vehicles
    {
        private int MPGorMPC; //Miles per gallon or miles per charge if electric 
        private string passengers; //how many passengers it can hold
        private string model;
        public string _model
        {
            get { return model; }
            set { model = value; }
        }

        public int _MPG
        {
            get
            {
                return MPGorMPC;
            }
            set
            {
                MPGorMPC = value;
            }
        }
        public string _passengers
        {
            get
            {
                return passengers;
            }
            set
            {
                passengers = value;
            }
        }

        public override void timeToTravel() //this asks how many miles someone is going to go, then returns the number to whatever called it. 
        {
            base.timeToTravel();
            Console.WriteLine("Let's see how long it would take you to get somewhere!");
            Console.WriteLine("Please input how many miles you'll be traveling in whole numbers!");
            int miles;
            int speed;
            try
            {
                miles = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("What will be your avg speed this trip in miles per hour?");
                speed = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("This trip would take you {0} hours to complete!", miles / speed);

            }
            catch
            {
                Console.WriteLine("You have to enter whole numbers!");
                 timeToTravel();
            }
            
            
           
           
        }
        public string cost(int initial, int MTC, int MPG, int MPY) //these inputs are things we've already gathered from the user, and outputs the yearly cost 
        {
            Console.WriteLine("How many years do you expect to own your vehicle?");
            try
            {
                int years = Convert.ToInt32(Console.ReadLine());
                int yearlyCost = (initial / years) + MTC + (MPG / MPY);
                return base.cost() + yearlyCost;
            }
            catch
            {
                Console.WriteLine("You have to input a number");
                return cost();
            }
            
            
        }
    }
}
