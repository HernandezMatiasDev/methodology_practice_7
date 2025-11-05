namespace methodology
{
public class Bigger : CardGame
    {
        private List<int> deck;
        private int player1_score;
        private int player2_score;
        private Random rng;

        public Bigger(Person player_1, Person player_2) :base (player_1, player_2)
        {
            // Crear el mazo de 20 cartas
            deck = new List<int>();
            for (int i = 1; i <= 20; i++)
            {
                deck.Add(i);
            }
            
            player1_score = 0;
            player2_score = 0;
            rng = new Random();
        }

        public override void mixDeck()
        {
            Console.WriteLine("Mezclando el mazo de 20 cartas...");
            // Algoritmo simple de mezclado (Fisher-Yates)
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
            // En este juego no hay "cartas iniciales",
            // se saca una por ronda.
            Console.WriteLine("Preparando la partida...");
        }

        public override void play()
        {
            Console.WriteLine("¡Comienza el juego 'Bigger'!");
            int round = 1;

            // Jugar mientras queden cartas en el mazo
            // (Se necesitan 2 cartas por ronda)
            while (deck.Count >= 2)
            {
                Console.WriteLine($"\n--- Ronda {round} ---");

                // Sacar una carta para cada jugador
                int card1 = deck[0];
                deck.RemoveAt(0);
                int card2 = deck[0];
                deck.RemoveAt(0);

                Console.WriteLine($"{this.player_1.getName()} saca un {card1}");
                Console.WriteLine($"{this.player_2.getName()} saca un {card2}");

                // Comparar y asignar puntos
                if (card1 > card2)
                {
                    Console.WriteLine($"{this.player_1.getName()} gana la ronda.");
                    player1_score++;
                }
                else if (card2 > card1)
                {
                    Console.WriteLine($"{this.player_2.getName()} gana la ronda.");
                    player2_score++;
                }
                else
                {
                    Console.WriteLine("¡Empate en esta ronda! No hay puntos.");
                }

                Console.WriteLine($"Marcador: {this.player_1.getName()}: {player1_score} - {this.player_2.getName()}: {player2_score}");
                round++;
            }

            Console.WriteLine("\n¡Se acabaron las cartas del mazo!");
        }

        public override void isWin()
        {
            Console.WriteLine("Calculando al ganador de la partida...");
            // El que ganó más rondas, gana la partida
            if (player1_score > player2_score)
            {
                this.winner = this.player_1;
            }
            else if (player2_score > player1_score)
            {
                this.winner = this.player_2;
            }
            else
            {
                this.winner = null; // Empate
            }
        }

        public override Person winer()
        {
            if (this.winner != null)
            {
                Console.WriteLine($"\n¡El ganador de la partida es {this.winner.getName()}!");
            }
            else
            {
                Console.WriteLine("\n¡La partida ha terminado en empate!");
            }
            return this.winner;
        }
    }
}
