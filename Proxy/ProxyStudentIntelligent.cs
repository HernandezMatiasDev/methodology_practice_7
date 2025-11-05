namespace methodology
{
    public class ProxyStudentIntelligent : ProxyStudent
    {
        public ProxyStudentIntelligent(string name, int dni, int id, double average,double examScore) : base(name, dni, id, average, examScore){}
        public override int AnswerQuestion(int question)
        {
            if (student == null)
            {
                student = StudentFactory.StudentFabricator(StudentIntelligentType, name, dni, studentID, average, examScore);
            }
            Console.WriteLine($"Creando alumno desde proxy inteligente");
            return student.AnswerQuestion(question);
        }
    }
}