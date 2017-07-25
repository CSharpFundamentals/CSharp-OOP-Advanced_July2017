using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    private readonly SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> books;
        private int currentIndex;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.Reset();
            this.books = new List<Book>(books);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }

        public Book Current
        {
            get => this.books[currentIndex];
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }
    }
}