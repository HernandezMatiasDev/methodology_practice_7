namespace methodology
{
    public class CompareByAverage : IcomparableStrategy
    {
        //sosIgual
        public bool isEqual(IComparable a, IComparable b) => ((IStudent)a).getAverage() == ((IStudent)b).getAverage();

        //sosMenor
        public bool isSmaller(IComparable a, IComparable b) => ((IStudent)a).getAverage() < ((IStudent)b).getAverage();

        //sosMayor
        public bool isBigger(IComparable a, IComparable b) => ((IStudent)a).getAverage() > ((IStudent)b).getAverage();

        public string getValue(IComparable a) => ((IStudent)a).getAverage().ToString();
    }
}