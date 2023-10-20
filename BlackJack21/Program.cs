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
            //initialize deck
            Deck game = new Deck();

            //number of cards:
            Console.WriteLine("NUMBER OF CARDS: " + game.Count().ToString() );

            ////show cards: 
            //Console.WriteLine("CARDS: "  );
            //game.ShowDeck();

            ////shuffle deck:
            game.Shuffle();
            //Console.WriteLine("CARDS AFTER SHUFFLE: ");
            //game.ShowDeck();

            //steal a card
            Card stolenCard = game.Draw();
            Console.WriteLine("STOLEN CARD: " + stolenCard.GetInfo());
            
            string input = Console.ReadLine();
        }
    }

    //CARD
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

        public int GetValue()
        {
            return Value;
        }
        public char GetSuit()
        {
            return Suit;
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
                cards[0].GetInfo();
                Card drawnCard = cards[0];
                cards.RemoveAt(0);
                return drawnCard;
            }
            else
            {
                return null; 
            }
        }

        private void InitializeDeck()
        {
            //Console.WriteLine("¡Hola, mundo!");

            cards = new List<Card>();
            Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));
            
               
            int[] values = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            foreach (Suit suit in suits)
            {
                foreach (int value in values)
                {
                    Card card = new Card((char)suit, value);
                    cards.Add(card);
                }
            }

            //foreach (Card card in cards)
            //{
            //    Console.WriteLine(card.GetInfo());
            //}

        }

    }

    //PLAYER
    public class Player
    {
        public string name;
        public List<Card> hand;

        public Player(string Name, List<Card> Hand)
        {
            name = Name;
            hand = Hand;
        }

        public void addCard(Card card)
        {
            hand.Add(card);
        }

        public void ShowHandInfo()
        {
            foreach (Card card in hand)
            {
                Console.WriteLine(card.GetInfo());
            }
        }

    }

    //BLACKJACK PLAYER
    public class BlackjackPlayer : Player
    {
        public string test;
       public BlackjackPlayer(string name, List<Card> hand) : base(name, hand)
        {
           
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
