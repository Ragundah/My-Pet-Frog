using System;
using System.Runtime.InteropServices;
using System.Threading;
using Typewriter;

namespace MyPetFrog;
class MyPetFrog
{
    private static void Main(string[] args)
    {
        InitConsole();
        Env.SetPos(0, 0);
        Write.String("This is an {y}example{c} of {g}Multi{cb}Colored{c} text!");
        Write.LineEnd(250);
        Write.String(ConsoleColor.Red,"This is a second line of text to display after the first line.");
        Console.ReadKey();
    }

    private static void InitConsole()
    {
        Env.Init(100,20);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Env.GenerateBorder('█');

        Console.ForegroundColor = ConsoleColor.Green;
        Env.SetPos(76, 16);
        Console.Write(">___)/_\\-----/_\\(___<");
        Env.SetPos(76, 15);
        Console.Write("__\\\\ \\\\       // //__");
        Env.SetPos(76, 14);
        Console.Write("   / _/'-----'\\_ \\");
        Env.SetPos(76, 13);
        Console.Write("    __(   \"   )__");
        Env.SetPos(76, 12);
        Console.Write("      (')-=-(')");
        Env.SetPos(76, 11);
        Console.Write("       _     _");
        Env.SetPos(76, 10);
        Console.Write("       V. 0.1a");
        Env.SetPos(76, 9);
        Console.Write("     My Pet Frog");
        Env.SetPos(0,0);
        Console.ForegroundColor = ConsoleColor.White;

        
    }

    
}