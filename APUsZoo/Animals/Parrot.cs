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
    /// //This script are used to define the specie of parrot inheriting from categories bird and animal
    // It holds all methods and variables relevant form the parrot
    /// </summary>
    [Serializable]
    class Parrot :Bird
    {        
        protected int knownPhrases;// how many phrases this bird can say

       public Parrot()
        {
            // empty default constructor
        }
        
        public int KnownPhrases
        {
            get { return knownPhrases; }
            set { knownPhrases = value; }
        }
        public override string ToString()
        {
            string outPut = String.Empty;// variable to save fromated string in
            string phrase = "Phrases Known ";// string declaring that the value aver it will be swimspeed
            string flightspeed = "Flightspeed ";
            string color = "Color ";
            outPut = String.Format("{0,25}{1,5}{2,10}{3,15}{4,25}{5,5}",
                
                flightspeed,//var0
                FlightSpeed.ToString(),//var1
                color,//var2
                Color,//var3
                phrase,//var4
                KnownPhrases.ToString());// var 5
            return base.ToString()+outPut;
        }
        public void ParrotValues( string name, double age, Diet parrotdiet, Gender parrotgen,Category cat,string col,double flight,int phrase)
        {
            // expects parameters in the form of variables sent from the main form interface
            Name = name;
            Age = age;
            AnimDiet = parrotdiet;
            AnimGender = parrotgen;
            AnimCat = cat;
            Color = col;
            FlightSpeed = flight;
            KnownPhrases = phrase;
        }
        /// <summary>
        /// returns the specie name as parrot
        /// </summary>
        /// <returns></returns>
        public override string GetSpecies()
        {
            string specieName = "Parrot";
            return specieName;
        }
        /// <summary>
        /// Generate different foodschedules for parrots dependent of their diet. 
        /// </summary>
        public override FoodSchedule GetFoodschedule()
        {
            switch (AnimDiet)
            {
                case Diet.MeatEater:
                    Carnivore();
                    break;
                case Diet.AllEater:
                    Omnivore();
                    break;
                case Diet.PlantEater:
                    Herbivore();
                    break;
            }
            return foodscheme;
        }
        /// <summary>
        /// Generate schedule for carnivorous parrots
        /// </summary>
        private void Carnivore()
        {
            // create new object of type foodschedule
            foodscheme = new FoodSchedule();
            // add some items to list
            foodscheme.AddFoodScheduleItem("Morning: Bowl of jumbo insect legs");
            foodscheme.AddFoodScheduleItem("Lunch: spiderlegs and giant mosquitos");
            foodscheme.AddFoodScheduleItem("Afternoon: Maggots and fishpieces hidden in enclosure for the bird to search");
            foodscheme.AddFoodScheduleItem("Evening, bowl of tropical insects");
            
            
        }
        /// <summary>
        /// Generate schedule for omnivorous parrots
        /// </summary>
        private void Omnivore()
        {
            // create new object of type foodschedule
            foodscheme = new FoodSchedule();
            foodscheme.AddFoodScheduleItem("Morning: One bowl of fruit and peanuts");
            foodscheme.AddFoodScheduleItem("Lunch: Fruitsallad, peanutbisquits and spiderlegs");
            foodscheme.AddFoodScheduleItem("Evening Bowl of fish and tropical fruit");
            foodscheme.AddFoodScheduleItem("Observe that this bird should never be fed chocholate");
           
           
        }
        /// <summary>
        /// Genereate schedule for herbivorous parrots
        /// </summary>
        private void Herbivore()
        {
            // create new foodschedule
            foodscheme = new FoodSchedule();
            // add some items
            foodscheme.AddFoodScheduleItem("Morning: Half a mango and a bowl of peanuts");
            foodscheme.AddFoodScheduleItem("Lunch: Tropical fruits and nuts");
            foodscheme.AddFoodScheduleItem("Afternoon: Hide nuts and fruit in enclosure for bird to search");
            foodscheme.AddFoodScheduleItem("Occasionally: Some extra nutcrackers");
            foodscheme.AddFoodScheduleItem("Evening: Dranonfruit and apples");
           
            
        }
    }
}
