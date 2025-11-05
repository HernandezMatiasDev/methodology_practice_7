using System;

namespace methodology
{
    public class KeyboaStudentIntelligentFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {
            Handler dataProvider = HandlerFactory.GetChain();
            Console.WriteLine("    Creacion de Estudiante");

            Console.WriteLine("Ingrese el nombre completo del estudiante");
            string name = dataProvider.stringByKeyboard();

            Console.WriteLine("Ingrese el DNI");
            int dni = dataProvider.numberByKeyboard();

            Console.WriteLine("Ingrese el legajo");
            int id = dataProvider.numberByKeyboard();

            Console.WriteLine("Ingrese el promedio");
            double average = dataProvider.doubleByKeyboard();

            Console.WriteLine("Ingrese la ultima nota");
            double examScore = dataProvider.doubleByKeyboard();

            return new StudentIntelligent(name, dni, id, average, examScore);
        }
    }
}