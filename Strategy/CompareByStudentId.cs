namespace methodology
{
    public class CompareByStudentId: IcomparableStrategy
    {
        //sosIgual
        public bool isEqual(IComparable a, IComparable b) => ((IStudent)a).getStudentID() == ((IStudent)b).getStudentID();

        //sosMenor
        public bool isSmaller(IComparable a, IComparable b) => ((IStudent)a).getStudentID() < ((IStudent)b).getStudentID();

        //sosMayor
        public bool isBigger(IComparable a, IComparable b) => ((IStudent)a).getStudentID() > ((IStudent)b).getStudentID();

        public string getValue(IComparable a) => ((IStudent)a).getStudentID().ToString();
    }
}