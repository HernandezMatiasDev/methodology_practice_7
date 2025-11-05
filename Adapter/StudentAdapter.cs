using MetodologíasDeProgramaciónI;
namespace methodology
{
    public class StudentAdapter : MetodologíasDeProgramaciónI.Student
    {
        private IStudent student;

        public StudentAdapter(IStudent student)
        {
            this.student = student;
        }

        public string getName()
        {
            return student.getName();
        }

        public int yourAnswerIs(int question)
        {
            return student.AnswerQuestion(question);
        }

        public void setScore(int score)
        {
            student.ExamScore = score;
        }

        public string showResult()
        {
            return student.PrintExamScore();
        }

        // estos funcionan con todos los strategy ya creados
        public bool equals(MetodologíasDeProgramaciónI.Student s)
        {
            return student.isEqual(((StudentAdapter)s).student);
        }

        public bool lessThan(MetodologíasDeProgramaciónI.Student s)
        {
            return student.isSmaller(((StudentAdapter)s).student);
        }

        public bool greaterThan(MetodologíasDeProgramaciónI.Student s)
        {
            return student.isBigger(((StudentAdapter)s).student);
        }
    }
}

