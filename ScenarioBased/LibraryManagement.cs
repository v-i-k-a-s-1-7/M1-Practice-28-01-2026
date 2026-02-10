namespace ScenarioBased
{
    public class Book
    {
        public int Id;
        public string Title{get;set;}
        public string Author{get;set;}
        public string Genre{get;set;}
        public int PublicationYear{get;set;}

        public Book()
        {
            
        }

        // whenever anyone tries to print Book this will work
        public override string ToString()
        {
            return $"[{Id}] {Title} by {Author} ({PublicationYear})";
        }
    }

    public class LibraryUtility
    {
        public static int id = 1;
        public static List<Book> books = new List<Book>();

        public void AddBook(string title, string author, string genre, int year)
        {

            int currentId = id;
            id++;
            books.Add(new Book
            {

                Id = currentId,
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = year

            });
        }

        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> groupByGenre = new SortedDictionary<string, List<Book>>();
            
            if (books == null)
            {
                return groupByGenre;
            }
            foreach(var item in books)
            {
                if (groupByGenre.ContainsKey(item.Genre))
                {
                    List<Book> bookList = groupByGenre[item.Genre];
                    bookList.Add(item) ;
                }
                else
                {
                    List<Book> bookList = new List<Book>();
                    bookList.Add(item);
                    groupByGenre[item.Genre] = bookList;
                }
            }
            return groupByGenre;
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> booksByAuthor = new List<Book>();
            foreach(var item in books)
            {
                if(item.Author == author)
                {
                    booksByAuthor.Add(item);
                }
            }
            return booksByAuthor;
        }

        public int GetTotalBooksCount()
        {
            return books.Count;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            LibraryUtility library = new LibraryUtility();

            library.AddBook("Harry Potter and the Philosopher's Stone", "J.K. Rowling", "Fantasy", 1997);
            library.AddBook("Harry Potter and the Chamber of Secrets", "J.K. Rowling", "Fantasy", 1998);

            library.AddBook("The Hobbit", "J.R.R. Tolkien", "Fantasy", 1937);

            library.AddBook("1984", "George Orwell", "Dystopian", 1949);
            library.AddBook("Animal Farm", "George Orwell", "Dystopian", 1945);

            library.AddBook("The Alchemist", "Paulo Coelho", "Fiction", 1988);
            library.AddBook("Inferno", "Dan Brown", "Thriller", 2013);

            SortedDictionary<string,List<Book>> groupByGenre = new SortedDictionary<string, List<Book>>();
            groupByGenre = library.GroupBooksByGenre();

            foreach(var item in groupByGenre)
            {
                Console.WriteLine($"Genre: {item.Key}");

                foreach(var book in item.Value)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine();
            }

            List<Book> booksByAuthor = new List<Book>();
            booksByAuthor = library.GetBooksByAuthor("J.K. Rowling");

            foreach(var item in booksByAuthor)
            {
                Console.WriteLine($"{item}");
            }

        }
    }
}