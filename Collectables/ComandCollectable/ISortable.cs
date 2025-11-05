namespace methodology
{
    public interface ISortable
    {
        public void setStartOrder(IOrderInClassroom1 order);
        public void setStudentArrivalOrder(IOrderInClassroom2 order);
        public void setClassroomFullOrder(IOrderInClassroom1 order);
    }
}