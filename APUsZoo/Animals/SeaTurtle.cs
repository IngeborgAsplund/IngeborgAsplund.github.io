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
    /// //This script are used to define the specie of seaturtle inheriting from categories reptile and animal
         // It holds all methods and variables relevant form the seaturtle
    /// </summary>
    [Serializable]
    public class SeaTurtle :Reptile
    {
        
        protected double swimSpeed;// seaturtles swim, this is the speed for that       

        public SeaTurtle()
        {
            // empty constructor
        }
        public double SwimSpeed
        {
            get { return swimSpeed; }
            set { swimSpeed = value; }
        }
        public override string ToString()
        {
            // this method overrides everything in format animal detail,cs and create a string based on the variables read unto seaturtle
            string outPut = String.Empty;// variable to save fromated string in
            string swim = "Swimspeed ";// string declaring that the value aver it will be swimspeed
            string reqTemp = "Required environment temperature ";
            string crawl = "Crawlspeed ";
            outPut = String.Format("{0,45}{1}{2,15}{3}{4,15}{5}",               
                reqTemp,//var0
                RecuiredTemp.ToString(),//var1
                crawl,//var2
                crawlSpeed.ToString(),//var3
                swim,//var4
                SwimSpeed.ToString());//var 5
            return base.ToString()+outPut;
        }
        public void SeaTurtleValues(string name, double age, Diet seadiet, Gender seagen,Category cat, double temp, double crawl, double swim)
        {
            // sets the values of the turtle after read in variables.
            Name = name;
            Age = age;
            AnimDiet = seadiet;
            AnimGender = seagen;
            AnimCat = cat;
            RecuiredTemp = temp;
            CrawlSpeed = crawl;
            SwimSpeed = swim;
        }
        /// <summary>
        /// return Sea turtle as the name of the specie
        /// </summary>
        /// <returns></returns>
        public override string GetSpecies()
        {
            string specieName = "Sea Turtle";
            return specieName;
        }
        /// <summary>
        /// Retruns three different possible schemes for herbivorous, omnivorous and carnivorous sea turtles.
        /// the schedule choosen is based on the diet that was choosen by the user earlier on.
        /// </summary>
        public override FoodSchedule GetFoodschedule()
        {
            switch (AnimDiet)
            {
                case Diet.MeatEater:
                    CarnivoreSchedule();
                    break;
                case Diet.AllEater:
                    OmnivoreSchedule();
                    break;
                case Diet.PlantEater:
                    HerbivoreSchedule();
                    break;
            }
            return foodscheme;// returns the readily defined feeding schedule defined 
        }
        /// <summary>
        /// Carnivorous schedule for seaturtle used to detail what a meat eating sea turtle animal would eat
        /// </summary>
        private void CarnivoreSchedule()
        {            
            // create a new object of type Foodschedule
            foodscheme = new FoodSchedule();
            // add instructions
            foodscheme.AddFoodScheduleItem("Morning: two big salmons and a bowl of northern herring");
            foodscheme.AddFoodScheduleItem("Lunch: Landturtle meat and a bowl of cubed raw salmon");
            foodscheme.AddFoodScheduleItem("Afernoon: Small tropical fish");
            foodscheme.AddFoodScheduleItem("Evening: One bowl of raw sealmeat");
            
        }
        /// <summary>
        /// defines instructions for feeding an omnivorous seaturtle
        /// </summary>
        private void OmnivoreSchedule()
        {
            // create a new item of type foodschedule 
            foodscheme = new FoodSchedule();
            // add instructions
            foodscheme.AddFoodScheduleItem("Morning: A bowl of seaweed, five seaweedcrakers and two small bird eggs");
            foodscheme.AddFoodScheduleItem("Lunch: Seaweed sallad with salmon and herring pieces");
            foodscheme.AddFoodScheduleItem("Afternoon: Seaweed crackers and sesame seed bread");
            foodscheme.AddFoodScheduleItem("Evening: Seaweed, half a salmon and five herrings");
          
            
        }
        /// <summary>
        /// Defines the feeing instructions for the herbivorous seaturtle
        /// </summary>
        private void HerbivoreSchedule()
        {
            // create a new item of type foodschedule 
            foodscheme = new FoodSchedule();
            // adds some items to the list of strings
            foodscheme.AddFoodScheduleItem("Morning: Bowl of mixed seaweed");
            foodscheme.AddFoodScheduleItem("Lunch: Seaweed salad, with pieces of mango and dragon fruit");
            foodscheme.AddFoodScheduleItem("Evening: Seaweed crackers and fruit salad");
                   
        }

    }
}
