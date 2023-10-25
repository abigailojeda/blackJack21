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
            int objective = 21;

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
            //Card stolenCard = game.Draw();
            //Console.WriteLine("STOLEN CARD: " + stolenCard.GetInfo());

            Card card1 = game.Draw();
            Card card2 = game.Draw();

            List<Card> cards = new List<Card>();
            cards.Add(card1);
            cards.Add(card2);

            //INITIALIZE BLACKJACK PLAYER
            BlackjackPlayer player = new BlackjackPlayer("Pepe", cards);
            player.ShowHandInfo();

            bool finish = false; 

            while (!finish)
            {
                int points = player.GetPlayerPoints(); 

                if (points > objective)
                {
                    Console.WriteLine("Has perdido, con " + points + " puntos");
                    break; 
                }
                else if (points == objective)
                {
                    Console.WriteLine("Has ganado, con " + points + " puntos");
                    break; 
                }
                else
                {
                    Console.WriteLine("Tienes " + points + " puntos");

                    Console.WriteLine("Selecciona\n1.hit\n2.stand");
                    string option = Console.ReadLine();

                    if (option == "1")
                    {
                        Card newCard = game.Draw();
                        player.AddCard(newCard);
                        player.ShowHandInfo();
                    }
                    else if (option == "2")
                    {
                        Console.WriteLine("Bye bye!");
                        finish = true; 
                    }
                }
            }


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
            cards = new List<Card>();
            Suit[] suits = (Suit[])Enum.GetValues(typeof(Suit));
            
               
            int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

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

        public void AddCard(Card card)
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
      
       public BlackjackPlayer(string name, List<Card> hand) : base(name, hand)
        {
           
        }

        public bool HasAs(Card card)
        {
            return card.GetValue() == 1;
        }

        public int GetPlayerPoints()
        {
            int points = 0;
            foreach (var card in hand)
            {
                int cardValue = card.GetValue();
                if (cardValue == 1)
                {
                    points += 11;
                }
                else
                {
                    points += card.GetValue();
                }
            }
            return points;
        }

        public bool PlayerLose()
        {
            return GetPlayerPoints() > 21;
        }
    }

    //CRUPIER
    public class Crupier : BlackjackPlayer
    {
       
        public Crupier(string name, List<Card> hand) : base(name, hand)
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
