using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameUtilities;
using DatabaseConnections;
//By Ingeborg Asplund 2019
namespace GameAndAIUtilities
{
    /// <summary>
    /// Class that creates instances of the Saveclasses from the information present in the current game.
    /// it takes parameters such as strings bools objects and enums and parses down to readable information
    /// for the databaseconnection classes. 
    /// </summary>
    public class SaveLoadManager
    {
        private ConnectWithDataBase dbConnect;
        private List<string> saveNames;//provide the listbox in the save games interface
        /// <summary>
        /// Property for the list of the saved games from the database it calls a function from the dbconnect class that in turn looks in the database to 
        /// see where it can find 
        /// </summary>
        public List<string> Saves
        {
            get { return dbConnect.SaveNames(); }          
        }
        /// <summary>
        /// Constructor for the saveloadmanager introducing the connectionwithDatabase script.
        /// </summary>
        public SaveLoadManager()
        {
            dbConnect = new ConnectWithDataBase();
        }
        /// <summary>
        /// Method that saves down the current game in the form of information
        /// </summary>
        /// <param name="save"></param>
        public void SaveGame(Game save)
        {            
            SGame savefile = new SGame();
            savefile.GameName = save.GamesName;
            savefile.NumOfPlayers = save.PlayerLimit;
            savefile.Players = new List<SPlayer>();
            savefile.SavedDeck = new SDeck();
            //Savemethods that fill the deck and list of players with adequate data
            CreatePlayerSavefiles(savefile, save);
            SpecifySaveDeck(savefile.SavedDeck, save.CurrentDeck);         
            dbConnect.SaveDownToDataBase(savefile);

        }
        /// <summary>
        /// Reads in the active players from the list of players in the active game saving the data needed to start up a new round with 
        /// an old savefile later on.
        /// </summary>
        /// <param name="save"></param>
        /// <param name="gamefile"></param>
        private void CreatePlayerSavefiles(SGame save,Game gamefile)
        {
            for(int i = 0; i < save.NumOfPlayers; i++)
            {
                SPlayer add = new SPlayer();
                add.Name = gamefile.Contest[i].Name;
                add.Draswleft = gamefile.Contest[i].DrawsLeft;
                add.Myturn = gamefile.Contest[i].Turn;
                add.Winner = gamefile.Contest[i].Winner;
                add.Victories = gamefile.Contest[i].Victories;
                save.Players.Add(add);
            }
        }
        /// <summary>
        /// Method that creates files for the cards of the deck based on the currently used one
        /// </summary>
        /// <param name="save"></param>
        /// <param name="savefrom"></param>
        private void SpecifySaveDeck(SDeck save,Deck savefrom)
        {
            int parsed = ParseNoDecksToInt(savefrom.NoDecks);
            save.SavedCards = new List<SCard>();
            save.Size = parsed;
            foreach(Card c in savefrom.cards)
            {
                SCard saveCopy = new SCard();
                saveCopy.Name = c.Name;
                saveCopy.Value = c.CardValue;
                saveCopy.Suit = ParseSuitToString(c.Suit);
                save.SavedCards.Add(saveCopy);
            }
        }
        /// <summary>
        /// Get which a number representing how many decks of cards is in a game.
        /// </summary>
        private int ParseNoDecksToInt(NumberOfDecks size)
        {
            int mySize = 0;
            switch (size)
            {
                case NumberOfDecks.One:
                    mySize = 1;
                    break;
                case NumberOfDecks.Two:
                    mySize = 2;
                    break;
                case NumberOfDecks.Three:
                    mySize = 3;
                    break;
            }
            return mySize;
        }
        /// <summary>
        /// function used to get the string value for the suit of a card one which to save down
        /// </summary>
        /// <returns></returns>
        private string ParseSuitToString(Suits suit)
        {
            string suitName = "default";
            switch (suit)
            {
                case Suits.Clubs:
                    suitName = "Clubs";
                    break;
                case Suits.Diamonds:
                    suitName = "Diamonds";
                    break;
                case Suits.Spades:
                    suitName = "Spades";
                    break;
                case Suits.Hearts:
                    suitName = "Hearts";
                    break;
            }
            return suitName;
        }
        /// <summary>
        /// returns a previously saved game if a save with matching name can be found
        /// </summary>
        /// <param name="gameName"></param>
        /// <returns></returns>
        public Game LoadedSave(string gameName)
        {           
            SGame found = dbConnect.Load(gameName);
            if (found != null)
            {
                Game loadedSave = new Game();
                loadedSave.GamesName = found.GameName;
                loadedSave.PlayerLimit = found.NumOfPlayers;
                loadedSave.CurrentDeck = new Deck();
                RetrieveDeck(loadedSave.CurrentDeck, found.SavedDeck);
                LoadPlayers(loadedSave.Contest, found,loadedSave.CurrentDeck);
                
                return loadedSave;
            }
            else
                throw new ArgumentNullException("Save could not be found");
            
        }
        /// <summary>
        /// Method that creates a set of player files using the data found in the database
        /// </summary>
        /// <param name="pl"></param>
        /// <param name="load"></param>
        /// <param name="curr"></param>
        private void LoadPlayers(List<Player>pl, SGame load, Deck curr)
        {
            foreach(SPlayer loadpl in load.Players)
            {
                Player retrieved = new Player();
                retrieved.Name = loadpl.Name;
                retrieved.DrawsLeft = loadpl.Draswleft;
                retrieved.Turn = loadpl.Myturn;
                retrieved.Winner = loadpl.Winner;
                retrieved.Victories = loadpl.Victories;
                retrieved.CurrentDeck = curr;
                pl.Add(retrieved);

            }
        }
        /// <summary>
        /// Method that retrieves the information for the deck class and its subservient cards
        /// dependent on the information saved to the database
        /// </summary>
        /// <param name="load"></param>
        /// <param name="retrieve"></param>
        private void RetrieveDeck(Deck load,SDeck retrieve)
        {
            load.NoDecks = RetrieveSize(retrieve.Size);
            foreach(SCard retc in retrieve.SavedCards)
            {
                Card retrieved = new Card();
                retrieved.CardValue = retc.Value;
                retrieved.Name = retc.Name;
                retrieved.Suit = RetrieveSuit(retc.Suit);
                retrieved.Score();
                load.cards.Add(retrieved);
            }
        }
        /// <summary>
        /// puts an int through a switch statement and returns a number of decks enum
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private NumberOfDecks RetrieveSize(int size)
        {
            NumberOfDecks no = NumberOfDecks.One;
            switch (size)
            {
                case 1:
                    no = NumberOfDecks.One;
                    break;
                case 2:
                    no = NumberOfDecks.Two;
                    break;
                case 3:
                    no = NumberOfDecks.Three;
                    break;

            }
            return no;
        }
        /// <summary>
        /// returns a suit based on a string sent into the function below
        /// </summary>
        /// <param name="suitstring"></param>
        /// <returns></returns>
        private Suits RetrieveSuit(string suitstring)
        {
            Suits s = Suits.Clubs;
            switch(suitstring)
            {
                case "Clubs":
                    s = Suits.Clubs;
                    break;
                case "Diamonds":
                    s = Suits.Diamonds;
                    break;
                case "Spades":
                    s = Suits.Spades;
                    break;
                case "Hearts":
                    s = Suits.Hearts;
                    break;
            }
            return s;
        }
    }
}
