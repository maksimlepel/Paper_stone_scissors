using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTables;

namespace Paper_stone_scissors
{
    class HelpMenu
    {
        public void ShowTable(string[] args)
        {
            string[] firstPos = new string[] { "PC/User" };

            var firstRow = new string[firstPos.Length + args.Length];
            firstPos.CopyTo(firstRow, 0);
            args.CopyTo(firstRow, firstPos.Length);
            var table = new ConsoleTable(firstRow);

            string[] rules = new string[args.Length];

            for (int i = 0; i < rules.Length; i++)
            {
                if (i == 0) { rules[i] = "DRAW"; }
                else if (i > 0 && i <= rules.Length / 2) { rules[i] = "WIN"; }
                else { rules[i] = "LOSE"; }
            }
            string[] curStr = new string[args.Length];
            for (int c = 0; c < args.Length; c++)
            {
                for (int i = 0; i < rules.Length; i++)
                {
                    curStr[(i + c) % curStr.Length] = rules[i];
                }
                firstPos[0] = args[c];
                var row = new string[firstPos.Length + args.Length];
                firstPos.CopyTo(row, 0);
                curStr.CopyTo(row, firstPos.Length);
                table.AddRow(row);
            }
            table.Write(Format.Alternative);

        }
    }
}

