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
    /// //This is the main reptile class that all objects of type reptile is inheriting from
    // It contains variables that is general to all of the reptilespecies
    /// </summary>
    [Serializable]
    public abstract class Reptile : Animal
    {
        // Instance variables specific to reptiles
        protected double requiredEnvTemp;
        // one of the biggest differences between reptiles and othe animals is that reptiles lack the ability to generate 
        // heat on their own thus they will need a the temperature in the environment to stay above a certain temperature, hence this required environmental tempreture variable
        protected double crawlSpeed;// how fast does the reptile move while on land

        // Constructors for this class called when initiated or changed(later in the process deverloing this application)
        public Reptile()
        {
            // empty default constrctor
        }
        
        // properties for reptiles
        public double RecuiredTemp
        {
            get { return requiredEnvTemp; }
            set { requiredEnvTemp = value; }
        }
        public double CrawlSpeed
        {
            get { return crawlSpeed; }
            set { crawlSpeed = value; }
        }
       
        
    }
}
