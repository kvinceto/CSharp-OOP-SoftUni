using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }

    public class Engine
    {
        public void Run()
        {
            List<Card> cards = new List<Card>();
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string cardInfo in input)
            {
                try
                {
                    string[] cardData = cardInfo
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    bool isChar = cardData[1].Length == 1;
                    if (!isChar)
                        throw new ArgumentException("Invalid card!");
                    Card card = new Card(cardData[0], Char.Parse(cardData[1]));
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
    public class Card
    {
        private HashSet<string> validCardsFaces;
        private string face;
        private char suit;
        public Card()
        {
            validCardsFaces = new HashSet<string>
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };
        }

        public Card(string face, char suit) : this()
        {
            this.face = ValidateFace(face);
            this.suit = ValidateSuit(suit);
        }

        private string ValidateFace(string face)
        {
            string f = validCardsFaces.FirstOrDefault(f => f == face);
            if(f == null)
                throw new ArgumentException("Invalid card!");
            return f;
        }

        private char ValidateSuit(char suit)
        {
            char s;
            switch (suit)
            {
                case 'S': s = '\u2660'; break;
                case 'H': s = '\u2665'; break;
                case 'D': s = '\u2666'; break;
                case 'C': s = '\u2663'; break;
                default:
                    throw new ArgumentException("Invalid card!");
            }
            return s;
        }
        public override string ToString()
        {
            return $"[{this.face}{this.suit}]";
        }
    }
}
