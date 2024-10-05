using LibraryConsoleApplication.Operation;

var function = new Function();

Console.WriteLine("Welcome to our book store.");

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Press [1] to view all the available books.");
    Console.WriteLine("Press [2] to add a new book.");
    Console.WriteLine("Press [3] to update an existing book.");
    Console.WriteLine("Press [4] to delete either of the book.");

    var action = LibraryConsoleApplication.Utility.Console.AskQuestion("\nEnter your action to be performed: ");

    string repeat;

    switch (action)
    {
        case "1":
            function.DisplayBooks();
            break;

        case "2":
            while (true)
            {
                function.AddBook(Function.BookDetails("added"));
                repeat = Function.RepeatQuestion("add");

                if (repeat == "N")
                {
                    break;
                }
            }
            break;

        case "3":
            while (true)
            {
                function.UpdateBook(Function.BookDetails("updated"));
                repeat = Function.RepeatQuestion("update");

                if (repeat == "N")
                {
                    break;
                }
            }
            break;

        case "4":
            while (true)
            {
                var id = int.Parse(LibraryConsoleApplication.Utility.Console.AskQuestion("\nBook ID [to be deleted]: "));

                function.DeleteBook(id);
                repeat = Function.RepeatQuestion("delete");

                if (repeat == "N")
                {
                    break;
                }
            }
            break;

        default:
            Console.WriteLine("Enter a valid function from the given actions");
            break;
    }

    var result = LibraryConsoleApplication.Utility.Console.AskQuestion("\nDo you want to perform any other action? (Y/N) ");

    if (result == "Y")
    {
        continue;
    }

    if (result == "N")
    {
        break;
    }

}

Console.WriteLine();