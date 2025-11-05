using System;

namespace methodology
{
    public abstract class DecoratorFactory
    {
        private const int decoratorBox = 1;
        private const int decoratorStatusNote = 2;
        private const int decoratorId = 4;
        private const int decoratorWrittenNote = 8;

        public static IprintQualification CreatePrintQualification(IStudent student, int flag = 0)
        {
            IprintQualification decorator = new PrintQualification(student);

            if ((flag & decoratorStatusNote) != 0)
            {
                decorator = new StudentStatusNoteDecorator(decorator);
            }
            if ((flag & decoratorId) != 0)
            {
                decorator = new StudentIdDecorator(decorator);
            }
            if ((flag & decoratorWrittenNote) != 0)
            {
                decorator = new StudentWrittenNoteDecorator(decorator);
            }
            if ((flag & decoratorBox) != 0)
            {
                decorator = new BoxDecorator(decorator);
            }
            return decorator;
        }

    }
}