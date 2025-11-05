using System;

namespace methodology
{
    public class RandomProxyStudentFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {
            Handler dataProvider = HandlerFactory.GetChain();
            string name = dataProvider.RandomName();
            int dni = dataProvider.IntegerRandomNumber(50000000, 10000000); //random.Next(10000000, 50000000);
            int studentID = dataProvider.IntegerRandomNumber(9999, 1000); //random.Next(1000, 9999);
            double average = dataProvider.DecimalRandomNumber(10); //Math.Round(random.NextDouble() * 10, 2);
            double examScore = dataProvider.DecimalRandomNumber(10); //Math.Round(random.NextDouble() * 10, 2);

            return new ProxyStudent(name, dni, studentID, average, examScore);
        }
    }
}