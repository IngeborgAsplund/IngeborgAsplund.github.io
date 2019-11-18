using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2019
namespace DatabaseConnections
{
    /// <summary>
    /// Class used to save down data relating to the deck used during a specific game, such as its specific cards
    /// the size of the deck one two and three. Dependant on what is choosen when creating the deck the 
    /// size will vary.
    /// </summary>
    public class SDeck
    {
        public virtual List<SCard> SavedCards { get; set; }
        public int Size { get; set; }
    }
}
