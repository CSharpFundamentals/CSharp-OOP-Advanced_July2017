namespace ListIterator
{
    using System;
    using System.Collections.Generic;

    public class ListIterator
    {
        private List<string> collection;
        private int currentIndex = 0;

        public ListIterator(List<string> collection)
        {
            this.collection = collection;
        }

        public List<string> Collection
        {
            get
            {
                return collection;
            }
        }


        public bool Move()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public bool HasNext()
        {
            if (this.currentIndex + 1 < this.collection.Count)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.collection[this.currentIndex]);
        }
    }
}
