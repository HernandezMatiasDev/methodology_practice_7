// --- Archivo: ArchiveComposedStudentFabricator.cs (NUEVO) ---
using System;

namespace methodology
{
    public class ArchiveComposedStudentFabricator : ComparableFactory
    {
        private const int AMOUNT_OF_STUDENTS = 5;

        public override IComparable CreateComparable()
        {

            ComposedStudent composedStudent = new ComposedStudent();
            
            for(int i = 0; i < AMOUNT_OF_STUDENTS; i++)
            {
                composedStudent.add((IStudent)ComparableFactory.createByArchive(6));
            }

            return composedStudent;
        }
    }
}