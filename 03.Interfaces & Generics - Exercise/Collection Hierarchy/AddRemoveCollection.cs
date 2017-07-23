namespace Collection_Hierarchy
{
    using Interfaces;

    public class AddRemoveCollection<T> : Collection<T>, IAddRemoveCollection<T>
    {
        public int Add(T element)
        {
            this.List.Insert(0, element);
            return 0;
        }

        public T Remove()
        {
            T temp = this.List[this.List.Count - 1];
            this.List.RemoveAt(this.List.Count - 1);
            return temp;
        }
    }
}
