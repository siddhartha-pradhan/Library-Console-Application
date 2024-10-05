namespace LibraryConsoleApplication.Utility;

public abstract class Console
{
    public static string AskQuestion(string question)
    {
        while (true)
        {
            System.Console.Write(question);

            var answer = System.Console.ReadLine();
            
            if (string.IsNullOrEmpty(answer))
            {
                continue;
            }

            return answer;
        }
    }
}
