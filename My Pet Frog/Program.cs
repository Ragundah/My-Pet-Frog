using System;
using System.Runtime.InteropServices;
using System.Threading;
using Typewriter;


namespace MyPetFrog;

class MyPetFrog
{
    // 75 working width
    // 18 Working hieght
    // Variables:
    private static PeriodicTimer UpdateTimer, ProcessingTimer, GameTimer, AgeTimer;
    private static TimeSpan GameTimerWaitDuration = TimeSpan.FromSeconds(15);
    private static float FrogAge, FrogHealth, FrogHunger, FrogHappiness;
    private static string FrogName, ClearLineString, HappinessString;

// Game Launches Here...
    private static void Main(string[] args)
    {
        Init(); // Set Console Flags, Create Border, Create Logo, Show Version
        TimerInit(); // Set Default Timer Values and Enable Update and Processing timers.
        Intro(); // Game Intro - Set the feel & Collect frog name.
        Write.AwaitInput(); // Prevent game from closing...
    }

// Set Console Flags, Create Border, Create Logo, Show Version
    private static void Init()
    {
        Env.Init(100, 20);
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("       V. 0.3a");
        Env.SetPos(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.CursorVisible = false;
        FrogHealth = 100;
        FrogHunger = 100;
        FrogHappiness = 100;
        FrogAge = 1;
    }
    
// Set Default Timer Values and Enable Update and Processing timers.
    private static void TimerInit()
    {
        UpdateTimer = new PeriodicTimer(TimeSpan.FromSeconds(0.075));
        ProcessingTimer = new PeriodicTimer(TimeSpan.FromSeconds(0.001));
        GameTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));
        AgeTimer = new PeriodicTimer(TimeSpan.FromMinutes(2.5)); // Age = 13 @ 30 Mins
        Update();
        Processing();
    }
    
// Enable ASAP. Handles Graphics.
    private async static void Update()
    {
        // Do Things. You Can Touch GUI...
        while (await UpdateTimer.WaitForNextTickAsync())
        {
            
        }
    }
    
// Enable ASAP. Handles Math.
    private async static void Processing()
    {
        // Do Things... Don't Touch GUI.
        while (await ProcessingTimer.WaitForNextTickAsync())
        {
            if(FrogAge > 15 || FrogAge < 1) { FrogAge = Math.Clamp(FrogAge, 1, 17); }
            if(FrogHealth > 100 || FrogHealth < 0) { FrogHealth = Math.Clamp(FrogAge, 0, 100); }
            if(FrogHunger > 100 || FrogHunger < 0) { FrogHunger = Math.Clamp(FrogHunger, 0, 100); }
            if(FrogHappiness > 200 || FrogHappiness < 0) { FrogHappiness = Math.Clamp(FrogHappiness, 0, 200); }
            if (FrogHappiness > 175) { HappinessString = "Very Happy"; } else
            {
                if (FrogHappiness > 150) { HappinessString = "Happy"; }
                else
                {
                    if (FrogHappiness > 50) { HappinessString = "Neutral"; }
                    else
                    {
                        if (FrogHappiness > 25) { HappinessString = "Sad"; }
                        else
                        {
                            HappinessString = "Very Sad";
                        }
                    }
                }
            }
        }
    }
    
// Enable on Game Start. Random Event Handler & In-Game GUI Updates.
    private async static void Game()
    {
        while (await GameTimer.WaitForNextTickAsync())
        {
            // Do Game Stuff.
        }
    }
    
// Enable on Game Start. Modify Age & Set Correct Game Timer Speed.
    private async static void Age()
    {
        while (await AgeTimer.WaitForNextTickAsync())
        {
            FrogAge++;
            switch (FrogAge)
            {
                case 1: { GameTimerWaitDuration = TimeSpan.FromSeconds(10); break; }
                case 2: { GameTimerWaitDuration = TimeSpan.FromSeconds(9); break; }
                case 3: { GameTimerWaitDuration = TimeSpan.FromSeconds(8); break; }
                case 4: { GameTimerWaitDuration = TimeSpan.FromSeconds(7); break; }
                case 5: { GameTimerWaitDuration = TimeSpan.FromSeconds(6); break; }
                case 6: { GameTimerWaitDuration = TimeSpan.FromSeconds(5); break; }
                case 7: { GameTimerWaitDuration = TimeSpan.FromSeconds(4); break; }
                case 8: { GameTimerWaitDuration = TimeSpan.FromSeconds(3); break; }
                case 9: { GameTimerWaitDuration = TimeSpan.FromSeconds(2.5); break; }
                case 10: { GameTimerWaitDuration = TimeSpan.FromSeconds(2); break; }
                case 11: { GameTimerWaitDuration = TimeSpan.FromSeconds(1.5); break; }
                case 12: { GameTimerWaitDuration = TimeSpan.FromSeconds(1); break; }
                case 13: { GameTimerWaitDuration = TimeSpan.FromSeconds(0.75); break; }
                case 14: { GameTimerWaitDuration = TimeSpan.FromSeconds(0.5); break; }
                case 15: { GameTimerWaitDuration = TimeSpan.FromSeconds(0.25); break; }
                case 16: { GameTimerWaitDuration = TimeSpan.FromSeconds(0.1); break; }
                default: { GameTimerWaitDuration = TimeSpan.FromSeconds(0.025); break; }
            }
            GameTimer = new PeriodicTimer(GameTimerWaitDuration);
        }
    }

    private static void Intro()
    {
        Env.Clear();
        Env.SetPos(0, 0);
        Write.String("Welcome intrepid youth. So you want to be a {g}frog{c} owner I hear!");
        Write.LineEnd();
        Write.String("While taking care of a {g}frog{c} might sound like a great time...");
        Write.LineEnd();
        Write.String("there are some things you will need to know.");
        Write.LineEnd();
        Write.LineEnd();
        Write.String("{g}Frogs{c} have an average lifespan of 13 years!");
        Write.LineEnd();
        Write.String("This means it might seem easy to take care of a {g}frog{c} at first, but");
        Write.LineEnd();
        Write.String("over time it will become more difficult to keep up with thier needs.");
        Write.LineEnd();
        Write.String("Be sure you are prepared for the best and the worst!");
        Write.LineEnd();
        Write.String("You will need to {y}Play{c}, {y}Feed{c}, and {y}Heal{c} when required.");
        Write.LineEnd();
        Write.String("Remember, your {g}frog{c} has feelings too!");
        Write.LineEnd();
        Write.LineEnd();
        Write.String("Are you sure you are ready for this adventure?");
        Write.LineEnd();
        Write.String("[Y] - Yes | [N] - No");
        Write.LineEnd();
        Write.LineEnd();
        bool answered = false;
        while(!answered)
        {
            switch (Write.AwaitInput())
            {
                case 'y': { answered = true; break; }
                case 'n': { Env.Clear(); Env.SetPos(0, 0); Write.String("I see... in that case you should be on your way..."); Write.LineEnd(1000); Write.String("Stay safe out there... friend."); Write.LineEnd(1000); Environment.Exit(2); break; }
                default: { Env.SetPos(0, Console.CursorTop - 2); Console.ForegroundColor = ConsoleColor.Red; Console.Write("Invalid input, please try again..."); Console.ForegroundColor = ConsoleColor.White; Env.SetPos(0, Console.CursorTop); break; }
            }
        }
        Env.Clear();
        Env.SetPos(0, 0);
        Write.String("Wonderful! I have one more question for you before you wake up.");
        Write.LineEnd();
        Write.String("What would you name your {g}frog{c}?");
        Write.LineEnd();
        Write.LineEnd();
        Write.LineEnd();
        bool named = false;
        while (!named)
        {
            FrogName = Console.ReadLine();
            Console.SetCursorPosition(2, Console.CursorTop - 1);
            string WidthText = "";
            for (int i = 0; i < Console.WindowWidth - 25; i++)
            {
                WidthText += " ";
            }
            Console.Write(WidthText);
            Console.SetCursorPosition(2, Console.CursorTop);
            if (FrogName.Length > 75)
            {
                Thread.Sleep(1000); Console.Clear();
                while (true)
                {
                    Write.String("Great, you broke it... are you happy?");
                    Thread.Sleep(100);
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                if (FrogName.Length >= 22)
                {
                    Console.SetCursorPosition(2, Console.CursorTop - 2);
                    Write.String("{r}Sorry, but the max length for a name is 21 characters.{c}");
                    Write.LineEnd(); Write.LineEnd();
                }
                else
                {
                    Write.String("Are you sure you like the name {g}" + FrogName + "{c}?");
                    Write.LineEnd();
                    answered = false;
                    while (!answered)
                    {
                        switch (Write.AwaitInput())
                        {
                            default: break;
                        }
                    }
                }
            }
        }
    }
}
    /*
    private static void WriteLine(string s)
    {
        Write.String(s);
        Write.LineEnd(50);
    }

    private static void BounceBack(Thread t, ParameterizedThreadStart s, int d)
    {
        t.Abort();
        Thread.Sleep(d);
        t = new Thread(s);
        t.Start();
    }

    private static void Main(string[] args)
    {
        GuiUpdateThread = new Thread(GuiUpdate);
        MathUpdateThread = new Thread(MathUpdate);
        MathUpdateThread.SetApartmentState(ApartmentState.STA);
        RNGTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(1));
        AgeThread = new Thread(AgeUpdate);
        //RNGThread = new Thread(RNGUpdate);
        MathUpdateThread.Start();
        InitConsole();
        Env.SetPos(0, 0);
        Config.SetWriteSpeed(40);
        StartGame();
        Console.ReadKey();
    }

    private static void StartGame()
    {
        Console.Title = "My Pet Frog - Version 0.2a";
        MainMenuLock = true;
        while (MainMenuLock)
        {
            Env.Clear();
            //WriteLine("My Pet Frog");
            //WriteLine("({g}S{c}) - Start Game");
            //WriteLine("({y}H{c}) - Help");
            //WriteLine("({r}Q{c}) - Quit Game");

            switch (Write.AwaitInput().ToString().ToLower())
            {
                case "s":
                    {
                        Env.Clear();
                        WriteLine("You get home after a long day at school.");
                        WriteLine("You collapse on your bed and pass out. The weekend ahead of you.");
                        WriteLine("When you wake up you can hear talking downstairs... two people.");
                        WriteLine("This is weird because your parents had seperated.");
                        WriteLine("When you get downstairs you see both of your parents.");
                        WriteLine("They look at you with a smile confusing you a bit.");
                        WriteLine("They said {y}\"We have something for you!\"{c}");
                        WriteLine("Upon inspection they held a box together...");
                        WriteLine("You take the box into your hands and open it");
                        Config.SetWriteSpeed(100);
                        WriteLine("Revealing...");
                        WriteLine("Your new... pet... {g}Frog{c}!");
                        Write.AwaitInput();
                        Config.SetWriteSpeed(40);
                        bool NameSelected = false;
                        string ErrorText = "";
                        while (!NameSelected)
                        {
                            Env.Clear();
                            if (ErrorText != "") { WriteLine(ErrorText); Write.LineEnd(); }
                            WriteLine("What will you name your new pet {g}frog{c}?");
                            Write.LineEnd();
                            Console.Write("Name: ");
                            FrogName = Console.ReadLine();
                            if(FrogName.Length > 21) { ErrorText = "{r}Your frog's name can't be longer than 21 characters."; }
                            else
                            {
                                WriteLine("Are you sure you like the name " + FrogName + "?");
                                WriteLine("This name CANNOT be changed later!");
                                WriteLine("({g}Y{c}) - Yes");
                                WriteLine("({r}N{c}) - No");
                                switch (Write.AwaitInput().ToString().ToLower())
                                {
                                    case "y":
                                        {
                                            NameSelected = true;
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }

                                }
                            }
                        }
                        MainMenuLock = false;
                        // Begin Game
                        break;
                    }
                case "h":
                    {
                        Env.Clear();
                        WriteLine("Help:");
                        WriteLine("Your pet frog starts off young and strong.");
                        WriteLine("Over time your pet frog will begin to decay and age.");
                        WriteLine("You must maintain your pet frog's {r}Health{c}, {y}Hunger{c}, and {g}Happiness{c}.");
                        WriteLine("As they get older this will become harder to do.");
                        WriteLine("Take care of your frog and enjoy spending a lot of time with them!");
                        WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        WriteLine("No Frogs Were Harmed In The Making Of This Game...");
                        Console.ForegroundColor = ConsoleColor.White;
                        Write.AwaitInput();
                        break;
                    }
                case "q":
                    {
                        Environment.Exit(0);
                        MainMenuLock = false;
                        break;
                    }
                case "a":
                    {
                        Age++;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }

    private static void MathUpdate()
    {
        while (GamePaused)
        {
            Thread.Sleep(10);
        }
        Thread.Sleep(10);
        while (GamePaused)
        {
            Thread.Sleep(10);
        }
        Health = Math.Clamp(Health, 0, 100);
        Hunger = Math.Clamp(Hunger, 0, 100);
        Happiness = Math.Clamp(Happiness, 0, 200);
    }

    private static void GuiUpdate()
    {
        while (GamePaused)
        {
            Thread.Sleep(10);
        }
        Thread.Sleep(100);
        while (GamePaused)
        {
            Thread.Sleep(10);
        }
        Config.Busy();
        ConsoleColor originalColor = Console.ForegroundColor;
        int originalX = Console.CursorLeft, originalY = Console.CursorTop;
        string temp;
        Env.SetPos(100 - (21 + 3), 0);
        switch (Health)
        {
            case 100:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   Health: 100/100");
                Env.SetPos(100 - (21 + 3), 1);
                Console.Write(" █ █ █ █ █ █ █ █ █ █ ");
                break;
            case > 66:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   Health:  " + Health + "/100");
                Env.SetPos(100 - (21 + 3), 1);
                temp = " ";
                for (int i = 0; i < Health / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Health / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
            case > 33:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   Health:  " + Health + "/100");
                Env.SetPos(100 - (21 + 3), 1);
                temp = " ";
                for (int i = 0; i < Health / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Health / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
            case > 9:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   Health:  " + Health + "/100");
                Env.SetPos(100 - (21 + 3), 1);
                temp = " ";
                for (int i = 0; i < Health / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Health / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
            case < 10:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   Health:   " + Health + "/100");
                Env.SetPos(100 - (21 + 3), 1);
                temp = " ";
                for (int i = 0; i < Health / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Health / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
        }
        Env.SetPos(100 - (21 + 3), 3);
        switch (Hunger)
        {
            case 100:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   Hunger: 100/100");
                Env.SetPos(100 - (21 + 3), 4);
                Console.Write(" █ █ █ █ █ █ █ █ █ █ ");
                break;
            case > 66:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   Hunger:  " + Hunger + "/100");
                Env.SetPos(100 - (21 + 3), 4);
                temp = " ";
                for (int i = 0; i < Hunger / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Hunger / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
            case > 33:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("   Hunger:  " + Hunger + "/100");
                Env.SetPos(100 - (21 + 3), 4);
                temp = " ";
                for (int i = 0; i < Hunger / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Hunger / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
            case > 9:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   Hunger:  " + Hunger + "/100");
                Env.SetPos(100 - (21 + 3), 4);
                temp = " ";
                for (int i = 0; i < Hunger / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Hunger / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
            case < 10:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("   Hunger:   " + Hunger + "/100");
                Env.SetPos(100 - (21 + 3), 4);
                temp = " ";
                for (int i = 0; i < Hunger / 10; i++)
                {
                    temp += "█ ";
                }
                for (int i = 0; i < 10 - Hunger / 10; i++)
                {
                    temp += "  ";
                }
                Console.Write(temp);
                break;
        }
        Env.SetPos(100 - (21 + 3), 6);
        if (Happiness > 99) { Console.ForegroundColor = ConsoleColor.Green; }
        if (Happiness < 99) { Console.ForegroundColor = ConsoleColor.Yellow; }
        if (Happiness < 50) { Console.ForegroundColor = ConsoleColor.Red; }
        Console.Write(GetHappinessLevel());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Env.SetPos(76, 8);
        Console.Write("     My Pet Frog");
        Env.SetPos(76, 9);
        int fluff = 21 - FrogName.Length; fluff = fluff / 2;
        string sfluff = "";
        for (int i = 0; i < fluff; i++)
        {
            sfluff += " ";
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(sfluff + FrogName);
        Console.ForegroundColor = originalColor;
        Console.SetCursorPosition(originalX, originalY);
        Config.Free();
        GuiUpdate();
    }

    private static string GetHappinessLevel()
    {
        switch (Happiness)
        {
            case > 149:
                return "     Very  Happy     ";
            case > 99:
                return "        Happy        ";
            case > 49:
                return "        Upset        ";
            case < 50:
                return "      Depressed      ";
        }
    }

    private static void InitConsole()
    {
        Env.Init(100,20);
        Console.CursorVisible = false;
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
        Console.ForegroundColor= ConsoleColor.Yellow;
        Console.Write("       V. 0.2a");
        Env.SetPos(0,0);
        Console.ForegroundColor = ConsoleColor.White;


        AgeThread.Start();
        RNGUpdate();
    }

    private async static void RNGUpdate()
    {
        while(await RNGTimer.WaitForNextTickAsync())
        {
            Config.Busy();
            Age++;
            int curX = Console.GetCursorPosition().Left, curY = Console.GetCursorPosition().Top;
            ConsoleColor origColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Env.SetPos(0, 17);
            Console.Write(widthString);
            Env.SetPos(0, 17);
            Console.Write("Age... " + Age);
            Console.SetCursorPosition(curX, curY);
            Console.ForegroundColor = origColor;
            Config.Free();
            DateTime dt = DateTime.Now;
            
        }
    }

    //private static void RNGUpdate()
    //{
    //    while (GamePaused)
    //    {
    //        Thread.Sleep(10);
    //    }
    //    Config.Busy();
    //    int curX = Console.GetCursorPosition().Left, curY = Console.GetCursorPosition().Top;
    //    ConsoleColor origColor = Console.ForegroundColor;
    //    Console.ForegroundColor = ConsoleColor.Yellow;
    //    Env.SetPos(0, 17);
    //    Console.Write(widthString);
    //    Env.SetPos(0, 17);
    //    Console.Write("Current Speed... " + (int)(30000 / MathF.Pow(2, Age / 2) - 100) + " Age... " + Age);
    //    Console.SetCursorPosition(curX, curY);
    //    Console.ForegroundColor = origColor;
    //    Config.Free();
    //    Thread.Sleep(Math.Clamp((int)(30000/MathF.Pow(2,Age/2)-100),1, 30000));
    //    while (GamePaused)
    //    {
    //        Thread.Sleep(10);
    //    }
    //    
    //}

    private static void AgeUpdate()
    {
        while (GamePaused)
        {
            Thread.Sleep(10);
        }
        Thread.Sleep(1000*60*5);
        while (GamePaused)
        {
            Thread.Sleep(10);
        }
        Age++;
        AgeUpdate();
    }

}

// Main Menu
// Game Intro
// Game Loop
// Game Over
// Easter Egg
// :)
    */