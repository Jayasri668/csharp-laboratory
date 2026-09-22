using System;
using System.Collections.Generic;

class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }

    public Book(
        int bookId,
        string title,
        string author,
        string category,
        double price)
    {
        BookId = bookId;
        Title = title;
        Author = author;
        Category = category;
        Price = price;
    }

    public void DisplayBookDetails()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Book ID  : {BookId}");
        Console.WriteLine($"Title    : {Title}");
        Console.WriteLine($"Author   : {Author}");
        Console.WriteLine($"Category : {Category}");
        Console.WriteLine($"Price    : Rs. {Price:F2}");
    }
}

class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>();

        books.Add(
            new Book(
                101,
                "Wings of Fire",
                "A. P. J. Abdul Kalam",
                "Biography",
                350.00));

        books.Add(
            new Book(
                102,
                "The Alchemist",
                "Paulo Coelho",
                "Fiction",
                499.00));

        books.Add(
            new Book(
                103,
                "Clean Code",
                "Robert C. Martin",
                "Programming",
                650.00));

        Console.WriteLine("BOOK MANAGEMENT SYSTEM");
        Console.WriteLine("======================");

        Console.WriteLine("\nAvailable Books:");

        foreach (Book book in books)
        {
            book.DisplayBookDetails();
        }

        Console.WriteLine("\n------------------------------------------");
        Console.Write("Enter a book title to search: ");

        string searchTitle = Console.ReadLine() ?? "";
        Book? foundBook = null;

        foreach (Book book in books)
        {
            if (book.Title.Equals(
                searchTitle,
                StringComparison.OrdinalIgnoreCase))
            {
                foundBook = book;
                break;
            }
        }

        if (foundBook != null)
        {
            Console.WriteLine("\nBook found:");
            foundBook.DisplayBookDetails();
        }
        else
        {
            Console.WriteLine("\nBook not found in the collection.");
        }
    }
}