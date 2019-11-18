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
    /// //This is the animal class handling all of the data relevant to an animal regardless of specie and categorization
    //The enumerators Gender and Diet are known and used by the Animal class,Category is placed inside of animal manager instead
    // as it makes more sense for the manager to know about category- all animal types and species alreayd inherits their basic animal properties from this script
    /// </summary>
    [Serializable]
    public abstract class Animal: IAnimal,IComparer<Animal>// inherits both the Icomparable and the IAnimal interfaces
    {
        protected Gender animalGender;// all animals have a gender
        protected Diet animalDiet;// animals may have different diets
        protected Category animcat;
        protected int animalID;// this is not accessed by the user but by the above oriented AnimalManager who generates an animalID only that class can make changes in
        protected double age;// age do not need to be a whole number
        protected string name;// name for the animal
        protected FoodSchedule foodscheme;// variable used by underlaying scripts
        
        // Constructors I prefer to start a script with writing the constructors at the very top
        public Animal()
        {
            // empty constructor for default calling
        }
        
        //Below I have placed some properties for this program to use all has get and set approriate information
        public Gender AnimGender
        {
            get { return animalGender; }
            set { animalGender = value; }
        }
        public Diet AnimDiet
        {
            get { return animalDiet; }
            set { animalDiet = value; }
        }
        public Category AnimCat
        {
            get { return animcat; }
            set { animcat = value; }
        }
        public int ID
        {
            get { return animalID; }
            set { animalID = value; }
        }
        public double Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        // public virtual ToString that can be overriden by other scripts lower down in the hierarchy
        public override string ToString()
        {
            string outPut = String.Empty;            
            outPut = String.Format("{0,2}{1,15}{2,15}{3,20}{4,15}", 
            ID.ToString(), //variable 0
            Name, //variable 1
            Age.ToString(), //Variable 2
            AnimDiet.ToString(), //Variable 3
            AnimGender.ToString());//Variable 4
            // the above variables compiled as text will be returned by the outPutstring
            return outPut;
        }
       /// <summary>
       /// Implementation of Icomparer that compares animals by their ID Numbers//I dont know if this are needed in the final implementation but let it stand
       /// </summary>
       /// <param name="myanim"></param>
       /// <returns></returns>
        public int Compare(Animal myanim1, Animal myanim2)
        {
            if (myanim1.ID > myanim2.ID)
                return 1;// return 1 if the id is bigger than the compare objects
            else if (myanim1.ID < myanim2.ID)
                return -1;// return -1 if the id is less than the compare objects
            else
                return 0;
        }
        /// <summary>
        /// Abstract method that returns a foodschedule based on an animals diet and specie
        /// </summary>
        public abstract FoodSchedule GetFoodschedule();
        /// <summary>
        /// Abstract method that tells us which specie the animal is of, it will dependent on the script redefines it specify specie as the 
        /// specie meant to be represented by the script
        /// </summary>
        public abstract string GetSpecies();
       

    }
}
