using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2019
namespace DatabaseConnections
{
    /// <summary>
    /// This is a class utilized to register an store data about a saved game, information from here is then used
    /// retrieve information from the base and create games with players and a deck in it. This shall make it possible to save basic data from a game
    /// and launch an old save as opposed to create a new game via the settings
    /// </summary>
    public class SGame
    {
        public string GameName { get; set; }
        public int NumOfPlayers { get; set; }
        public virtual List<SPlayer>Players { get; set; }    
        public virtual SDeck SavedDeck { get; set; }
  
    }
}
