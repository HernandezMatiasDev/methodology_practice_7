namespace methodology
{
    public class OrderClassroomFull : IOrderInClassroom1
    {
        private Classroom classroom;
        public OrderClassroomFull(Classroom classroom)
        {
            this.classroom = classroom;
        }
        public void Execute()
        {
            classroom.ClearList();
        }
    }
}