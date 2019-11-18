using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2019
namespace DatabaseConnections
{
    /// <summary>
    /// saving the data of the player needed to later retrieve a saved game 
    /// </summary>
   public class SPlayer
    {
        public string Name { get; set; }       
        public int Draswleft { get; set; }
        public bool Myturn { get; set; }
        public bool Winner { get; set; }
        public int Victories { get; set; }
    }
}
