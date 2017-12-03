using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Hand_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new poker hand generator
            //Random Hands
            //Build Statistics off hands 

            //Part 5 
            //review ASCII Codes
            //Debug in downloaded folder

            //https://www.youtube.com/watch?v=gkJKqVo30LA

            Console.SetWindowSize(65, 40);//configure numbers
            //remove scoll bars by setting buffer to the actual window size 
            Console.BufferWidth = 65;
            Console.BufferHeight= 40;
            Console.Title = "Poker Hands";

            DealCards dc = new DealCards();
            bool quit = false;

            while(!quit)
            {
                dc.Deal();

                char selection = ' ';
                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.WriteLine("Play Again? Y/N");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (selection.Equals('Y'))
                        quit = false;
                    else if (selection.Equals('N'))
                        quit = true;
                    else
                        Console.WriteLine("Invalid Selection, try again");
                } 
            }

            Console.ReadLine();
            //symbols when encoded need changing 
        }
    }
}
