using System;

namespace Helpers
{
    public static class Extensions
    {
        public static void ErrorLog(this string str)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void SuccessLog(this string str)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void InfoLog(this string str)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(str);
            Console.WriteLine();
            Console.ResetColor();
        }

        public static void UsualLog(this string str)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(str);
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
