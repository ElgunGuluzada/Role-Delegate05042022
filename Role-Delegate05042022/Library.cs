using System;
using System.Collections.Generic;
using Utils.Exceptions;

namespace Role_Delegate05042022
{
    public class Library : IEntity
    {
        public int Id { get; set; }
        public int BookLimit { get; set; }

        private List<Book> _books;
        public List<Book> Books
        {
            get
            {
                return _books;
            }
            set
            {
                _books = value;
            }
        }

        public Library(int bookLimit)
        {
            Books = new List<Book>();
            BookLimit = bookLimit;
        }

        public void AddBook(Book book)
        {

            if (Books.Count>=BookLimit)
            {
                CapacityLimitException.CapacityLimit();
            }
            else
            {
                List<Book> newBook = Books.FindAll(x => x.Name == book.Name);

                if (newBook.Find(x => x.Name == book.Name) == null && book.IsDeleted == false)
                {
                    Books.Add(book);
                    Console.WriteLine(" Book is Added");
                    return;
                }
                else
                {
                    AlreadyExistsException.AlreadyExists();
                    return;
                }
            }
        }

        public void GetBookById(int? id)
        {
            if (id == null)
            {
                NullReferenceExcept.NullReference();
            }
            else
            {
                List<Book> books = Books.FindAll(x => x.Id == id);

                Book book = books.Find(x => x.Id == id);
                if (book == null )
                {
                    NotFoundException.NotFound();
                }
                else if(book.IsDeleted == false)
                {
                    book.ShowInfo();
                }
            }
        }

        public void GetAllBooks()
        {
            List<Book> allBooks = new List<Book>();
            allBooks.AddRange(Books);
            foreach (var book in allBooks)
            {
                book.ShowInfo();
            }
        }

        public void DeleteBookById(int? id)
        {
            if (id == null)
            {
                NullReferenceExcept.NullReference();
            }
            else
            {
                Book book = Books.Find(x => x.Id == id);
                if (book != null && book.IsDeleted == false)
                {

                    book.IsDeleted = true;
                    Books.Remove(book);
                    Console.WriteLine(" Book is Deleted!");
                }
                else if (book == null)
                {
                     NotFoundException.NotFound();
                }
            }
        }

        public void EditBookName(int? id)
        {
            if (id == null)
            {
                NullReferenceExcept.NullReference();
            }
            else
            {
                Book book = Books.Find(x => x.Id == id);
                if (book==null)
                {
                    NotFoundException.NotFound();
                }
                else
                {
                    Console.Write(" Enter new Book Name :");
                    string newName = Console.ReadLine();
                    book.Name = newName;
                    Console.WriteLine(" Name Is Changed");
                }
            }
        }
   
        public Book FilterByPageCount(int minPageCount, int maxPageCount)
        {
            //Console.Write("Enter Min Page");
            //int minPg= Convert.ToInt32(Console.ReadLine());

            //Console.Write("Enter Max Page");
            //int maxPg = Convert.ToInt32(Console.ReadLine());

            Book book = Books.Find(x => x.PageCount >= minPageCount && x.PageCount <= maxPageCount && x.IsDeleted==false);
        
            return book;
        }
    }
}