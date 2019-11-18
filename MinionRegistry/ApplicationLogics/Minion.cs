using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ingeborg Asplund 2018
namespace ApplicationLogics
{
    /// <summary>
    /// This class describes the minionobject which are stored inside the registry part of the application
    /// it contains a couple of fields as well as a function for adding items to a list of strings and for displaying the tag of the object
    /// through an overriden tostring function
    /// </summary>
    /// 
    [Serializable]
   public class Minion:MasterList<string>
    {
        //Instance variables
        private string name;
        private MinionType specie;
        private int strenght;
        //private List<string> traits;
        //Properties
        /// <summary>
        /// The name of the minion, needed by the ui and the registry class
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        /// <summary>
        /// The type of minion Needed by the ui and the registry class
        /// </summary>
        public MinionType Specie
        {
            get { return specie; }            
        }
        /// <summary>
        /// The strenght of the minion, needed by Ui and registry class
        /// </summary>
        public int StrenghtPoints
        {
            get { return strenght; }           
        }      
        public Minion()
        {
        }
        /// <summary>
        /// Constructor that takes 3 parameters and sets up the minion object properly
        /// </summary>
        /// <param name="miniName"></param>
        /// <param name="miniStrength"></param>
        /// <param name="miniType"></param>
        public Minion(string miniName,int miniStrength,MinionType miniType)
        {
            name = miniName;
            strenght = miniStrength;
            specie = miniType;            
        }
        /// <summary>
        /// Override to string method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string minionTag = string.Format("{0}{1,30}{2,25}",name, specie.ToString(), strenght.ToString());
            return minionTag;
        }
    }
}
