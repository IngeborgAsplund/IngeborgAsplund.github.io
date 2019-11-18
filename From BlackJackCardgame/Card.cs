using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund 2018
namespace CardGameUtilities
{
    /// <summary>
    /// CardObject used by the deck it contains a value a suit a name and a method to get the full information contained in this class
    /// out of it.
    /// </summary>
    public class Card: IComparable
    {
        //instance variables
        private int cvalue;
        private Suits cardSuit;
        private string name;
        //properties
        /// <summary>
        /// property for the value of the card
        /// </summary>
        public int CardValue
        {
            get { return cvalue; }
            set { cvalue = value; }
        }
        /// <summary>
        /// Property for the suit of the card
        /// </summary>
        public Suits Suit
        {
            get { return cardSuit; }
            set { cardSuit = value; }
        }
        /// <summary>
        /// Property for the name of the card
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// constrcutor for the card class
        /// </summary>
        public Card()
        {
        }
        /// <summary>
        /// method that sets a name of the cards
        /// </summary>
        public void AssignName()
        {
            switch (CardValue)
            {
                case 1:
                    name = "Ace";
                    break;
                case 11:
                    name = "Jack";
                    break;
                case 12:
                    name = "Queen";
                    break;
                case 13:
                    name = "King";
                    break;
                default:
                    name = CardValue.ToString();
                    break;
            }
        }
        /// <summary>
        /// Method that depending of the value of the card calculates the cards scoring points
        /// used by the playerhand item to determine the final score of the hand.//Method tested and works
        /// </summary>
        public int Score()
        {
            int score = 0;// score starts out by default
            switch (CardValue)
            {
                case 1:
                    score = 13;// max amount of score is ten and given to the ace
                    break;
                case 11:
                    score =10 ;
                    break;
                case 12:
                    score = 11;
                    break;
                case 13:
                    score = 12;
                    break;
                default:
                    score = CardValue-1;// all other cards given 1 less score than their actual cardvalue
                    break;
            }
            return score;
        }
        /// <summary>
        /// Method that returns all of the information we need to know about the card inform of its value(name) and its suit
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string fullName = Name+ Suit.ToString();
            return fullName;
        }
        /// <summary>
        /// Implementation of the one needed method for the Icomparable interface to function properly is implemented
        /// due to that at least one class will want to sort a list of cards
        /// </summary>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            Card valueComp = obj as Card;
            if (valueComp != null)
            {
                return this.cvalue.CompareTo(valueComp.cvalue);
            }
            else
                throw new ArgumentException("Object is not a card");
        }
    }
}
