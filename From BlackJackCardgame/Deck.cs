using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//By Ingeborg Asplund
namespace CardGameUtilities
{
    /// <summary>
    /// This class contains the main functionality of the deck in the form of public functions called by the ui when the buttons regarding
    /// different functionalities 
    /// </summary>
    public class Deck
    {
        //Instance variables
        private List<Card> cardsInGame;
        private NumberOfDecks numOfDecks;
        //Properties for this class
        /// <summary>
        /// Get property for the list of cards 
        /// </summary>
        public List<Card> cards
        {
            get { return cardsInGame; }
        }
        /// <summary>
        /// Property for the number of decks used in the game
        /// </summary>
        public NumberOfDecks NoDecks
        {
            get { return numOfDecks; }
            set { numOfDecks = value; }
        }
        /// <summary>
        /// constructor setting up the main functionality of the deck
        /// </summary>
        public Deck()
        {
            cardsInGame = new List<Card>();
        }
        /// <summary>
        /// method that fills the deck with cards which are done slightly differently dependent
        /// on the number of decks choosen to play with. There is three sizes of decks 1, 2 and 3.
        /// This method is tested and runs sucessfully, in case of troubles accumulating in the future this 
        /// one is innocent.
        /// </summary>
        public void FillDeck()
        {
            switch (NoDecks)
            {
                case NumberOfDecks.One:
                    CreateClubs();
                    CreateDiamonds();
                    CreateSpades();
                    CreateHearts();
                    break;
                case NumberOfDecks.Two: 
                    for(int i = 0; i < 2; i++)
                    {
                        CreateClubs();
                        CreateDiamonds();
                        CreateSpades();
                        CreateHearts();
                    }
                    break;
                case NumberOfDecks.Three:
                    for(int it = 0; it < 3; it++)
                    {
                        CreateClubs();
                        CreateDiamonds();
                        CreateSpades();
                        CreateHearts();
                    }
                    break;
            }
        }
        
        /// <summary>
        /// The below method creates all cards that are clubs(it can be run more than once and is called from inside a loop when more instances is run)
        /// </summary>
        private void CreateClubs()
        {
            int c = 1;
            for (c = 1; c <= 13;c++)
            {
                Card club = new Card();
                club.CardValue = c;
                club.Suit = Suits.Clubs;
                club.AssignName();
                cardsInGame.Add(club);
            }
        }
        /// <summary>
        /// Same as the above but with diamonds
        /// </summary>
        private void CreateDiamonds()
        {
            int d = 1;
            for (d = 1; d <= 13; d++)
            {
                Card diamond = new Card();
                diamond.CardValue = d;
                diamond.Suit = Suits.Diamonds;
                diamond.AssignName();
                cardsInGame.Add(diamond);
            }
        }
        /// <summary>
        /// As above but with spades
        /// </summary>
        private void CreateSpades()
        {
            int s = 1;
            for (s = 1; s <= 13; s++)
            {
                Card spade = new Card();
                spade.CardValue = s;
                spade.Suit = Suits.Spades;
                spade.AssignName();
                cardsInGame.Add(spade);
            }
        }
        /// <summary>
        /// As above but with hearts
        /// </summary>
        private void CreateHearts()
        {
            int h = 1;
            for (h = 1; h <= 13; h++)
            {
                Card heart = new Card();
                heart.CardValue = h;
                heart.Suit = Suits.Hearts;
                heart.AssignName();
                cardsInGame.Add(heart);
            }
        }
        /// <summary>
        /// method that schuffles the cards using a while loop that takes random cards out of the original list of cards
        /// and put them into a new list which are then assigned as the original list of cards. Method is tested and runs sucessfully
        /// </summary>
        public void Shuffle()
        {
            if (cardsInGame.Count < 8)
            {
                cardsInGame.Clear();
                FillDeck();
            }
            Random cardrand = new Random();
            List<Card> shuffle = new List<Card>();
            while (cardsInGame.Count > 0)
            {
                int cardToMove = cardrand.Next(cardsInGame.Count);
                shuffle.Add(cardsInGame[cardToMove]);
                cardsInGame.RemoveAt(cardToMove);
            }
            cardsInGame = shuffle;
        }
        /// <summary>
        /// Method for drawing a new card, it automatically draws the topmost card. This function is tested and made run satisfyingly
        /// returning the expected results.(topmost card in the deck)
        /// </summary>
        /// <returns></returns>
        public Card DrawCard()
        {
            CheckCardsLeft();
            Card drawn = cardsInGame[0];// pick first element in the cardlist
            cardsInGame.Remove(drawn);
            return drawn;//return the card found
        }
        /// <summary>
        /// Checks if the deck in use is low on cards and refills+shuffle if so called first whenever a card is drawn
        /// from the deck preventing the game from running out of cards.
        /// </summary>
        private void CheckCardsLeft()
        {
            if(cardsInGame.Count<=8)
            {
                cardsInGame.Clear();
                FillDeck();
                Shuffle();
            }
        }
        /// <summary>
        /// Resetmethod for the deck used when a game is over and a new round can begin
        /// </summary>
        public void Reset()
        {
            cardsInGame.Clear();
            FillDeck();
            Shuffle();
        }

    }
}
