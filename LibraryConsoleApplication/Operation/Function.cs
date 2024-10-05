using LibraryConsoleApplication.Models;

namespace LibraryConsoleApplication.Operation;

public class Function
{
    private readonly List<Book> _books = [];

    public static Book BookDetails(string action)
    {
        var book = new Book();

        while (true)
        {
            var result = int.TryParse(Utility.Console.AskQuestion($"\nBook ID [to be {action}]: "), out var id);

            if (result)
            {
                book.Id = id;
                break;
            }

            Console.WriteLine("Enter a valid integer for book code.\n");
        }

        book.Title = Utility.Console.AskQuestion("Book Title: ");

        book.Author = Utility.Console.AskQuestion("Book Author: ");

        while (true)
        {
            var result = int.TryParse(Utility.Console.AskQuestion("Book Quantity: "), out int quantity);

            if (result)
            {
                book.Quantity = quantity;
                break;
            }

            Console.WriteLine("Enter a valid integer for book quantity.\n");
        }

        while (true)
        {
            var result = decimal.TryParse(Utility.Console.AskQuestion("Book Price: $"), out var price);

            if (result)
            {
                book.UnitPrice = price;
                break;
            }

            Console.WriteLine("Enter a valid price for book price.\n");
        }

        return book;
    }

    public void DisplayBooks()
    {
        if (_books.Count != 0)
        {
            foreach (var book in _books)
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
            _books.Add(book);
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
            var bookObject = _books.FirstOrDefault(b => b.Id == book.Id);

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

    public void DeleteBook(int id)
    {
        try
        {
            var bookObject = _books.FirstOrDefault(b => b.Id == id);

            if (bookObject != null)
            {
                _books.Remove(bookObject);
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

    public static string RepeatQuestion(string operation)
    {
        return Utility.Console.AskQuestion($"\nDo you want to {operation} another book? (Y/N) ");
    }
}
