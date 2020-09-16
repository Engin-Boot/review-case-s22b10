using System;
using System.Collections.Generic;

namespace Receiver
{
    class HandleError
    {
        static Dictionary<string, string> mapErrorCodeWithDiscription = new Dictionary<string, string>
        {
            {"2(0xA)", "Error: Invalid column argument"},
            {"2(0xF)", "invalid file name" }
        };

        public static void IfErrorLogInConsole(string errorData)
        {
            foreach (var code in mapErrorCodeWithDiscription)
            {
                if (errorData.Contains(code.Key))
                {
                    LogErrorInConsole(code.Key);
                }
            }
        }
        public static void LogErrorInConsole(string errorCode)
        {
            Console.WriteLine(mapErrorCodeWithDiscription[errorCode]);
        }
    }
}
