using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConsoleApplication.Operation;

namespace LibraryApplication.Operation;

public class Function
{
    private List<Book> books = new List<Book>();

    public Book BookDetails(string action)
    {
        var book = new Book();

        while (true)
        {
            var result = int.TryParse(Util.Console.AskQuestion($"\nBook ID [to be {action}]: "), out int Id);

            if (result)
            {
                book.Id = Id;
                break;
            }
            else
            {
                Console.WriteLine("Enter a valid integer for book code.\n");
            }
        }

        book.Title = Util.Console.AskQuestion("Book Title: ");

        book.Author = Util.Console.AskQuestion("Book Author: ");

        while (true)
        {
            var result = int.TryParse(Util.Console.AskQuestion("Book Quantity: "), out int quantity);

            if (result)
            {
                book.Quantity = quantity;
                break;
            }
            else
            {
                Console.WriteLine("Enter a valid integer for book quantity.\n");
            }
        }

        while (true)
        {
            var result = decimal.TryParse(Util.Console.AskQuestion("Book Price: $"), out decimal price);

            if (result)
            {
                book.UnitPrice = price;
                break;
            }
            else
            {
                Console.WriteLine("Enter a valid price for book price.\n");
            }
        }

        return book;
    }

    public void DisplayBooks()
    {
        if (books.Count != 0)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"\nBook ID: {book.Id}");
                Console.WriteLine($"Book Title: {book.Title}");
                Console.WriteLine($"Book Author: {book.Author}");
                Console.WriteLine($"Book Quantity: {book.Quantity}");
                Console.WriteLine($"Book Price: ${book.UnitPrice}");
            }
        }
        else
        {
            Console.WriteLine("\nNo any books have been stored in the list.");
        }
    }

    public void AddBook(Book book)
    {
        try
        {
            books.Add(book);
            Console.WriteLine("\nBook successfully added.");
        }
        catch (Exception)
        {
            Console.WriteLine("\nError adding a book to our library.\n");
        }
    }

    public void UpdateBook(Book book)
    {
        try
        {
            var bookObject = books.FirstOrDefault(b => b.Id == book.Id);

            if (bookObject != null)
            {
                bookObject.Title = book.Title;
                bookObject.Author = book.Author;
                bookObject.Quantity = book.Quantity;
                bookObject.UnitPrice = book.UnitPrice;
                Console.WriteLine("\nBook successfully updated.");
            }
            else
            {
                Console.WriteLine("\nBook not found.");
            }
        }
        catch (Exception)
        {

            Console.WriteLine("\nError updating an existing book.");
        }
    }

    public void DeleteBook(int Id)
    {
        try
        {
            var bookObject = books.FirstOrDefault(b => b.Id == Id);

            if (bookObject != null)
            {
                books.Remove(bookObject);
                Console.WriteLine("\nBook successfully deleted.");
            }
            else
            {
                Console.WriteLine("\nBook not found.");
            }
        }
        catch (Exception)
        {

            Console.WriteLine("\nError deleting the entered book.");
        }
    }

    public string RepeatQuestion(string operation)
    {
        return Util.Console.AskQuestion($"\nDo you want to {operation} another book? (Y/N) ");
    }
}
