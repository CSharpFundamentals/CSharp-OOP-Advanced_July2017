namespace Collection_Hierarchy
{
    using System.Collections.Generic;

    public abstract class Collection<T>
    {
        private readonly IList<T> list;

        public Collection()
        {
            this.list = new List<T>();
        }

        public IList<T> List
        {
            get => this.list;
        }
    }
}
