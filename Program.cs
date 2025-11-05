using System;
using mp = MetodologíasDeProgramaciónI;

namespace methodology
{
    class Program
    {
        //constantes para el StudentDecorator
        private const int decoratorBox = 1;
        private const int decoratorStatusNote = 2;
        private const int decoratorId = 4;
        private const int decoratorWrittenNote = 8;

        //constantes para el fabricator
        private const int number = 1;
        private const int student = 2;
        private const int name = 3;
        private const int teacher = 4;
        private const int StudentIntelligentType = 5;
        private const int Proxystudent = 6;
        private const int ProxyStudentIntelligentType = 7;
        private const int ComposedStudentType = 8;
        static void Main(string[] args)
        {

            Collectable stack = new Stack();
            Classroom classroom = new Classroom();
            stack.setStartOrder(new OrderStart(classroom));
            stack.setStudentArrivalOrder(new OrderArrivesStudent(classroom));
            stack.setClassroomFullOrder(new OrderClassroomFull(classroom));

            for (int i = 0; i < 2; i++)
            {
                IComparable student = ComparableFactory.createByKeyboard(StudentIntelligentType);
                stack.add(student);
            }
            for (int i = 0; i < 5; i++)
            {
                IComparable student = ComparableFactory.createByArchive(ComposedStudentType);
                stack.add(student);
            }
            Funcions.RandomLoadComparable(stack, student, 13);
            Funcions.RandomLoadComparable(stack, StudentIntelligentType, 19);
            stack.add(ComparableFactory.createRandom(ComposedStudentType)); //necesariamente hay que añadirlo ultimo
            // la logica que se pide para "sosMayor, sosMenor,sosIgual" no es muy practica
            // seria mejor si en vez de tenre que ser mayor o menor que todos se usase el promedio


            Funcions.PlayChampionship((Person)ComparableFactory.createRandom(student), (Person)ComparableFactory.createRandom(student), 2);
        }
    }
}
