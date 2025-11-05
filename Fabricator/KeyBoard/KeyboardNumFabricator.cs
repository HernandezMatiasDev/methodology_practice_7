using System;

namespace methodology
{
    public class KeyboardNumFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {
            Handler dataProvider = HandlerFactory.GetChain();
            return new Number(dataProvider.numberByKeyboard());
        }
    }
}