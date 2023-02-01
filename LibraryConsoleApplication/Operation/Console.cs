using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util;

public class Console
{
    public static string AskQuestion(string question)
    {
        string answer;

        while (true)
        {
            System.Console.Write(question);

            answer = System.Console.ReadLine();
            
            if (answer == "")
            {
                continue;
            }
            else if (answer != "")
            {
                break;
            }
        }

        return answer;
    }
}
