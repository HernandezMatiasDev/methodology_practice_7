using System;

namespace methodology
{
    public class BaseStudentFabricator : StudentFactory
    {
        public override Student CreateComparable(string name, int dni, int id, double average, double examScore)
        {

            return new Student(name, dni, id, average, examScore);
        }
    }
}