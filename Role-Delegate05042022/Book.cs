using System;
namespace Role_Delegate05042022
{
    public class Book : IEntity
    {
        private static int _id;
        public int Id
        {
            get;
        }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; }


        public Book(string name, string authorName, int pageCount)
        {
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            IsDeleted = false;
            Id = _id;
            _id++;
        }

        public void ShowInfo()
        {
            Console.WriteLine(Name);
        }

    }
}
