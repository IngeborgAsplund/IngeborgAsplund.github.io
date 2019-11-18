using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//By Ingeborg Asplund 2018
namespace APUsZoo
{
    /// <summary>
    /// This class contains the main methods for sorting out different foodschedules for the different species based on the choosen
    /// diet for said specie. It contains a set of main methods for sorting out feeing schedules as well as producing lists of strigns to provide to the GUI
    /// </summary>
    [Serializable]
     public class FoodSchedule
    {
        private List<string> foodDescriptionLines;// defines a list of strings used to describe the feeding procedure of a specific animal, right now defined by said animals specie
        /// <summary>
        /// Main property for the foodschedule class returns the number of saved lines in the foodDescriptionLines List.
        /// </summary>
        public int Count
        {
            get { return foodDescriptionLines.Count; }
        }
        // below follows the two main constructors of this script
        /// <summary>
        /// Basic constructor that inatantiate a new list of strings.
        /// </summary>
        public FoodSchedule()
        {
            foodDescriptionLines = new List<string>();
        }
        /// <summary>
        /// Constructor with a parameter that allow predefinition of an entire foodschedule, I intend to use this function in order to create different foodschedules for the 
        /// different species depending on choosen diet
        /// </summary>
        /// <param name="foodstrings"></param>
        public FoodSchedule(List<string> foodstrings)
        {
           foodDescriptionLines = foodstrings ;
        }
        /// <summary>
        /// method that describes how many times an animal need to be fed based on the number of items in the fooddescription lines list.
        /// </summary>
        /// <returns></returns>
        public string DescribeNoFeedingRequired()
        {
            string noFeedingNeed = String.Empty;// initiates the output string as an empty string to ensure no null output is given
            string descriptionStart = "To be fed ";// the start of the sentence that is written out
            string descriptionEnd = " times as follows";// the end of the sentence written out in GUI
            string nOdescriptions = Count.ToString();// the number of items in list translated to a string
            if (Count > -1)
                noFeedingNeed = String.Format("{0}{1}{2}", descriptionStart, nOdescriptions, descriptionEnd);// formated string output given when count is bigger than -1
            return noFeedingNeed;
        }
        /// <summary>
        /// this is the a method for adding a string item to the list of strings, it is not yet implemented in the application as it is designed to let the user specify foodschedule items through GUI in the future
        /// right now the foodschedule is hardcoded and therefore this method is never called or used
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool AddFoodScheduleItem(string description)
        {
            bool add = false;// bool initially described as false
            if (!string.IsNullOrEmpty(description))
                add = true;// turns true if descrition is not an empty line
            if (add)//if add is true then add the description
                foodDescriptionLines.Add(description);
            return add;
        }
        /// <summary>
        /// In the future this method will be called by a windows form graphical interface in order to 
        /// change a specific description line something the user might want to do if something got misspelled.
        /// </summary>
        /// <param name="newdescription"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool ChangeFoodscheduleItem(string newdescription,int index)
        {
            bool change = false;// bool initially declared false
            bool indexValid = ValidateIndex(index);// bool that check if the index sent into the method is within range
            if (!string.IsNullOrEmpty(newdescription)&& indexValid)
                change = true;// turns true if the new descritption is not null or empty and index is within index of count
            if (change)
            {
                // if true the item on the old position is deleted and a new one is added
                foodDescriptionLines.RemoveAt(index);// remove old description line
                foodDescriptionLines.Insert(index, newdescription);// add new one
            }             
            return change;// return change
        }
        /// <summary>
        /// Removes the selected item in the list of strings, this again is for later implementation as it is designed for user input
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveFoodScheduleItem(int index)
        {
            bool indexOk = ValidateIndex(index);// runs the validate index method directly in order to validate the index sent into method
            if (indexOk)
                foodDescriptionLines.RemoveAt(index);// remove the item at the defined index if it is valid
            return indexOk;
        }
        /// <summary>
        /// The method below generates a list of strings to display int the GUI. Tranlating the items 
        /// in the dynamic list into an array of strings that easily can be displayed in the user interface
        /// </summary>
        /// <returns></returns>
        public string[] PresentFoodSchedule()
        {
            string[] foodSchedule = new string[Count];
            int index = 0;
            if (index > -1)
            { 
              foreach(string instruct in foodDescriptionLines)
              {
                 foodSchedule[index++] = foodDescriptionLines[index];
              }
            }
            return foodSchedule;
        }
        /// <summary>
        /// small method for validating the index sent into one of the above methods
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool ValidateIndex(int index)
        {
            if (index != -1 && index <= Count)
                return true;
            else
                return false;
        }
    }
}
