using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Poker_Hand_Calculator
{
    
    class Card
    {
        
        public Rank cardrank { get; set; }
        public Suit cardsuit { get; set; }

        /// create new way of dynamically retrieveing the suit and rank
      
        public enum Rank
        {
            Two = 2,
            Three,
            Four,
            Five,
            Six, 
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        public enum Suit
        {
            Clubs,
            Spades,
            Hearts,
            Diamonds
        }
    }
}
