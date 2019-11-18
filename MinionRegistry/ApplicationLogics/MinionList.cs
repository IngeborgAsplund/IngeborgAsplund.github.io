using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
//Ingeborg Asplund 2018
namespace ApplicationLogics
{
    /// <summary>
    /// The registry containing the Minions currently recruited as well as the methods associated with handelig them, search among them
    /// based on different categories as well as their traits.
    /// </summary>
    /// 
    [Serializable]
    public class MinionList : MasterList<Minion>
    {
        /// <summary>
        /// Construtor for the minonRegistry
        /// </summary>
        public MinionList()
        {

        }
        /// <summary>
        /// Property that returns the current number of minions in the list
        /// </summary>
        //public int NumberOfMinions
        //{
        //    get { return minionsOfTerror.Count; }
        //}
        /// <summary>
        /// Function for adding a minion to the list of minions
        /// </summary>
        /// <param name="minName"></param>
        /// <param name="type"></param>
        /// <param name="strength"></param>
        //public void AddMinion(Minion min)
        //{
        //    if (min != null)
        //        minionsOfTerror.Add(min);
        //}
        /// <summary>
        /// Function that removes a minion from a specific index
        /// </summary>
        /// <param name="index"></param>
        //public void RemoveMinion(int index)
        //{
        //    if (index > -1 && index < minionsOfTerror.Count)
        //        minionsOfTerror.RemoveAt(index);
        //}
        /// <summary>
        /// Function for saving the file as an xml to a location choosen by the user, this is called 
        /// by the ui whenever the user calls the save function producing a save fíle of minions to load
        /// into the application
        /// </summary>
        /// <param name="fileName"></param>
        //public bool SaveAsXML(string fileName)
        //{
        //    bool sucessful = false;
        //    if (!string.IsNullOrEmpty(fileName))
        //        sucessful = true;
        //    if (sucessful)
        //        XMLSerialize.Save<MinionList>(fileName, minionsOfTerror);
        //    return sucessful;
        //}
        /// <summary>
        /// Function to loadfile from xml format
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        //public bool LoadFromXML(string fileName)
        //{
        //    bool sucessful = false;
        //    if (!string.IsNullOrEmpty(fileName))
        //        sucessful = true;
        //    if (sucessful)
        //        minionsOfTerror = XMLSerialize.Load<List<Minion>>(fileName);
        //    return sucessful;
        //}
        /// <summary>
        /// Method that outputs a list of strings based on a list of minions sent in, this method is meant to be versatile and can
        /// display alternate versions of the list of minions in the bank when lambda functions is displayed to filter certain attributes
        /// later in the application
        /// </summary>
        /// <param name="miniList"></param>
        /// <returns></returns>
        public List<string> MyMinions(List<Minion> inList)
        {
            List<string> outputstring = new List<string>();
            foreach (Minion m in inList)
            {
                outputstring.Add(m.ToString());
            }
            return outputstring;
        }


        //**********************************Lambda Expressions****************************
        //Below I have defined four lambda expressions used to search for minions by their name, strenght
        //type and different traits
        /// <summary>
        /// Lambda expression that returns a minion based on its name, making it possible for the application to 
        /// check if a minion with x name already exist in the registry and thereby preventing doublettes 
        /// </summary>
        /// <param name="searchName"></param>
        /// <returns></returns>
        public Minion SearchByName(string searchName)
        {
            Minion found = Mylist.Find(min => min.Name == searchName);
            return found;
        }
        /// <summary>
        /// Lambda that returns a list of minions that has the same  strenght than the input parameter
        /// </summary>
        /// <param name="strength"></param>
        /// <returns></returns>
        public List<Minion> SearchByStrength(int strenght)
        {
            List<Minion> similarstrenght = new List<Minion>();
            similarstrenght= Mylist.Where((Minion m) => m.StrenghtPoints == strenght).ToList();
            if (similarstrenght.Count == 0)
                similarstrenght = SortByStrength(strenght);
            return similarstrenght;
        }
        /// <summary>
        /// Lambda that returns a list of minions that is of the same type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Minion> SearchByType(MinionType type)
        {
            List<Minion> sameType = Mylist.Where((Minion m) => m.Specie == type).ToList();
            return sameType;
        }
        /// <summary>
        /// Lambda Function that filters through the list of minions to find those assigned a specific trait
        /// </summary>
        /// <param name="trait"></param>
        /// <returns></returns>
        public List<Minion> SearchByTrait(string trait)
        {
            List<Minion> minions = Mylist.Where(x => (x.Mylist.Contains(trait))).ToList();
            return minions;
        }
        /// <summary>
        /// Lambda expression that outputs a list of all name starting with a specific letter if no whole 
        /// minionName was entered as it then returns that minions name instead
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Minion>SearchNameByStartLetter(string searchfeature)
        {
            List<Minion> startsWith = new List<Minion>();
            startsWith = Mylist.Where(x => (x.Name == searchfeature)).ToList();
            if (startsWith.Count == 0)
            {
                char start = searchfeature.First<char>();
                startsWith = Mylist.FindAll(x => (x.Name.StartsWith(start.ToString()))).ToList();
            }
            return startsWith;
        }
        /// <summary>
        /// If no minion with the entered strenght are found and the entered value is not 0
        /// evrything lower than the entered value are found, if no values lower than the entered value are found
        /// the function instead displays all values above it.
        /// </summary>
        private List<Minion> SortByStrength(int strinput)
        {
            List<Minion> SortByStrenght = new List<Minion>();
            if (strinput > 0)
            {
                SortByStrenght = Mylist.Where(x => (x.StrenghtPoints < strinput)).ToList();
                //below code is only run if 
                if (SortByStrenght.Count == 0)
                {
                    SortByStrenght = Mylist.Where(x => (x.StrenghtPoints > strinput)).ToList();
                }
            }
            return SortByStrenght;
        }


    }
}
