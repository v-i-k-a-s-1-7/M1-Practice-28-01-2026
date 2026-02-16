using System;


public class Book{
    
    public string Id {get;set;}
    public string Title {get;set;}
    public string Author {get;set;}
    public int Price {get;set;}
    public int Stock{get;set;}
}

public class BookUtility{
    
    private Book book;
    public BookUtility(Book book){
        this.book = book;
    }
    
    public void GetBookDetails(){
        
        Console.WriteLine($"Details: {book.Id} {book.Title} {book.Price} {book.Stock}");
    }
    
    public void UpdateBookPrice(int newPrice){
        
        book.Price = newPrice;
        
        Console.WriteLine($"Updated Price: {book.Price}");
    }
    
    public void UpdateBookStock(int newStock){
        book.Stock = newStock;
        
         Console.WriteLine($"Updated Stock: {book.Stock}");
    }
    
}

public class Program{
    
    public static void Main(string[] args){
        
        Book book1 = new Book();
        string input = Console.ReadLine();
        string[] inputStr = input.Split(" ");
        
        book1.Id = inputStr[0]; 
        book1.Title = inputStr[1];
        // book1.Author = 
        book1.Price = int.Parse(inputStr[2]);
        book1.Stock = int.Parse(inputStr[3]);
        
        BookUtility bku = new BookUtility(book1);
        
        Console.WriteLine("Enter Your Choice");
        Console.WriteLine(" 1 - > Details");
        Console.WriteLine(" 2 -> Update Price");
        Console.WriteLine(" 3 -> Update Stock");
        Console.WriteLine(" 4 -> exit");
        
        
        
            int choice;
            do{
               choice = int.Parse(Console.ReadLine());
            
            switch(choice){
                
                case 1: 
                    bku.GetBookDetails();
                    break;
                case 2:
                    int newPrice = int.Parse(Console.ReadLine());
                    bku.UpdateBookPrice(newPrice);
                    break;
                case 3:
                    int newStock = int.Parse(Console.ReadLine());
                    bku.UpdateBookStock(newStock);
                    break;
                case 4:
                    // flag = false;
                    Console.WriteLine("Thank You");
                    break;
            }
            }while(choice != 4);
            
        }
        
       
    }