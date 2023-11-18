using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cripto_Cesar
{
    public static class MessageConsole
    {
        public static void Show(string message, bool? typeValue = null)
        {

            if(typeValue != null)
            {
                Console.Write(message.ToUpper());
                if(typeValue != true)
                {

                    Console.Write("TYPE: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FALSE");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("TYPE: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("TRUE");
                    Console.ResetColor();
                }
            }
            else Console.WriteLine(message.ToUpper());
        }
        
        public static void ShowResult(string result)
        {
            Console.Write("RESULT: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{result}");
            Console.ResetColor();
        }
    }
}
