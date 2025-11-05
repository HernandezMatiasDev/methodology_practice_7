using System;

namespace methodology
{
    public class StudentIdDecorator : StudentDecorator
    {

        public StudentIdDecorator(IprintQualification printQualification) : base(printQualification) { }

        public override string PrintExamScore()
        {
            string baseText = printQualification.PrintExamScore();
            IStudent student = printQualification.GetStudent();
            int index = baseText.IndexOf(student.getName());
            string id = $" ({student.getStudentID().ToString()})";
            string text = baseText.Insert(index + student.getName().Length, id);
            return text;
        }
    }
}