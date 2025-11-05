using System;

namespace methodology
{
    public class KeyboardTeacherFabricator : ComparableFactory
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
            int seniority = dataProvider.numberByKeyboard();

            return new Teacher(name, dni, seniority);
        }
    }
}