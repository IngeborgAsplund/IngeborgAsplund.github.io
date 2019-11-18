using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
// By Ingeborg Asplund 2018
namespace APUsZoo
{
    /// <summary>
    ///    This script are used to define the specie of pigeon inheriting from categories bird and animal
    //It holds all methods and variables relevant form the pigeon
    /// </summary>
    [Serializable]
    public class Pigeon:Bird
    {    
        protected int lettersCarried;// pigeons use to carry letters and this one is not an exeption      
        public Pigeon()
        {
            // empty default constructor
        }
        
        public int LettersCarried
        {
            get{ return lettersCarried; }
            set { lettersCarried = value; }
        }
        public override string ToString()
        {
            // overrides the format animal details method in animal class presenting the data read into the pigeon object
            string outPut = String.Empty;// variable to save fromated string in
            string letter = "Letters Carried ";// string declaring that the value aver it will be swimspeed
            string flightspeed = "Flightspeed ";
            string color = "Color ";
            outPut = String.Format("{0,25}{1,5}{2,10}{3,15}{4,25}{5,5}",               
                flightspeed,//var0
                FlightSpeed.ToString(),//var1
                color,//var2
                Color,//var3
                letter,//var4
                LettersCarried.ToString());// var 5
            return base.ToString()+outPut;
        }
        public void PigeonValues(string name, double age, Diet pigeonDiet, Gender pigeonGender,Category cat, string color, double flightspeed, int letters)
        {
            // expect the values specific to pigeon and set them after inpputgiven values
            Name = name;
            Age = age;
            AnimDiet = pigeonDiet;
            AnimGender = pigeonGender;
            AnimCat = cat;
            Color = color;
            FlightSpeed = flightspeed;
            LettersCarried = letters;
        }
        /// <summary>
        /// returns peigon as the name of the specie Pigeon as Pigeon
        /// </summary>
        /// <returns></returns>
        public override string GetSpecies()
        {
            string specieName = "Pigeon";
            return specieName;
        }
        /// <summary>
        /// provide one of three possible foodschedules for pigeons through the use of a switch statement
        /// </summary>
        public override FoodSchedule GetFoodschedule()
        {
            switch (AnimDiet)
            {
                case Diet.MeatEater:
                    Carnivorous();
                    break;
                case Diet.AllEater:
                    Omnivorous();
                    break;
                case Diet.PlantEater:
                    Herbivorous();
                    break;
            }
            return foodscheme;
        }
        /// <summary>
        /// Define a schedule for carnivorous pigeons
        /// </summary>
        private void Carnivorous()
        {
            // create an obect of type foodschedule 
            foodscheme = new FoodSchedule();          
            // add a number of items to the list
            foodscheme.AddFoodScheduleItem("Dawn: The Pigeon will hunt for small insects such as fleas and maggots");
            foodscheme.AddFoodScheduleItem("Morning: One small bowl of spiderlegs and bumblebees");
            foodscheme.AddFoodScheduleItem("Lunch: One big spider");
            foodscheme.AddFoodScheduleItem("Evening: The Pigeon will hunt smaller insects such as fireflies by itself");
            
        }
        /// <summary>
        /// Define a schedule for feeding omnivorous pigeons
        /// </summary>
        private void Omnivorous()
        {
            // create new foodschedule item.
            foodscheme = new FoodSchedule();
            // add some items to list
            foodscheme.AddFoodScheduleItem("Morning: One small bowl of insects and seeds");
            foodscheme.AddFoodScheduleItem("Lunch: Breadcrums, worms and fireflies");
            foodscheme.AddFoodScheduleItem("Evening: Sesame seed crackers and a bowl of small insects");
            
        }
        /// <summary>
        /// define a schedule for feeding herbivorous pigeons
        /// </summary>
        private void Herbivorous()
        {
            // create new item of type foodschedule 
            foodscheme = new FoodSchedule();
            // add some items
            foodscheme.AddFoodScheduleItem("Morning: Sesame seeds and breadcrumbs");
            foodscheme.AddFoodScheduleItem("Lunch: Fruit and berries");
            foodscheme.AddFoodScheduleItem("Afternoon: Nuts and various seeds");
            foodscheme.AddFoodScheduleItem("Evening: bowl of corn and small nuts");
           
        }
    }
}
