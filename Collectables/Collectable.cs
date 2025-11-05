using System.Collections.Generic;

namespace methodology
{
    public abstract class Collectable : ICollectable, Iterated, ISortable
    {
        protected IOrderInClassroom1? orderStart;
        protected IOrderInClassroom2? orderArrivesStudent;
        protected IOrderInClassroom1? orderClassroomFull;

        protected List<IComparable> elements = new List<IComparable>();

        // Necesite el get para la funcion print_collectable y print_student_list de Funcions.cs
        public List<IComparable> GetElements()
        {
            return elements;
        }

        public int amount() => elements.Count;
        public IComparable minimum()
        {
            if (this.amount() == 0)
            {
                throw new InvalidOperationException("La lista esta vacia");
            }
            IComparable min = elements[0];
            for (int i = 1; i < amount(); i++)
            {
                if (elements[i].isSmaller(min))
                {
                    min = elements[i];
                }
            }
            return min;
        }
        public IComparable maximum()
        {
            if (this.amount() == 0)
            {
                throw new InvalidOperationException("La lista esta vacia");
            }
            IComparable max = elements[0];
            for (int i = 1; i < amount(); i++)
            {
                if (elements[i].isBigger(max))
                {
                    max = elements[i];
                }
            }
            return max;
        }
        public virtual void add(IComparable c)
        {
            if ((this.amount() == 0) && (orderStart != null))
            {
                orderStart.Execute();
            }

            // funcion normal
            elements.Add(c);
            //

            if ((orderArrivesStudent != null) && (c is IStudent))
            {
                orderArrivesStudent.Execute(new StudentAdapter((IStudent)c));
            }
            if (this.amount() == 40 && this.orderClassroomFull != null)
            {
                this.orderClassroomFull.Execute(); 
            }
        }

        public bool contains(IComparable c)
        {
            foreach (IComparable element in elements)
            {
                if (element.isEqual(c))
                {
                    return true;
                }
            }
            return false;
        }

        // compara si lo ingresado ingresado por parametro es igual al value de algun elemento
        // esta funcion fue necesaria para poder buscar por value sin tener que crear un objeto
        /// <summary>
        /// Solo usar esta funcion si los objetos son INumberComparable
        /// </summary>
        public bool containsValue(string value)
        {
            foreach (INumberComparable element in elements)
            {
                if (element.getValue() == value)
                {
                    return true;
                }
            }
            return false;
        }

        public Iiterator createIterator()
        {
            return new ListIterator(this.elements);
        }


        public void setStartOrder(IOrderInClassroom1 order)
        {
            this.orderStart = order;
        }
        public void setStudentArrivalOrder(IOrderInClassroom2 order)
        {
            this.orderArrivesStudent = order;
        }
        public void setClassroomFullOrder(IOrderInClassroom1 order)
        {
            this.orderClassroomFull = order;
        }
    }
}