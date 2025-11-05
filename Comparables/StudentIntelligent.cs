namespace methodology
{
    public class StudentIntelligent : Student
    {
        public StudentIntelligent(string name, int dni, int id, double average,double examScore) : base(name, dni, id, average, examScore){}
        public override int AnswerQuestion(int question) => question % 3;
    }
}