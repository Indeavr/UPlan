using System;

namespace TODO
{
    public class Writer
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void ClearHistory()
        {
            Console.Clear();
        }

        public static void NoUserLogged()
        {
            Console.WriteLine("no user logged");
        }

        public static void RemindText(string message)
        {
            int oldSize = Console.CursorSize;
            Console.CursorSize = 50;           
            Console.WriteLine($"Time for {message}!");
            Console.CursorSize = oldSize;
        }
    }
}
