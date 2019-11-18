using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using CardGameUtilities;
//By Ingeborg Asplund 2018
namespace GameAndAIUtilities
{
    /// <summary>
    /// This class handles everything that have to do with the player
    /// </summary>
    public class Player:IComparable
    {
        private string playerName;//the name of the player
        private int drawsLeft;// the amount of draws left for the player to do
        private int victories;//variable determine the number of times this player came out a victor
        private bool myturn;//bool determining if it is still the current players turn
        private bool won; // bool that turns true only for the first player to hit the winning condition
        private Hand plHand;// hand
        private Deck deck;// the deck used this time
        //*******************************************************
        //properties
        /// <summary>
        /// property for the name of the player
        /// </summary>
        public string Name
        {
            get { return playerName; }
            set { playerName = value; }
        }
        /// <summary>
        /// propety for the draws left for the player to use
        /// </summary>
        public int DrawsLeft
        {
            get { return drawsLeft; }
            set { drawsLeft = value; }
        }
        /// <summary>
        /// The number of times this player has won
        /// </summary>
        public int Victories
        {
            get { return victories; }
            set { victories = value; }
        }
        /// <summary>
        /// Property for the bool determine if it is the current players turn
        /// </summary>
        public bool Turn
        {
            get { return myturn; }
            set { myturn = value; }
        }
        /// <summary>
        /// bool that determines if a player has won the game
        /// </summary>
        public bool Winner
        {
            get { return won; }
            set { won = value; }
        }
        /// <summary>
        /// Property for the players hand
        /// </summary>
        public Hand MyHand
        {
            get { return plHand; }
        }
        /// <summary>
        /// Property for later useage, sets the current used deck as the deck for this class(assigned by the Game class)
        /// </summary>
        public Deck CurrentDeck
        {
            set { deck = value; }
        }
        //**************************************************************************
        //constructor
        /// <summary>
        /// Sets up the general information needed by the player class to function
        /// </summary>
        public Player()
        {
            plHand = new Hand();
            myturn = false;// by default it is never your turn
            drawsLeft = 0;// when it is your turn you will get two draws
            won = false; // obviously you do not starting out the game as a winner.
            victories = 0;
        }
        //**************************************************************************
        //Methods
        /// <summary>
        /// draws a new card and add to the playerhand
        /// </summary>
        public void DrawNewCard()
        {                      
           Card drawnew = deck.DrawCard();
           plHand.Cards.Add(drawnew);
           plHand.AktiveCard = drawnew;
           plHand.UpdateScore();
           DrawsLeft = DrawsLeft - 1;                        
        }
        /// <summary>
        /// swap cards with the dealer this is tested and proven to work as intended
        /// </summary>
        public void SwapCardsWithDealer(Dealer betty)
        {                      
            int cardplacepment = plHand.Cards.IndexOf(plHand.AktiveCard);
            Card swapped = betty.DealCard;
            betty.ReactToSwitch(plHand.AktiveCard);

            plHand.Cards.RemoveAt(cardplacepment);
            plHand.Cards.Insert(cardplacepment, swapped);
            plHand.AktiveCard = swapped;
            plHand.UpdateScore();
            DrawsLeft = DrawsLeft - 1;
        }
        /// <summary>
        /// discard card from hand this is also tested and proven to work as intended
        /// </summary>
        public void DiscardCardOnHand()
        {
            int deletehere = plHand.Cards.IndexOf(plHand.AktiveCard);
            plHand.Cards.RemoveAt(deletehere);
            if (plHand.Cards.Count > 0)
                plHand.AktiveCard = plHand.Cards[0];//always reset the active card to be the first card
            else plHand.AktiveCard = null;
            plHand.UpdateScore();
            DrawsLeft = DrawsLeft - 1;
        }
        /// <summary>
        /// method that switch active cards on the players hand depending on which way the player want to go
        /// either the next or previous card is shown given that the player has more than one card on hand as
        /// in which case the function handling input from the user will throw back an error, since that happen on another
        /// level in the application this function assumes the player has more than 1 card on hand when it is called
        /// </summary>
        /// <param name="nextPrev"></param>
        /// <param name="index"></param>
        public void CardCarousel(bool nextPrev)
        {
            int index = MyHand.Cards.IndexOf(MyHand.AktiveCard);// get the aktive cards index
            //if we want to go to the next card in hand
            if(nextPrev == true)
            {
                if (index != MyHand.Cards.Count - 1)// if the currrent card is not hte last item in hand
                {
                    int nextcard = index + 1;
                    MyHand.AktiveCard = MyHand.Cards[nextcard];
                }
                else
                    MyHand.AktiveCard = MyHand.Cards[0];// if we was at the last card in hand we come around to the first one
            }
            //if we want to go to the previous card
            if (nextPrev == false)
            {
                if (index != 0)//if the current card is not the first in the list
                {
                    int previouscard = index - 1;
                    MyHand.AktiveCard = MyHand.Cards[previouscard];
                }
                else
                    MyHand.AktiveCard = MyHand.Cards[MyHand.Cards.Count-1];// get the last card in the stack.
            }
        }
        /// <summary>
        /// Implementation of the Icomparable interface method of Compare to used by the classes to sort players
        /// in this case by their scores.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
       public int CompareTo(object obj)
        {
            Player compare = obj as Player;
            if (compare != null)
            {
                return this.MyHand.Score.CompareTo(compare.MyHand.Score);
            }
            else
                throw new ArgumentException("object is not a player");
        }

    }
}
