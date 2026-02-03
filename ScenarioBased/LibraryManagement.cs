namespace ScenarioBased
{
    public class Book
    {
        string Title{get;set;}
        string Authot{get;set;}
        string Genre{get;set;}
        int PublicationYear{get;set;}

        public void AddBook(string title, string author, string genre, int year)
        {
            
        }

        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            
        }

        public List<Book> GetBooksByAuthor(string author)
        {
            
        }

        public int GetTotalBooksCount()
        {
            
        }
    }
}