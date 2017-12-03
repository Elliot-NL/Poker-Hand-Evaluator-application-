using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Calculator
{
    

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class HandEvaluator : Card
    {
        private int heartsSum;
        private int clubsSum;
        private int spadesSum;
        private int diamondsSum;

        private Card[] cards;
        private HandValue handValue;

        public HandEvaluator(Card[] sortedHand)
        {
            heartsSum = 0;
            clubsSum = 0;
            spadesSum = 0;
            diamondsSum = 0;

            //for the number of cards in hand:
            cards = new Card[5];
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                //for the number of cards in hand:
                cards[0] = value[0];
                cards[0] = value[0];
                cards[0] = value[0];
                cards[0] = value[0];
                cards[0] = value[0];
            }
        }

        public Hands EvaluateHand()
        {
            getNumberOfSuit();
            if (fourOfAKind())
                return Hands.FourOfKind;
            else if (fullHouse())
                return Hands.FourOfKind;
            else if (Flush)
                return Hands.Flush;
            else if (Straight())
                return Hands.Straight;
            else if (ThreeOfKind())
                return Hands.ThreeOfKind;
            else if (TwoPair())
                return Hands.TwoPair;
            else if (Pair())
                return Hands.Pair;

            //High card wins:
            handValue.HighCard = (int)cards[4].cardrank;
            return Hands.Nothing;

        }

        private void getNumberOfSuit()
        {
            foreach(var element in Cards)
            {
                if(element.cardsuit == Card.Suit.Hearts)
                {
                    heartsSum++;
                }
                else if (element.cardsuit == Card.Suit.Diamonds)
                {
                    diamondsSum++;
                }
                else if (element.cardsuit == Card.Suit.Clubs)
                {
                    clubsSum++;
                }
                else if (element.cardsuit == Card.Suit.Spades)
                {
                    spadesSum++;
                }
            }
        }

        private bool fourOfAKind()
        {
            if (cards[0].cardrank == cards[1].cardrank && cards[0].cardrank == cards[2].cardrank && cards[0].cardrank == cards[3].cardrank)
            {
                handValue.Total = (int)cards[1].cardrank * 4;
                handValue.HighCard = (int)cards[4].cardrank;
                return true;
            }
            else if (cards[1].cardrank == cards[2].cardrank && cards[1].cardrank == cards[3].cardrank && cards[1].cardrank == cards[4].cardrank)
            {
                handValue.Total = (int)cards[1].cardrank * 4;
                handValue.HighCard = (int)cards[0].cardrank;
                return true;
            }

            return false;
        }

        private bool fullHouse()
        {
            if((cards[0].cardrank == cards[1].cardrank && cards[0].cardrank == cards[2].cardrank && cards[3].cardrank == cards[4].cardrank)||
                (cards[0].cardrank == cards[1].cardrank && cards[2].cardrank == cards[3].cardrank && cards[3].cardrank == cards[4].cardrank))
            {
                handValue.Total = (int)(cards[0].cardrank) + (int)(cards[1].cardrank) + (int)(cards[2].cardrank) +
                    (int)(cards[3].cardrank) + (int)(cards[4].cardrank);
                return true;
            }

            return false;
        }

        private bool Flush()
        {
            if(heartsSum == 5 || diamondsSum == 5 || clubsSum == 5 || spadesSum == 5)
            {
                handValue.Total = (int)cards[4].cardrank;
                return true;
            }
            return false;
        }

        private bool Straight()
        {
            if (cards[0].cardrank + 1 == cards[1].cardrank &&
               cards[1].cardrank + 1 == cards[2].cardrank &&
               cards[2].cardrank + 1 == cards[3].cardrank &&
               cards[3].cardrank + 1 == cards[4].cardrank)
            {
                handValue.Total = (int)cards[4].cardsuit;
                return true;
            }

            return false;
        }

        private bool ThreeOfKind()
        {
            if((cards[0].cardrank == cards[1].cardrank && cards[0].cardrank == cards[3].cardrank) ||
               (cards[1].cardrank == cards[2].cardrank && cards[1].cardrank == cards[3].cardrank))
                {
                handValue.Total = (int)cards[2].cardrank * 3;
                handValue.HighCard = (int)cards[4].cardrank;
            }
            else if (cards[2].cardrank == cards[3].cardrank && cards[2].cardrank == cards[4].cardrank)
            {
                handValue.Total = (int)cards[2].cardrank * 3;
                handValue.HighCard = (int)cards[1].cardrank;
                return true;
            }

            return false;
                               
        }

        private bool TwoPair()
        {
            if(cards[0].cardrank == cards[1].cardrank && cards[2].cardrank == cards[3].cardrank)
            {
                handValue.Total = ((int)cards[1].cardrank * 2) + (int)cards[3].cardrank * 2;
                handValue.HighCard = (int)cards[4].cardsuit;
                return true;
            }
            else if(cards[0].cardrank == cards[1].cardrank && cards[3].cardrank == cards[4].cardrank)
            {
                handValue.Total = ((int)cards[1].cardrank * 2) + (int)cards[3].cardrank * 2;
                handValue.HighCard = (int)cards[2].cardsuit;
                return true;
            }
            else if (cards[1].cardrank == cards[2].cardrank && cards[3].cardrank == cards[4].cardrank)
            {
                handValue.Total = ((int)cards[1].cardrank * 2) + (int)cards[3].cardrank * 2;
                handValue.HighCard = (int)cards[0].cardsuit;
                return true;
            }

            return false;
        }

        private bool Pair()
        {
            if(cards[0].cardrank == cards[1].cardrank)
            {
                handValue.Total = (int)cards[0].cardrank * 2;
                handValue.HighCard = (int)cards[4].cardrank;
                return true;
            }
            else if(cards[1].cardrank == cards[2].cardrank)
            {
                handValue.Total = (int)cards[1].cardrank * 2;
                handValue.HighCard = (int)cards[4].cardrank;
                return true;
            }
            else if (cards[3].cardrank == cards[4].cardrank)
            {
                handValue.Total = (int)cards[2].cardrank * 2;
                handValue.HighCard = (int)cards[2].cardrank;
                return true;
            }

            return false;
        }
    }
}
