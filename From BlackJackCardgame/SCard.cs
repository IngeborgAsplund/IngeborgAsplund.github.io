using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2019
namespace DatabaseConnections
{
    /// <summary>
    /// class descirbing the variables that needs to be saved down for the cards in the deck used in the saved game
    /// </summary>
    public class SCard
    {
        public int Value { get; set; }
        public string Suit { get; set; }
        public string Name { get; set; }
    }
}
