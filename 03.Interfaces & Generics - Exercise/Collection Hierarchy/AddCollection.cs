namespace Collection_Hierarchy
{
    using Interfaces;

    public class AddCollection<T> : Collection<T>, IAddCollection<T>
    {
        public int Add(T element)
        {
            this.List.Add(element);
            return this.List.Count - 1;
        }
    }
}
