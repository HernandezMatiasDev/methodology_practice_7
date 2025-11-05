using System;

namespace methodology
{
    public class DataReaderHandler : Handler
    {
        private static DataReaderHandler? _instance;
        private DataReaderHandler(Handler? handler) : base(handler) { }
        public static DataReaderHandler GetInstance(Handler? successor)
        {
            if (_instance == null)
            {
                _instance = new DataReaderHandler(successor);
            }
            return _instance;
        }

        public override int numberByKeyboard()
        {
            int value = 0;
            bool valid = false;

            while (!valid)
            {
                Console.Write("Ingrese un numero: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out value))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Entrada invalida, por favor ingrese un numero: ");
                }
            }
            return value;
        }

        public override string stringByKeyboard()
        {
            Console.Write("Ingrese un valor: ");
            return Console.ReadLine();
        }

        public override double doubleByKeyboard()
        {
            double value = 0;
            bool valid = false;

            while (!valid)
            {
                Console.Write("Ingrese un número decimal: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida, por favor ingrese un número decimal.");
                }
            }
            return value;
        }
    }
}