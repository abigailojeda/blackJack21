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

    //CARD
    public class Card
    {
        public char suit;
        public int value;

        public Card(char suit, int value)
        {
            suit = this.suit;
            value = this.value;
        }

        public string GetInfo()
        {
            return value.ToString() + suit.ToString();
        }

        public int GetValue()
        {
            return value;
        }
        public char GetSuit()
        {
            return suit;
        }
    }

    //DECK
public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            InitializeDeck();
        }

        public int Count()
        {
            return cards.Count;
        }

        public void ShowDeck()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.GetInfo());
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        public Card Draw()
        {
            if (cards.Count > 0)
            {
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                return drawnCard;
            }
            else
            {
                return null; // La baraja está vacía
            }
        }

        private void InitializeDeck()
        {
            cards = new List<Card>();
            string[] suits = new string[] { "♠", "♣", "♥", "♦" };
            string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    cards.Add(new Card(suit, value));
                }
            }
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
