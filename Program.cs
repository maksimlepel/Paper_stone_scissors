using System;
using System.Security.Cryptography;

namespace Paper_stone_scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length % 2 == 0) { Console.WriteLine("Enter an odd number of elements. For example: stone scissors paper"); return; }
            if (args.Length==1) { Console.WriteLine("3 min"); return; }
            string[] sortedCopy = (string[])args.Clone();
            Array.Sort(sortedCopy);
            string prev = sortedCopy[0];
            for (int i = 1; i < sortedCopy.Length; i++)
            {
                if (sortedCopy[i] == prev) { Console.WriteLine("Enter not the same numbers. For example: stone scissors paper"); return; }
                prev = sortedCopy[i];
            }
            string msg = "Available moves:\n";
            for (int i = 0; i < args.Length; i++)
            {
                msg = msg + (i + 1) + " - " + args[i] + "\n";
            }
            msg += "0 - exit\n? - help\nEnter your move:";
            string userMove;
            while (true)
            {
                Key key = new Key(args);

                Console.WriteLine("HMAC: " + key.GetStringHmac());
                while (true)
                {
                    Console.WriteLine(msg);
                    userMove = Console.ReadLine();
                    try
                    {
                        if (int.Parse(userMove) <= args.Length && int.Parse(userMove) > 0)
                        {
                            break;
                        }
                        if (int.Parse(userMove) == 0) { return; }
                    }
                    catch
                    {
                        if (userMove == "?")
                        {
                            HelpMenu helpMenu = new HelpMenu();
                            helpMenu.ShowTable(args);
                        }
                    }

                }
                try { Console.WriteLine("Your move: " + args[Int32.Parse(userMove) - 1]); }
                catch { }

                Console.WriteLine("PC move: " + args[key.pcMove - 1]);
                if (int.Parse(userMove) == key.pcMove) { Console.WriteLine("Draw"); }
                else if ((int.Parse(userMove) - (args.Length / 2)) > 0)
                {
                    if (key.pcMove < int.Parse(userMove) && key.pcMove >= (int.Parse(userMove) - (args.Length / 2))) { Console.WriteLine("You win!"); }
                    else { Console.WriteLine("PC win!"); }
                }
                else if ((int.Parse(userMove) + (args.Length / 2)) <= args.Length)
                {
                    if (key.pcMove > int.Parse(userMove) && key.pcMove <= (int.Parse(userMove) + (args.Length / 2))) { Console.WriteLine("PC win!"); }
                    else { Console.WriteLine("You win!"); }
                }
                Console.WriteLine("HMAC key: " + key.GetStringKey());
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

}
