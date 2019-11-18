using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2018
/// <summary>
/// This class are used to compare animals based on their id and is called by animalmanager when we want to sort the items in zooregistry after their IDnumbers
/// </summary>
namespace APUsZoo
{
    class SortByID:IComparer<Animal>
    {
        /// <summary>
        /// Implementation of Icomparer that compares animals by their ID Numbers
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
    }
}
