using System;
using System.Collections.Generic;
using System.Linq;

namespace DB
{
    public class Database
    {
        private const int DefaultCapacity = 16;
        private int[] elements;
        private int currentIndex;

        //Tested
        public Database(IEnumerable<int> elements)
        {
            this.Elements = elements.ToArray();
        }

        public int[] Elements
        {
            get
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < this.currentIndex; i++)
                {
                    numbers.Add(elements[i]);
                }

                return numbers.ToArray();
            }
            private set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.elements = new int[DefaultCapacity];
                int bufferIndex = 0;

                foreach (int element in value)
                {
                    this.elements[bufferIndex++] = element;
                }

                this.currentIndex = value.Length;
            }
        }

        public int Capacity
        {
            get { return DefaultCapacity; }
        }

        public int Count
        {
            get { return this.currentIndex; }
        }

        public void Add(int element)
        {
            if (this.currentIndex == DefaultCapacity)
            {
                throw new InvalidOperationException("Cannot add more elements in the collection");
            }
            this.elements[currentIndex] = element;
            currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty database!");
            }

            this.elements[currentIndex] = default(int);
            currentIndex--;
        }
    }
}

