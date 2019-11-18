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
    /// This class contains methods that communicates directly with the database to save and retrieve data the user(player)
    /// wish to save
    /// </summary>
    public class ConnectWithDataBase
    {
        GameFileContext gm;

        public ConnectWithDataBase()
        {
            gm = new GameFileContext();
        }
        /// <summary>
        /// Savemethod that picks a savegame that was created by the bll layer when the user wants to save a game to the
        /// database.
        /// </summary>
        /// <param name="fileToSave"></param>
        public void SaveDownToDataBase(SGame fileToSave)
        {            
                var save = fileToSave;
                //add to the local database
                bool existsimilar = FoundExisting(fileToSave.GameName);
                if (existsimilar)
                {
                    //Removes old save and replace with a new one
                    var found = gm.GameFile.Single(SGame => SGame.GameName == fileToSave.GameName);
                    gm.GameFile.Remove(found);
                    gm.GameFile.Add(save);
                    gm.SaveChanges();
                }
                else
                {
                    //add and save the file to the database
                    gm.GameFile.Add(save);
                    gm.SaveChanges();
                }
                
            
        }
        /// <summary>
        /// Bool for searching throgh database after existing files with the same name
        /// </summary>
        /// <returns></returns>
        private bool FoundExisting(string fileName)
        {
            SGame existing = null;// if this stays null this bool will return a false else it will be true
                //check if the database exists as it is only then the application should try to see if ther is an existing item matching the sent in one
                if (gm.Database.Exists())
                {
                    var searchhere = gm.GameFile;
                    existing = searchhere.Single(SGame => SGame.GameName == fileName);
                }               
            
            if (existing != null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Method that gets an old save from the database by its name and returns an object in form of an SGame(short for saved game)
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public SGame Load(string search)
        {
            SGame loaded = null;//loaded game equals null to beginn with                  
                //variable for the list of saved games in the database
                var loadSave = gm.GameFile;
                //loaded is equal to the game which has a similar name
                loaded = loadSave.Single(SGame => SGame.GameName == search);                                       
            return loaded;
        }
        /// <summary>
        /// List that returns the names of each of the saved games in the gamefiles directory it also checks if the database does exist
        /// before the load is called
        /// </summary>
        /// <returns></returns>
        public List <string> SaveNames()
        {
            List<SGame> saved;
            List<string> saveNames = new List<string>();
            if (gm.Database.Exists())
            {
                saved = gm.GameFile.ToList();
                foreach (SGame sg in saved)
                    saveNames.Add(sg.GameName);
            }           
            return saveNames;
        }
    }
}
