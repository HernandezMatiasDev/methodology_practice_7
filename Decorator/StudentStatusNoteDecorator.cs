using System;

namespace methodology
{
    public class StudentStatusNoteDecorator : StudentDecorator
    {

        public StudentStatusNoteDecorator(IprintQualification printQualification) : base(printQualification) { }

        public override string PrintExamScore()
        {
            string baseText = printQualification.PrintExamScore();
            IStudent student = printQualification.GetStudent();
            int note = (int)student.getExamScore();
            string state = note >= 7 ? " (PROMOCIÓN)" : note >= 4 ? " (APROBADO)" : " (DESAPROBADO)"; 

            
            int index = baseText.IndexOf(student.getExamScore().ToString("F2"));
            string text = baseText.Insert(index + student.getExamScore().ToString("F2").Length, state);
            return text;
        }
    }
}