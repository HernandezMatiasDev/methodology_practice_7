// --- Archivo: FileProxyStudentFabricator.cs (NUEVO) ---
using System;

namespace methodology
{
    public class FileProxyStudentFabricator : ComparableFactory
    {
        public override IComparable CreateComparable()
        {
            Handler dataProvider = HandlerFactory.GetChain();


            string name = dataProvider.stringDesdeArchivo(20); 
            double baseNum = dataProvider.numeroDesdeArchivo(1); 

            int dni = (int)(baseNum * 50000000) + 10000000;
            int studentID = dataProvider.IntegerRandomNumber(9999, 1000);
            double average = dataProvider.DecimalRandomNumber(10);
            double examScore = dataProvider.DecimalRandomNumber(10);

            return new ProxyStudent(name, dni, studentID, average, examScore);
        }
    }
}