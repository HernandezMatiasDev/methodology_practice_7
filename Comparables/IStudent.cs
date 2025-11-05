namespace methodology
{
    public interface IStudent :INumberComparable, IUseCompareStrategy, IObserver, IObserved, IPerson
    {

        double ExamScore { get; set; }
        public int getStudentID();
        public double getAverage();
        public double getExamScore();
        public void setStrategy(IcomparableStrategy comparableStrategy);

        public string getValue();

        public bool isEqual(IComparable c);


        public bool isSmaller(IComparable c);

        public bool isBigger(IComparable c);

        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void Call(string message);

        public void attention();
        public void distract();
        public void present();
        public void Update(string message);

        public int AnswerQuestion(int question);

        public void PrintExamScoreSetDecorator(int decorators = 0);
        public string PrintExamScore();

        // Use este metodo porque lo necesite en print_student_list de Funcions
        public string ToString();
    }
}