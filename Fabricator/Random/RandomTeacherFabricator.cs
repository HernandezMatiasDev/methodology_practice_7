using System;

namespace methodology
{
    public class RandomTeacherFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {
            Handler dataProvider = HandlerFactory.GetChain();
            string name = dataProvider.RandomName();
            int dni = dataProvider.IntegerRandomNumber(50000000, 10000000); //random.Next(10000000, 50000000);
            int seniority = dataProvider.IntegerRandomNumber(20);

            return new Teacher(name, dni, seniority);
        }
    }
}