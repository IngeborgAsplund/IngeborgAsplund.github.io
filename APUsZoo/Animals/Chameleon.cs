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
    /// //This script are used to define the specie of Chameleon inheriting from categories reptile and animal
         // It holds all methods and variables relevant form the Chameleon
    /// </summary>
    [Serializable]
    public class Chameleon :Reptile
    {
        protected double colorChangeSpeed;// changing color is the key signature of a chameleon, but how fast does the individual chameleon change its colors?

        // Constructors, I choosed to only have constructors with parameters here as no scripts are inheriting from this script yet
        public Chameleon()
        {
            // Empty constructor
        }
       
        // Property for Chameleon
        public double ColorChangeSpeed
        {
            get { return colorChangeSpeed; }
            set { colorChangeSpeed = value; }
        }
        public override string ToString()
        {
            // this method overrides everything in format animal detail,cs and create a string based on the variables read into Chameleon
            string outPut = String.Empty;// variable to save fromated string in
            string col = "ColorchangeSpeed ";// string declaring that the value aver it will be swimspeed
            string reqTemp = "Required environment temperature ";
            string crawl = "Crawlspeed ";
            outPut = String.Format("{0,45}{1}{2,15}{3}{4,20}{5}",               
                reqTemp,//var0
                RecuiredTemp.ToString(),//var1
                crawl,//var2
                crawlSpeed.ToString(),//var3
                col,//var4
                colorChangeSpeed.ToString());//var5
            return base.ToString()+outPut;// use of baseclass plus data modified in this class
        }
        public void SetChameleonValues(string name, double age, Diet chamdiet,Gender chamgender,Category cat,double temp,double crawl,double colorchange)
        {
            // this method requires the values specific for the Chameleon and are called when we are sure that myanimal 
            // referred to in the main form is a chameleon(the enum is set as chameleon)
            Name = name;
            Age = age;
            AnimDiet = chamdiet;
            AnimGender = chamgender;
            AnimCat = cat;
            RecuiredTemp = temp;
            CrawlSpeed = crawl;
            ColorChangeSpeed = colorchange;
        }
        /// <summary>
        /// returns the specie name as chameleon this are later used by other members of the program to determine which specie they are defining the foodschedule foor.
        /// </summary>
        /// <returns></returns>
        public override string GetSpecies()
        {
            string specieName = "Chameleon";
            return specieName;
        }
        /// <summary>
        /// returns three different schedules through that depends on which diet the user have choosen which schedule are choosen is determined by 
        /// a switch statement going through the animal.diet property displaying different feeding routines depending on which diet the specific animal in quetion has.
        /// </summary>
        public override FoodSchedule GetFoodschedule()
        {
            switch (AnimDiet)// goes through the diet enum property displaying appropriate schedule dependent on which diet the user has choosen
            {
                case Diet.MeatEater:
                    CarnivorSchedule();
                    break;
                case Diet.AllEater:
                    OmnivorSchedule();
                    break;
                case Diet.PlantEater:
                    HerbivorSchedule();
                    break;
            }
            return foodscheme;// return foodscheme after the loop decided how to set it
        }
       
        /// <summary>
        /// Produces a schedule for carnivorous chameleons creating a list of strings to send as parameter to the foodschedule class when
        /// instanciated.
        /// </summary>
        private void CarnivorSchedule()
        {
            //create an item of the type foodscheme
            foodscheme = new FoodSchedule();
            // adds some feeding directions for the carnivorous variant of chameleon
            foodscheme.AddFoodScheduleItem("Morning: 1 plate with small fish");
            foodscheme.AddFoodScheduleItem("Lunch: Mix of fish and small spiders");
            foodscheme.AddFoodScheduleItem("Afernoon: Insect snacks");
            foodscheme.AddFoodScheduleItem("Evening: One bowl of spidermeat");            

        }
        /// <summary>
        /// define the feeding schedule for omnivorous chameleons
        /// </summary>
        private void OmnivorSchedule()
        {   
            // create a new item of type foodschedule                   
            foodscheme = new FoodSchedule();
            // add some items in the list
            foodscheme.AddFoodScheduleItem("Morning: 1 plate of fruit and insects");
            foodscheme.AddFoodScheduleItem("Lunch fruit and fisch pieces");
            foodscheme.AddFoodScheduleItem("Afternoon: 2 pieces of mango");
            foodscheme.AddFoodScheduleItem("Evening, 1/2 bird egg and a bowl of insects");                                      
        }
        /// <summary>
        /// define the feeding schedule for herbivorous chameleons
        /// </summary>
        private void HerbivorSchedule()
        {
            // intitiate new list of strings
            // create new instance of foodschedule
            foodscheme = new FoodSchedule();          
            // add some items to the list of strings
            foodscheme.AddFoodScheduleItem("Morning: Plant leaves and fruit pieces");
            foodscheme.AddFoodScheduleItem("Lunch: A bowl of friut pieces and plant leaves");
            foodscheme.AddFoodScheduleItem("Afternoon: 4 pieces of mango and some water");
            foodscheme.AddFoodScheduleItem("Evening: a bowl of mango and apple pieces");
            foodscheme.AddFoodScheduleItem("Often: refill water herbivorous chameleons consume much water every day");
                        
        }

    }
}
