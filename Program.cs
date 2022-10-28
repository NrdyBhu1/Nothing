using Nothing;
using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        if (!Directory.Exists("./Content"))
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Error: Content directory does not exists");
            Console.ResetColor();
            System.Environment.Exit(1);
        }
        NothingGame game = new NothingGame("./Content");
        game.Run();
    }
}