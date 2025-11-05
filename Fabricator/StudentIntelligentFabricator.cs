using System;

namespace methodology
{
    public class StudentIntelligentFabricator : StudentFactory
    {
        public override Student CreateComparable(string name, int dni, int id, double average, double examScore)
        {           
            
            return new StudentIntelligent(name, dni, id, average, examScore);
        }
    }
}