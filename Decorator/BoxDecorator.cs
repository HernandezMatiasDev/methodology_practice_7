using System;

namespace methodology
{
    public class BoxDecorator : StudentDecorator
    {

        public BoxDecorator(IprintQualification printQualification) : base(printQualification) { }

        public override string PrintExamScore()
        {
            string baseText = printQualification.PrintExamScore();
            string boxEdge = new string('*', baseText.Length + 6);
            string text = $"{boxEdge}\n*  {baseText}  *\n{boxEdge}";
            return text;
        }
    }
}