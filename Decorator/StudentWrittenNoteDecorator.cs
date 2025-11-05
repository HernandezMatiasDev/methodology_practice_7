using System;

namespace methodology
{
    public class StudentWrittenNoteDecorator : StudentDecorator
    {

        public StudentWrittenNoteDecorator(IprintQualification printQualification) : base(printQualification) { }

        public override string PrintExamScore()
        {
            string baseText = printQualification.PrintExamScore();
            IStudent student = printQualification.GetStudent();
            int index = baseText.IndexOf(student.getExamScore().ToString("F2"));
            string number = $" ({Funcions.numberTotext((int)student.getExamScore())})";
            string text = baseText.Insert(index + student.getExamScore().ToString("F2").Length, number);
            return text;
        }
    }
}