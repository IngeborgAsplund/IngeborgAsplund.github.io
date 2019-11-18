using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
// Ingeborg Asplund 2018

/// <summary>
///  Manager class that handle the adding of animals in the list of zooregistry
//It also handles the generating of unique animal ids, and holds two lists one for ids and one for the actual animal objects, all animals are added to both lists
///However should the possition inside of zoomanager change the id will not be changed, id 0 will continue to be id 0 
/// </summary>
namespace APUsZoo
{
    [Serializable]//Serialization of listmanager and its list
    public class AnimalManager:ListManager<Animal>
    {
        //private ListManager<Animal> zooRegistry;// private list containing objects of type animal, this list are Not Allowed A Constructor
        private List<Animal> id;// the list used to generate the animals id
              
        // Constructor method called by the GUI script when at initiation
        public AnimalManager()
        {
            //base constructor that sets up the script for use by GUI
            id = new List<Animal>();// IDlist                              
        }
       
        public bool GiveID(Animal added)// takes animal as a parameter to add the information being read in throguh the GUI
        {
            //<Summary>
            // this method adds an animal to zooregistry after a brief check of the general animal infrmation inside the animal(added as a specie in the main form)
            // originally I wanted to check all the information given for the animal here but as I could not find a working way to do so I use the main form to check 
            // the information instead
            //<Summary>
            bool infoOk = false;
            id.Add(added);// add animal to id list
            added.ID = GenerateAnimalID(added);// get the id based of the list
            
            if (added.ID != -1)
                infoOk = true;

            if (infoOk)
            {
                Add(added);// adds an animal after checking the input data
                GenerateFoodSchedule(added);
                
            }
            return infoOk;

        }
        
        /// <summary>
        ///  this method finds/ generates the Id number of a specific animal
        ///  sends an animal as parameter to see which position in the list said animal has
        // the id is based on this and generated on creation
        //Id will not change if animal is changed or for some reason changes its position in the list.
        /// </summary>
        /// <param name="anim"></param>
        /// <returns></returns>
        private int GenerateAnimalID(Animal anim)
        {
  
            if (anim != null)
            {

                return id.IndexOf(anim);
               
            }
            else
                return -1;
        }
        
       
      
        
    }
}
