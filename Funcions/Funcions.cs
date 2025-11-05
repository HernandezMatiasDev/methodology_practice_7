using System;
using System.IO;
using System.Collections.Generic;
using mp = MetodologíasDeProgramaciónI;

namespace methodology
{
    public static class Funcions
    {

        // Lista con los nombres de los numeros del 1 al 1000
        private static List<string> NumbersNames;

        // Ruta del archivo con los nombres de los numeros del 1 al 1000
        private static string filepath = "./numbers.txt";


        //llenar(Coleccionable)
        public static void RandomLoadComparable(ICollectable collectable, int typeComparable, int load = 20)
        {
            for (int i = 0; i < load; i++)
            {
                IComparable comparable = ComparableFactory.createRandom(typeComparable);
                collectable.add(comparable);
            }
        }

        public static void KeyboardLoadComparable(ICollectable collectable, int typeComparable, int load = 3)
        {
            for (int i = 0; i < load; i++)
            {
                IComparable comparable = ComparableFactory.createByKeyboard(typeComparable);
                collectable.add(comparable);
            }
        }

        //informar(Coleccionable)
        // Esta funcion acutalmente compara por un valor y no tiene la necesidad de crear instancias.
        public static void inform(ICollectable collectable)
        {
            Console.WriteLine($"Información de {collectable.GetType().Name}:");
            Console.WriteLine($"La {collectable.GetType().Name} tiene {collectable.amount()} elementos");
            Console.WriteLine($"El valor minimo de la {collectable.GetType().Name} es {((INumberComparable)collectable.minimum()).getValue()}");
            Console.WriteLine($"El valor maximo de la {collectable.GetType().Name} es {((INumberComparable)collectable.maximum()).getValue()}");

            if (collectable.containsValue(DataReader.stringByKeyboard()))
            {
                Console.WriteLine("El valor introducido esta en la coleccion");
            }
            else
            {
                Console.WriteLine("El valor introducido no se encuentra en la coleccion");
            }


        }


        public static void changeStrategy(Collectable collectable, IcomparableStrategy comparableStrategy)
        {
            Iiterator iterator = collectable.createIterator();
            while (!iterator.End())
            {
                ((IUseCompareStrategy)iterator.Current()).setStrategy(comparableStrategy);
                iterator.Next();
            }
        }
        public static void printCollectable(Collectable collectable)
        {
            Iiterator iterator = collectable.createIterator();
            while (!iterator.End())
            {
                Console.WriteLine(iterator.Current().ToString());
                iterator.Next();
            }

        }

        public static void dictationClasses(Teacher teacher, int timeClass = 5)
        {
            for (int i = 0; i < timeClass; i++)
            {
                teacher.speakClass();
                teacher.writeBlackboard();
            }
        }

        public static void conectToObserved(IObserved observed, IObserver Observer)
        {
            observed.AddObserver(Observer);
        }

        // una lista de observadores se conectan con un observado
        public static void AttachObservers(IObserved observed, Collectable collectable)
        {
            Iiterator iterator = collectable.createIterator();
            for (iterator.First(); !iterator.End(); iterator.Next())
            {
                conectToObserved(observed, (IObserver)iterator.Current());
            }
        }

        // un observador se conecta a una lista de observados 
        public static void SubscribeToSubjects(IObserver observer, Collectable collectable)
        {
            Iiterator iterator = collectable.createIterator();
            for (iterator.First(); !iterator.End(); iterator.Next())
            {
                conectToObserved((IObserved)iterator.Current(), observer);
            }
        }
        public static Queue studentList(Collectable collectable)
        {
            Queue queue = new Queue();
            Iiterator iterator = collectable.createIterator();
            for (iterator.First(); !iterator.End(); iterator.Next())
            {
                queue.add(new Name(((Person)iterator.Current()).getName()));
            }
            return queue;
        }


        // esta funcion recive un collectable de student y devuelve una lista de StudentAdapter
        public static mp.Collection combertToStudentAdapter(Collectable students)
        {
            mp.Collection collection = new mp.ListOfStudent();

            Iiterator it = students.createIterator();
            for (it.First(); !it.End(); it.Next())
            {
                IStudent student = (IStudent)it.Current();
                StudentAdapter adapter = new StudentAdapter(student);
                collection.addStudent(adapter);
            }
            return collection;
        }

        // como la lista es un objeto, podemos modificarla directamente sin necesidad de devolverla 
        public static void shortCollectable(Collectable collectable)
        {
            ListIterator it = (ListIterator)collectable.createIterator();
            IComparable auxilarComparable = (IComparable)it.Current();

            for (it.First(); !it.End(); it.Next())
            {
                if (((IComparable)it.Current()).isBigger((IComparable)it.NextItem()))
                {
                    it.change(it.index(), it.index() + 1);
                }
            }

        }

        public static void loadNumbersNames()
        {
            if (File.Exists(filepath))
            {
                NumbersNames = new List<string>(File.ReadAllLines(filepath));
            }
            else
            {
                throw new FileNotFoundException("No se encontro el archivo de nombres: " + filepath);
            }
        }

        public static string numberTotext(int num)
        {
            if (NumbersNames == null || NumbersNames.Count == 0)
                loadNumbersNames();

            return NumbersNames[num];
        }

        public static void setStudentDecorator(Collectable collectable, int decorators)
        {
            Iiterator iterator = collectable.createIterator();
            while (!iterator.End())
            {
                ((IStudent)iterator.Current()).PrintExamScoreSetDecorator(decorators);
                iterator.Next();
            }
        }
    public static void PlayChampionship(Person playerA, Person playerB, int pointsToWin)
        {
            Console.WriteLine("================================================");
            Console.WriteLine($"Empieza EL Torneo");
            Console.WriteLine($"El primero en ganar {pointsToWin} partidas gana.");
            Console.WriteLine("================================================");

            int scorePlayerA = 0;
            int scorePlayerB = 0;
            int gameNumber = 1;

            while (scorePlayerA < pointsToWin && scorePlayerB < pointsToWin)
            {
                Console.WriteLine($"\n----------[ Inicia Partida {gameNumber} ]----------");

                CardGame currentGame = new Bigger(playerA, playerB); 

                Person? gameWinner = currentGame.Game();

                if (gameWinner != null)
                {
                    if (gameWinner.isEqual(playerA))
                    {
                        scorePlayerA++;
                        Console.WriteLine($"\n*** {playerA.getName()} gano la partida {gameNumber}. ***");
                    }
                    else
                    {
                        scorePlayerB++;
                        Console.WriteLine($"\n*** {playerB.getName()} gano la partida {gameNumber}. ***");
                    }
                }
                else
                {
                    Console.WriteLine($"\n*** La partida {gameNumber} fue un empate. No hay puntos. ***");
                }

                Console.WriteLine($"MARCADOR GENERAL: {playerA.getName()}: {scorePlayerA} - {playerB.getName()}: {scorePlayerB}");
                gameNumber++;
            }

            // Declarar al ganador
            Console.WriteLine("\n========================================");
            Console.WriteLine("Fin del Campeonato");

            if (scorePlayerA > scorePlayerB)
            {
                Console.WriteLine($"El ganador es: {playerA.getName()}!");
            }
            else
            {
                Console.WriteLine($"El ganador es: {playerB.getName()}!");
            }
            Console.WriteLine("========================================");
        }

    }
}
