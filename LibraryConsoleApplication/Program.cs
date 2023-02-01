using LibraryApplication.Operation;

var function = new Function();

Console.WriteLine("Welcome to our book store.");

while (true)
{
    Console.WriteLine("\nPress [1] to view all the available books.");
    Console.WriteLine("Press [2] to add a new book.");
    Console.WriteLine("Press [3] to update an existing book.");
    Console.WriteLine("Press [4] to delete either of the book.");

    var action = Util.Console.AskQuestion("\nEnter your action to be performed: ");

    string repeat;

    switch (action)
    {
        case "1":
            function.DisplayBooks();
            break;

        case "2":
            while (true)
            {
                function.AddBook(function.BookDetails("added"));
                repeat = function.RepeatQuestion("add");

                if (repeat == "N")
                {
                    break;
                }
            }
            break;

        case "3":
            while (true)
            {
                function.UpdateBook(function.BookDetails("updated"));
                repeat = function.RepeatQuestion("update");

                if (repeat == "N")
                {
                    break;
                }
            }
            break;

        case "4":
            while (true)
            {
                var id = int.Parse(Util.Console.AskQuestion("\nBook ID [to be deleted]: "));

                function.DeleteBook(id);
                repeat = function.RepeatQuestion("delete");

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

    var result = Util.Console.AskQuestion("\nDo you want to perform any other action? (Y/N) ");

    if (result == "Y")
    {
        continue;
    }
    else if (result == "N")
    {
        break;
    }

}

Console.WriteLine();