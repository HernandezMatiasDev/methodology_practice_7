using System.Numerics;

namespace methodology
{
    public class ComposedStudent : IStudent
    {
        List<IStudent> students;
        public double ExamScore
        {
            get
            {
            if (!students.Any())
            {
                return 0; 
            }
                return students.Average(student => student.ExamScore);
            }
            set
            {
            foreach (IStudent student in students)
            {
                student.ExamScore = value;
            }
            }
        }

        public ComposedStudent()
        {
            students = new List<IStudent>();
        }

        public void add(IStudent student)
        {
            students.Add(student);
        }

        public string getName()
        {
            string names = "";
            foreach (IStudent student in students)
            {
                names += student.getName();
                names += "\n";
            }
            return names;
        }

        public int AnswerQuestion(int question)
        {
            int[] answers = new int[3];
            foreach (IStudent student in students)
            {
                answers[student.AnswerQuestion(question) -1] += 1;
            }

            int maxValue = answers.Max();
            List<int> indexsMaxValue = new List<int>();
            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i] == maxValue)
                {
                    indexsMaxValue.Add(i);
                }
            }
            Random random = new Random();

            return random.Next(indexsMaxValue.Count);
        }

        public bool isEqual(IComparable c)
        {
            foreach (IStudent student in students)
            {
                if (student.isEqual(c))
                {
                    return true;
                }
            }  
            return false;
        }


        public bool isSmaller(IComparable c)
        {
            foreach (IStudent student in students)
            {
                if (!student.isSmaller(c))
                {
                    return false;
                }
            }  
            return true;
        }

        public bool isBigger(IComparable c)
        {
            foreach (IStudent student in students)
            {
                if (!student.isBigger(c))
                {
                    return false;
                }
            }
            return true;
        }
        
        public int getStudentID(){return 03;}
        public double getAverage(){return 02;}
        public double getExamScore(){return 01;}
        public void setStrategy(IcomparableStrategy comparableStrategy){}

        public string getValue(){return ExamScore.ToString();}

        public void AddObserver(IObserver observer){}
        public void RemoveObserver(IObserver observer){}
        public void Call(string message){}

        public void attention(){}
        public void distract(){}
        public void present(){}
        public void Update(string message){}

        public void PrintExamScoreSetDecorator(int decorators = 0){}
        public string PrintExamScore()
        {
            string text = "***********ComposedStudent*************\n";
            foreach (IStudent student in students)
            {
                text += student.PrintExamScore();
                text += "\n";
                text += "\n";
            }
            text += "****************************************";
            return text;
        }
        
        public int getDni(){return 05;}
        public string ToString(){return "123";}
    }
}
