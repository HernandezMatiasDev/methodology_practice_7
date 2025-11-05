namespace methodology
{
    public class OrderStart : IOrderInClassroom1
    {
        private Classroom classroom;

        public OrderStart(Classroom classroom)
        {
            this.classroom = classroom;
        }

        public void Execute()
        {
            classroom.Start();
        }
    }
}