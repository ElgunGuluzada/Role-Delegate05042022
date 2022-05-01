using System;
using System.Collections.Generic;
using Utils.Enums;

namespace Role_Delegate05042022
{
    internal class Program
    {

        static void Main(string[] args)
        {
        R1: Console.Write(" Choose Your Role: ");
           
            string name = Console.ReadLine();

            if (name.ToLower() != "admin" && name.ToLower() != "member")
            {
                goto R1;
            }
            //Role role = Enum.Parse<Role>(name);
            Role role = (Role)Enum.Parse(typeof(Role), name.ToLower());
           
            User user = new User("Guluzade", "elgunpg@code.edu.az", role);


            Book book = new Book("Ana Dili", "Hesen", 24);
            Book book1 = new Book("Riyaziyyat", "Hesen", 24);
            Book book2 = new Book("Oxu", "Hesen", 24);
            Book book3 = new Book("Cebr", "Hesen", 24);


            Console.Write(" Write want do you count of books: ");
            int bookLimit = Convert.ToInt32(Console.ReadLine());
            Library library = new Library(bookLimit);
            library.AddBook(book);
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            library.DeleteBookById(0);

            library.GetBookById(0);
        }
    }
}
