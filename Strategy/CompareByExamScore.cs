namespace methodology
{
    public class CompareByExamScore: IcomparableStrategy
    {
        //sosIgual
        public bool isEqual(IComparable a, IComparable b) => ((IStudent)a).getExamScore() == ((IStudent)b).getExamScore();

        //sosMenor
        public bool isSmaller(IComparable a, IComparable b) => ((IStudent)a).getExamScore() < ((IStudent)b).getExamScore();

        //sosMayor
        public bool isBigger(IComparable a, IComparable b) => ((IStudent)a).getExamScore() > ((IStudent)b).getExamScore();

        public string getValue(IComparable a) => ((IStudent)a).getExamScore().ToString();
    }
}