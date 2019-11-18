using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Threading.Tasks;
using CardGameUtilities;
//By Ingeborg Asplund
namespace GameAndAIUtilities
{
    /// <summary>
    /// This is a class working as a gameManager handling turns, keeping track of winning conditions and 
    /// applying the general simplyfied rules of the game.
    /// </summary>
    public class Game
    {
        //instance variables
        Deck deck;//the deck being used in this game
        List<Player> contestants;//the players present in the game
        Player activePlayer;//the currently active player 
        Dealer betty;// dealer ai this are used by subservient classes as well a with this        
        string gameId;
        int numberOfPlayers;
        /// <summary>
        /// property for the games name
        /// </summary>
        public string GamesName
        {
            get { return gameId; }
            set { gameId = value; }
        }
        /// <summary>
        /// Get property returning list of players in the game
        /// </summary>
        public List<Player> Contest
        {
            get { return contestants; }
        }
        /// <summary>
        /// Property for the number of players
        /// </summary>
        public int PlayerLimit
        {
            get { return numberOfPlayers; }
            set { numberOfPlayers = value; }
        }
        /// <summary>
        /// Returns the number of players in the game
        /// </summary>
        public int PlayersInGame
        {
            get { return contestants.Count; }
        }
        /// <summary>
        /// Get property that returns the index of the currently active player, used by interface to keep track on which playerhand to show
        /// and which to close
        /// </summary>
        public Player ActivePlayer
        {
            get { return activePlayer; }
        }
        /// <summary>
        /// Get property for the deck used in this game it is used by the programs associated with the game such as the gameboard
        /// behind the scenes code
        /// </summary>
        public Deck CurrentDeck
        {
            get { return deck; }
            set { deck = value; }
        }
        /// <summary>
        /// Constructor setting up and arranging the variables needed for this class to function properly
        /// </summary>
        public Game()
        {
            betty = new Dealer();
            contestants = new List<Player>();          
        }
        /// <summary>
        /// Get Property for the dealer class, if a player want to acess the dealer it can be done through here
        /// as game.betty can be passed for specific funtions
        /// </summary>
        public Dealer Betty
        {
            get { return betty; }            
        }
        /// <summary>
        /// Method for creating the Deck adding the cards and shuffle them. It also sets the name of the current game
        /// and the prefered number of players to participate
        /// </summary>
        /// <param name="num"></param>
        public void CreateDeck(NumberOfDecks num, string name, int players)
        {
            deck = new Deck();
            deck.NoDecks = num;
            deck.FillDeck();
            deck.Shuffle();
            gameId = name;
            numberOfPlayers = players;
            betty.d = deck;
        }
        /// <summary>
        /// Add a player to the list of players setting their name and 
        /// </summary>
        /// <param name="name"></param>
        public void AddPlayer(string name)
        {
            if (contestants.Count < numberOfPlayers)
            {
                Player toAdd = new Player();
                toAdd.Name = name;
                toAdd.CurrentDeck = deck;
                contestants.Add(toAdd);
            }
            else
                MessageBox.Show("You cannot add any more players than you originally assigned for this game","Error");
        }
        /// <summary>
        /// method that starts up the game and spawns the playerhand of the player that is first in line
        /// </summary>
        public void StartGame()
        {
            activePlayer = contestants[0];
            activePlayer.DrawsLeft = 2;
            activePlayer.Turn = true;
        }
        /// <summary>
        /// Function that a)updates the dealers hand and cards throgh her actions and b switches the turn over to the 
        /// next player in line
        /// </summary>
        public void SwitchTurn()
        {
            //dealers turn inserted here
            int index = contestants.IndexOf(activePlayer);// index of currently active player
            if (index != contestants.Count - 1)
            {
                activePlayer = contestants[index + 1];
               
            }
            else
                activePlayer = contestants[0];
            activePlayer.DrawsLeft = 2;
            activePlayer.Turn = true;

        }
        /// <summary>
        /// Function that looks for a winner before a new turn is started, if any of the players score is above 21
        /// the game will find the players that has a lower than 21 score that is higher than the dealer and pick the one
        /// with the highest score among them as the winner. If nobody but the player with the score above 21 comes over the dealer
        /// in points or if the dealer reaches the limit first no one winns
        /// </summary>
        public void CheckWinningConditions()
        {
            if (betty.DealScore < 21)// if the dealers score is below 21
            {
                Player trigger;// this saves the information about the player first to break the 21 score barrier, he is sorted out of the list of players                
                foreach (Player p in contestants)
                {
                    if (p.MyHand.Score > 21)
                    {
                        trigger = p;// save this player for later(he is added again after the winner is declared)
                        contestants.Remove(p);
                        List<Player> candidates = new List<Player>();
                        foreach (Player pl in contestants)
                        {
                            if (pl.MyHand.Score > betty.DealScore)
                                candidates.Add(pl);
                        }
                        if (candidates.Count > 1)
                        {
                            candidates.Sort();
                            candidates[candidates.Count - 1].Winner = true;// assign winner                           

                        }
                        else if (candidates.Count == 1)
                            candidates[0].Winner = true;
                        else
                            betty.Winner = true;
                        contestants.Add(trigger);// add trigger back in to the list
                        break;
                    }
                }

            }
            else
                betty.Winner = true;
                                      
        }
        /// <summary>
        /// Returns the player which has its winner bool set to true
        /// </summary>
        /// <returns></returns>
        public Player Winner()
        {
            Player toReturn = null;
            foreach(Player pl in contestants)
            {
                if (pl.Winner == true)
                    toReturn = pl;
            }
            return toReturn;
        }
        /// <summary>
        /// This function is used to reset all the players to their initial score level, remove all of their current cards on hand
        /// and clear their active cards.
        /// </summary>
        public void ResetGame()
        {
            foreach(Player p in contestants)
            {
                p.MyHand.AktiveCard = null;
                p.MyHand.Cards.Clear();
                p.Turn = false;
                p.Winner = false;
                p.MyHand.Score = 0;
            }
            deck.Reset();
            betty.ResetDealer();
        }
       
        
       
    }
}
