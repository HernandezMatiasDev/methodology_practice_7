namespace methodology
{
    public class OrderArrivesStudent : IOrderInClassroom2
    {
        private Classroom classroom;

        public OrderArrivesStudent(Classroom classroom)
        {
            this.classroom = classroom;
        }

        public void Execute(StudentAdapter student)
        {
            classroom.NewStudent(student);
        }
    }
}