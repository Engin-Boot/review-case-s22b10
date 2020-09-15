using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HandleError
    {
         static Dictionary<string, string> mapErrorCodeWithDiscription = new Dictionary<string, string>
        {
            {"2(0xA)", "Error: Invalid column argument"},
            {"2(0xF)", "invalid file name" }
        };

        public static bool IfErrorLogInConsole(string errorData)
        {
            foreach(var code in mapErrorCodeWithDiscription)
            {
                if (errorData.Contains(code.Key))
                {
                    LogErrorInConsole(code.Key);
                    return true;
                }
            }
            return false;
        } 
        public static void LogErrorInConsole(string errorCode)
        {
            Console.WriteLine(mapErrorCodeWithDiscription[errorCode]);
        }
    }
}
