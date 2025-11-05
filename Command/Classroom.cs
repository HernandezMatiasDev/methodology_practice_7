using Mp = MetodologíasDeProgramaciónI;

namespace methodology
{
    public class Classroom
    {
        Mp.Teacher? teacher;

        public void Start()
        {
            Console.WriteLine("Comienza la clase");
            teacher = new Mp.Teacher();
        }

        public void NewStudent(StudentAdapter student)
        {
            if (teacher == null)
            {
                throw new InvalidOperationException("Primero necesita crear el profesor.");
            }

            teacher.goToClass(student);
        }
        
        public void ClearList()
        {
            if (teacher == null)
            {
                throw new InvalidOperationException("Primero necesita crear el profesor.");
            }

            teacher.teachingAClass();
        }
    }
}