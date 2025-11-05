namespace methodology
{
    public class Student : Person, IUseCompareStrategy, IObserver, IObserved, IStudent
    {

        protected IprintQualification pe;
        protected List<IObserver> observers = new List<IObserver>();
        protected string[] distractTexts =
        {
            "Mirando el celular",
            "Dibujando en el margen de la carpeta",
            "Tirando aviones de papel"
        };

        protected double examScore;

        //legajo
        protected int studentID;

        //promedio
        protected double average;

        protected IcomparableStrategy comparableStrategy;

        public Student(string name, int dni, int id, double average, double examScore) : base(name, dni)
        {
            this.studentID = id;
            this.average = average;
            this.examScore = examScore;
            comparableStrategy = new CompareByStudentId();
            pe = DecoratorFactory.CreatePrintQualification(this);
        }
        public double ExamScore
        {
            get { return examScore; }
            set { examScore = value; }
        }

        public int getStudentID() => studentID;
        public double getAverage() => average;
        public double getExamScore() => examScore;
        public void setStrategy(IcomparableStrategy comparableStrategy)
        {
            this.comparableStrategy = comparableStrategy;
        }
        public override string getValue()
        {
            return comparableStrategy.getValue(this);
        }

        public override bool isEqual(IComparable c)
        {
            return comparableStrategy.isEqual(this, (IStudent)c);
        }

        public override bool isSmaller(IComparable c)
        {
            return comparableStrategy.isSmaller(this, (IStudent)c);
        }
        public override bool isBigger(IComparable c)
        {
            return comparableStrategy.isBigger(this, (IStudent)c);
        }

        public void AddObserver(IObserver observer) => observers.Add(observer);
        public void RemoveObserver(IObserver observer) => observers.Remove(observer);
        public void Call(string message)
        {
            foreach (IObserver obs in observers)
                obs.Update(message);
        }

        public void attention() => Console.WriteLine("Prestando atención");

        public void distract() => Console.WriteLine(distractTexts[RandomDataGenerator.IntegerRandomNumber(distractTexts.Count())]);
        public void present() => Console.WriteLine($"Alumno {getName()}: Presente");
        public void Update(string message)
        {
            if (message == "talk")
            {
                attention();
            }
            else if (message == "write")
            {
                distract();
            }
            else if (message == this.getName())
            {
                present();
                Call("present");
            }
        }

        public virtual int AnswerQuestion(int question) => RandomDataGenerator.IntegerRandomNumber(4, 1);

        //se le tiene que pasar todos los decorators que se quieran a la vez
        public void PrintExamScoreSetDecorator(int decorators = 0)
        {
            pe = DecoratorFactory.CreatePrintQualification(this, decorators);
        }
        public string PrintExamScore() => pe.PrintExamScore();

        // Use este metodo porque lo necesite en print_student_list de Funcions
        public override string ToString()
        {
            return $"Nombre: {name}, DNI: {dni}, Legajo: {studentID}, Promedio: {average}";
        }
    }
}