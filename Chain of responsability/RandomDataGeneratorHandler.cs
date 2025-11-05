using System;
using System.IO;
using System.Collections.Generic;

namespace methodology
{
    public class RandomDataGeneratorHandler : Handler
    {
        private static RandomDataGeneratorHandler? _instance;
        private RandomDataGeneratorHandler(Handler? handler) : base(handler)
        {
            // Moví 'loadNames' aquí para que se ejecute UNA SOLA VEZ
            // cuando se crea la única instancia.
            if (File.Exists(filepath))
            {
                studentsNames = new List<string>(File.ReadAllLines(filepath));
            }
            else
            {
                // Es mejor manejar esto, pero no lanzar una excepción en el constructor
                Console.WriteLine($"Error: No se encontro el archivo de nombres: {filepath}");
                studentsNames = new List<string>(); // Dejar la lista vacía
            }
        }
        public static RandomDataGeneratorHandler GetInstance(Handler? successor)    
        {
            if (_instance == null)
            {
                _instance = new RandomDataGeneratorHandler(successor);
            }
            return _instance;
        }
        private  Random random = new Random();

        // Lista con los nombres de los estudiantes
        private  List<string> studentsNames;

        // Ruta del archivo con los nombres
        private  string filepath = "./names.txt";

        public override int IntegerRandomNumber(int max, int min = 0)
        {
            return random.Next(min, max);
        }

        public override double DecimalRandomNumber(int max, int Decimals = 2)
        {
            return Math.Round(random.NextDouble() * max, Decimals);
        }


        public override string stringRandom(int amountChar)
        {
            string Characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string randomString = "";
            for (int i = 0; i < amountChar; i++)
            {
                randomString = randomString + Characters[IntegerRandomNumber(Characters.Length)];
            }
            return randomString;
        }

        public override string RandomName()
        {
            if (studentsNames == null || studentsNames.Count == 0)
                loadNames();

            return studentsNames[IntegerRandomNumber(studentsNames.Count)];
        }

        public override void loadNames()
        {
            if (File.Exists(filepath))
            {
                studentsNames = new List<string>(File.ReadAllLines(filepath));
            }
            else
            {
                throw new FileNotFoundException("No se encontro el archivo de nombres: " + filepath);
            }
        }

    }
}