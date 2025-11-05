using System;

namespace methodology
{
    public class KeyboardNameFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {
            Handler dataProvider = HandlerFactory.GetChain();

            Console.WriteLine("Ingrese el nombre: ");
            string name = dataProvider.stringByKeyboard();

            return new Name(name);
        }
    }
}