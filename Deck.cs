using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Calculator
{
    class Deck : Card
    {
        const int noOfCards = 52; // standard deck
        private Card[] deck; // All playing cards

        public Deck()
        {
            deck = new Card[noOfCards];
        }

        public Card[] getDeck
        {
            get
            {
                return deck;
                // gets current deck
            }
        }
        //create deck of 52 cards: 13 values each with 4 suits

        public void setUpDeck()
        {
            int i = 0;
            foreach(Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach(Rank r in Enum.GetValues(typeof(Rank)))
                {
                    deck[i] = new Card { cardsuit = s, cardrank = r };
                    i++;
                }
            }
        }

        public void SuffleCards()
        {
            Random rand = new Random();
            Card temp;

            //run shuffle 1000 times
            for(int shuffletimes = 0; shuffletimes < 1000; shuffletimes++)
            {
                for(int i = 0; i < noOfCards; i++)
                {
                    //swap cards
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }
    }
}
