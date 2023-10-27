using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BlackJack21.Crupier;

namespace BlackJack21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    int objective = 21;

            //    //initialize deck
            //    Deck game = new Deck();

            //    //number of cards:
            //    Console.WriteLine("NUMBER OF CARDS: " + game.Count().ToString() );

            //    ////show cards: 
            //    //Console.WriteLine("CARDS: "  );
            //    //game.ShowDeck();

            //    ////shuffle deck:
            //    game.Shuffle();
            //    //Console.WriteLine("CARDS AFTER SHUFFLE: ");
            //    //game.ShowDeck();

            //    //steal a card
            //    //Card stolenCard = game.Draw();
            //    //Console.WriteLine("STOLEN CARD: " + stolenCard.GetInfo());

            //    Card card1 = game.Draw();
            //    Card card2 = game.Draw();

            //    List<Card> cards = new List<Card>();
            //    cards.Add(card1);
            //    cards.Add(card2);

            //    //INITIALIZE BLACKJACK PLAYER
            //    BlackjackPlayer player = new BlackjackPlayer("Pepe", cards);
            //    player.ShowHandInfo();
            //    player.DrawCards();
            //    Crupier crupier = new Crupier("Crupier", new List<Card>());
            //    crupier.Play(game);


            //    bool finish = false; 

            //    while (!finish)
            //    {
            //        int points = player.GetPlayerPoints(); 

            //        if (points > objective)
            //        {
            //            Console.WriteLine("Has perdido, con " + points + " puntos");
            //            break; 
            //        }
            //        else if (points == objective)
            //        {
            //            Console.WriteLine("Has ganado, con " + points + " puntos");
            //            break; 
            //        }
            //        else
            //        {
            //            Console.WriteLine("Tienes " + points + " puntos");

            //            Console.WriteLine("Selecciona\n1.hit\n2.stand");
            //            string option = Console.ReadLine();

            //            if (option == "1")
            //            {
            //                Card newCard = game.Draw();
            //                player.AddCard(newCard);
            //                player.ShowHandInfo();
            //                player.DrawCards();
            //            }
            //            else if (option == "2")
            //            {
            //                Console.WriteLine("Bye bye!");
            //                finish = true; 
            //            }
            //        }
            //    }


            //    string input = Console.ReadLine();
            //}
            Deck deck = new Deck();
            // Crear una instancia del jugador
            List<Card> playerHand = new List<Card>();
            BlackjackPlayer player = new BlackjackPlayer("Pepe", playerHand);

            // Crear una instancia del crupier
            List<Card> crupierHand = new List<Card>();
            Crupier crupier = new Crupier("Crupier", crupierHand);

            // Crear una instancia del juego de Blackjack
            BlackjackGame game = new BlackjackGame(player, crupier);

            // Iniciar el juego llamando al método PlayGame
            game.PlayGame(deck);

            Console.WriteLine("Juego terminado. Presiona Enter para salir.");
            Console.ReadLine();

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

        public void DrawCards()
        {
            string[] lines = new string[5];

            foreach (Card card in hand)
            {
                string cardValue = card.GetValue().ToString();
                char cardSuit = card.GetSuit();

                lines[0] += " +-----+";
                lines[1] += " |" + cardValue.PadLeft(2) + "   |";
                lines[2] += " |  " + cardSuit + "  |";
                lines[3] += " |   " + cardValue.PadRight(2) + "|";
                lines[4] += " +-----+";
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(lines[i]);
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
                if (cardValue == 1 && (points +11) <=21)
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
        public void DrawInitialCards()
        {
            Card firstCard = hand[0];
            Card secondCard = hand[1];

            string cardValue1 = firstCard.GetValue().ToString();
            char cardSuit1 = firstCard.GetSuit();

            string[] lines = new string[5];

            // Mostrar ambas cartas del crupier una al lado de la otra
            lines[0] = " +-----+ +-----+  ";
            lines[1] = " |" + cardValue1.PadLeft(2) + "   | |     |  ";
            lines[2] = " |  " + cardSuit1 + "  | |     |  ";
            lines[3] = " |   " + cardValue1.PadRight(2) + "| |     |  ";
            lines[4] = " +-----+ +-----+  ";

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }



        public void Play(Deck deck)
        {
            while (GetPlayerPoints() < 17)
            {
                Card newCard = deck.Draw();
                AddCard(newCard);
                Console.WriteLine("El crupier toma una carta: " + newCard.GetInfo());
            }
        }
    }


    public class BlackjackGame
    {
        private BlackjackPlayer player;
        private Crupier crupier;

        public BlackjackGame(BlackjackPlayer player, Crupier crupier)
        {
            this.player = player;
            this.crupier = crupier;
        }

        public void PlayGame(Deck deck)
        {
            Console.WriteLine("¡Comienza el juego de Blackjack!");

         
            deck.Shuffle();

           
            player.AddCard(deck.Draw());
            player.AddCard(deck.Draw());
            crupier.AddCard(deck.Draw());
            crupier.AddCard(deck.Draw());

            Console.WriteLine("MANO DEL CRUPIER:");
            crupier.DrawInitialCards(); 

            Console.WriteLine("TU MANO:");
            player.DrawCards();

            bool finish = false;
            int playerPoints = player.GetPlayerPoints();
            int crupierPoints = crupier.GetPlayerPoints();
            Console.WriteLine("PLAYER: " + playerPoints);
            Console.WriteLine("CRUPIER: " + crupierPoints);

            if (player.GetPlayerPoints() == 21 && crupierPoints != 21)
            {
                Console.WriteLine("HAS GANADO");
                Console.WriteLine("PLAYER: " + playerPoints);
                Console.WriteLine("CRUPIER: " + crupierPoints);
                finish = true;
            }

         

           

            while (!finish)
            {
              
                break;
                //if (points > 21)
                //{
                //    Console.WriteLine("Has perdido, con " + points + " puntos");
                //    return;
                //}
                //else
                //{
                //    Console.WriteLine("Tienes " + points + " puntos");

                //    Console.WriteLine("Selecciona\n1. Pedir carta\n2. Plantarse");
                //    string option = Console.ReadLine();

                //    if (option == "1")
                //    {
                //        Card newCard = deck.Draw();
                //        player.AddCard(newCard);
                //        player.DrawCards();
                //    }
                //    else if (option == "2")
                //    {
                //        break;
                //    }
                //}
            }

            // El crupier juega
            //crupier.Play(deck);

            //// Determinar el resultado del juego
            //DetermineWinner();
          
        }

        private void DetermineWinner()
        {
            int playerPoints = player.GetPlayerPoints();
            int crupierPoints = crupier.GetPlayerPoints();

            if (playerPoints > 21 || (crupierPoints <= 21 && crupierPoints >= playerPoints))
            {
                Console.WriteLine("¡Gana el Crupier!");
            }
            else if (crupierPoints > 21 || playerPoints > crupierPoints)
            {
                Console.WriteLine("¡Gana el Jugador!");
            }
            else
            {
                Console.WriteLine("¡Empate!");
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
