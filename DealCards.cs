using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Calculator
{
    class DealCards : Deck
    {
        private Card[] playerHand;
        private Card[] computerHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;

        public DealCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            computerHand = new Card[5];
            sortedComputerHand = new Card[5];
        }

        public void Deal()
        {
            setUpDeck(); //Creates deck of cards and shuffle
            GetHand();
            SortCard();
            DisplayCards();
            EvaluateHands();
        }

        public void GetHand()
        {
            for(int i = 0; i < 5; i++)
            
                //Players hand created here:
                playerHand[i] = getDeck[i];
            

            for (int i = 5; i < 10; i++)
            
                //Computers hand created here:
                computerHand[i -5] = getDeck[i];
            
        }

        public void SortCard()
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.cardrank
                              select hand;

            var queryComputer = from hand in computerHand
                                orderby hand.cardrank
                                select hand;

            var index = 0;
            foreach(var element in queryPlayer.ToList())
            
                sortedPlayerHand[index] = element;
                index++;

            index = 0;
            foreach (var element in queryComputer.ToList())
            
                sortedComputerHand[index] = element;
                index++;
            

        }

        public void DisplayCards()
        {
            Console.Clear();
            //Position of the cursor. Left & Right
            int x = 0; 
            int y = 1;

            //Display Player Hand:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Players Hand");
            for(int i = 0; i < 5; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedPlayerHand[i], x, y);
                x++;//Move Right
            }
            y = 15; // move row of computer cards below players cards
            x = 0; // reset x position 
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Computers Hand");
            for (int i = 5; i < 10; i++)
            {
                DrawCards.DrawCardOutline(x, y);
                DrawCards.DrawCardSuitValue(sortedComputerHand[i-5], x, y);
                x++;//Move Right
            }
        }

        public void EvaluateHands()
        {
            //Create players card Evaluation
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);
            HandEvaluator computerHandEvaluator = new HandEvaluator(sortedComputerHand);

            Hands playerHand = playerHandEvaluator.EvaluateHand();
            Hands computerHand = computerHandEvaluator.EvaluateHand();

            Console.WriteLine("\n\n\n\n\nPlayers Hand: " + playerHand);
            Console.WriteLine("\n\n\n\n\nPlayers Hand: " + computerHand);

            if(playerHand > computerHand)
            {
                Console.WriteLine("Player Wins");
            }
            else if(playerHand < computerHand)
            {
                Console.WriteLine("Computer Wins");
            }
            else
            {
                //re-evaluate hands:
                if(playerHandEvaluator.HandValues.Total > computerHandEvaluator.HandValues.Total)
                {
                    Console.WriteLine("Player Wins");
                }

                else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
                {
                    Console.WriteLine("Computer Wins");
                }

                //re-evaluate hands:
                else if (playerHandEvaluator.HandValues.HighCard > computerHandEvaluator.HandValues.HighCard)
                {
                    Console.WriteLine("Player Wins");
                }

                else if (playerHandEvaluator.HandValues.HighCard < computerHandEvaluator.HandValues.HighCard)
                {
                    Console.WriteLine("Computer Wins");
                }

                else
                {
                    Console.WriteLine("Draw, no one wins");
                }
            }
        } 
    }
}
