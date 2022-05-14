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
        Write.String("This is an {y}example{c} of {g}Multi{cb}Colored{c} text!");
        Write.LineEnd(250);
        Write.String(ConsoleColor.Red,"This is a second line of text to display after the first line.");
        Console.ReadKey();
    }

    private static void InitConsole()
    {
        Console.SetWindowSize(100, 20);
        Console.SetBufferSize(100, 20);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(78, 18);
        Console.Write(">___)/_\\-----/_\\(___<");
        Console.SetCursorPosition(78, 17);
        Console.Write("__\\\\ \\\\       // //__");
        Console.SetCursorPosition(78, 16);
        Console.Write("   / _/'-----'\\_ \\");
        Console.SetCursorPosition(78, 15);
        Console.Write("    __(   \"   )__");
        Console.SetCursorPosition(78, 14);
        Console.Write("      (')-=-(')");
        Console.SetCursorPosition(78, 13);
        Console.Write("       _     _");
        Console.SetCursorPosition(78, 12);
        Console.Write("       V. 0.1a");
        Console.SetCursorPosition(78, 11);
        Console.Write("     My Pet Frog");
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;

        IntPtr handle = GetConsoleWindow();
        IntPtr sysMenu = GetSystemMenu(handle, false);

        if (handle != IntPtr.Zero)
        {
            DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
        }
    }

    private const int MF_BYCOMMAND = 0x00000000;
    public const int SC_MINIMIZE = 0xF020;
    public const int SC_MAXIMIZE = 0xF030;
    public const int SC_SIZE = 0xF000;

    [DllImport("user32.dll")]
    public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

    [DllImport("user32.dll")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
}