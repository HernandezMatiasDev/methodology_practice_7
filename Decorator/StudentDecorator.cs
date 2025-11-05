using System;

namespace methodology
{
    public abstract class StudentDecorator : IprintQualification
    {
        protected IprintQualification printQualification;

        public StudentDecorator(IprintQualification printQualification)
        {
            this.printQualification = printQualification;
        }

        public abstract string PrintExamScore();

        public IStudent GetStudent() => printQualification.GetStudent();
    }
}