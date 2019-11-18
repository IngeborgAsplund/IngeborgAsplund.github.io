using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2018
namespace APUsZoo
{
    /// <summary>
    /// This Class implements IComparer and is used to compare the names of animals, this class is called by the animal calss
    /// </summary>
    class CompareByName: IComparer<Animal>
    {
        /// <summary>
        /// compare the names of two animals which each other in order to sort them in alphabetical order
        /// </summary>
        /// <param name="anim1"></param>
        /// <param name="anim2"></param>
        /// <returns></returns>
        public int Compare(Animal anim1,Animal anim2)
        {
            return anim1.Name.CompareTo(anim2.Name);
        }
    }
}
