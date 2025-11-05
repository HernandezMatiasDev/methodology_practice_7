namespace methodology
{
    public class One : CardGame
    {
        private List<int> deck;
        private Random rng;

        public One(Person player_1, Person player_2) :base (player_1, player_2)
        {
            deck = new List<int>();
            for (int i = 1; i <= 30; i++)
            {
                deck.Add(i);
            }
            rng = new Random();
        }

        public override void mixDeck()
        {
            Console.WriteLine("Mezclando el mazo de 30 cartas");

            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public override void distributecards()
        {
            Console.WriteLine("Preparando la partida");
        }

        public override void play()
        {
            Console.WriteLine("Comienza el juego.\n El primero en sacar el '1' gana.");
            int round = 1;

            while (deck.Count > 0 && this.winner == null)
            {
                Console.WriteLine($"\n--- Ronda {round} ---");

                if (deck.Count > 0)
                {
                    int card1 = deck[0];
                    deck.RemoveAt(0);

                    Console.WriteLine($"{this.player_1.getName()} saco un {card1}");

                    if (card1 == 1)
                    {
                        Console.WriteLine($"{this.player_1.getName()} encontro el 1");
                        this.winner = this.player_1; 
                        return; 
                    }
                }

                if (deck.Count > 0)
                {
                    int card2 = deck[0];
                    deck.RemoveAt(0);
                    Console.WriteLine($"{this.player_2.getName()} saco un {card2}");

                    if (card2 == 1)
                    {
                        Console.WriteLine($"{this.player_2.getName()} encontro el 1!");
                        this.winner = this.player_2; 
                        return; 
                    }
                }
                
                round++;
            }
        }

        public override void isWin(){}

        public override Person? winer()
        {
            if (this.winner != null)
            {
                Console.WriteLine($"\n¡El ganador de la partida es {this.winner.getName()}!");
            }
            else
            {
                //igualmente esto no tendria que ser posible
                Console.WriteLine("\nNadie encontro el 1");
            }
            return this.winner;
        }
    }
}