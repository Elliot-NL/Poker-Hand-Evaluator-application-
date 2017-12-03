using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Calculator
{
    public static class Hands
    {
        //Enums moved to HandEvaluator.cs
        public enum HAND
        {
            Nothing,
            HighCard,
            Pair,
            TwoPair,
            ThreeOfKind,
            Straight,
            Flush,
            FullHouse,
            FourOfKind,
            StraightFlush,
            RoyalFlush

        }
    }
}
