using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
//By Ingeborg Asplund 2019
namespace DatabaseConnections
{
    /// <summary>
    /// Custom databasecontext for the things needed in the gamefiles
    /// </summary>
    class GameFileContext:DbContext
    {
        /// <summary>
        /// Creates the database 
        /// </summary>
        public GameFileContext(): base ("SavedGames")
        {
        }
        public DbSet<SGame> GameFile { get; set; }
        public DbSet<SPlayer> PlayerFile { get; set; }
        public DbSet<SDeck> DeckFile { get; set; }
        public DbSet<SCard> CardData { get; set; }
    }
}
