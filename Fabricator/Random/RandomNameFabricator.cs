using System;

namespace methodology
{
    public class RandomNameFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {   
            Handler dataProvider = HandlerFactory.GetChain();
            string name = dataProvider.RandomName();
            return new Name(name);
        }
    }
}