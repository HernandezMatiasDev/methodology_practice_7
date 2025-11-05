using System;

namespace methodology
{
    public class PrintQualification : IprintQualification
    {
        IStudent student;

        public PrintQualification(IStudent student)
        {
            this.student = student;
        }

        public string PrintExamScore() => $"{student.getName()}  {student.getExamScore().ToString("F2")}";  

        public IStudent GetStudent() => student;
    }
}