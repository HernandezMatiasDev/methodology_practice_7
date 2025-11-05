namespace methodology
{
    public class ListIterator : Iiterator
    {
        int CurrentPosition;
        List<IComparable> iterableList;
        public ListIterator(List<IComparable> iterableList)
        {
            this.iterableList = iterableList;
            this.First();
        }
        // primero
        public void First() => CurrentPosition = 0;

        // siguiente 
        public void Next() => CurrentPosition++;

        // fin     
        public bool End() => CurrentPosition >= iterableList.Count;

        // actual
        public IComparable Current() => iterableList[CurrentPosition];

        public void change(int a, int b)
        {
            IComparable auxilar = iterableList[a];
            iterableList[a] = iterableList[b];
            iterableList[b] = auxilar;
        }
        public IComparable NextItem() => iterableList[CurrentPosition + 1];

        public IComparable reviousItem() => iterableList[CurrentPosition - 1];

        public int index() => CurrentPosition;
    }
}