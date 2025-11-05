using System;

namespace methodology
{
    public class RandomNumFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {
            Handler dataProvider = HandlerFactory.GetChain();
            return new Number(dataProvider.IntegerRandomNumber(10000));
        }
    }
}