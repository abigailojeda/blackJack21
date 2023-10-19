using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Card
    {
        public char Suit;
        public int Value;

        public Card(char suit, int value)
        {
            Suit = suit;
            Value = value;
        }

        public string GetInfo()
        {
            return Value.ToString() + Suit.ToString();
        }
    }

    //ENUM 
    public enum Suit
    {
        Corazon = '♥',
        Diamante = '♦',
        Trebol = '♣',
        Pica = '♠'
    }

  



}
