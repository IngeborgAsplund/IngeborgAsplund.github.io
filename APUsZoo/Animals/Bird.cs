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
    /// //This is the main bird class that all objects of type bird is inheriting from
    // It contains variables that is general to all of the reptilespecies
    /// </summary>
    [Serializable]
    public abstract class Bird :Animal
    {
        protected string color;// birds can have many beautiful colors the user are allowed to assign the main coloration of the bird here, ex brown, green, yellow or pink
        protected double flightSpeed;// birds can fly that is one particular aspect that put them appart from other animals this value determines how fast they will fly

        // Properties for the bird object
        public Bird()
        {
            //empty constructor
        }
        
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public double FlightSpeed
        {
            get { return flightSpeed; }
            set { flightSpeed = value; }
        }
        
       
    }
}
