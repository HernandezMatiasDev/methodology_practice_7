using System;

namespace methodology
{
    public abstract class StudentFactory
    {
        private const int studentType = 1;
        private const int StudentIntelligentType = 2;


        public static Student StudentFabricator(int type, string name, int dni, int id, double average, double examScore)
        {
            StudentFactory factory;
            switch (type)
            {
                case studentType:
                    factory = new BaseStudentFabricator();
                    break;
                case StudentIntelligentType:
                    factory = new StudentIntelligentFabricator();
                    break;
                default:
                    throw new ArgumentException("El valor introducido no es valido");
                    break;
            }
            return factory.CreateComparable(name, dni, id, average, examScore);
        }
        public abstract Student CreateComparable(string name, int dni, int id, double average, double examScore);
    }
}