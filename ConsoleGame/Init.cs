using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Init
    {
        public static void InitTimer()
        {
            System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
            clock.Start();
        }
        public static List<int> InitializeBoard()
        {
            List<int> config = new List<int>();
            Console.WriteLine("Please enter the desired width of the grid.");
            int a;
            bool validInput = false;
            while (validInput == false)
            {
                if (int.TryParse(Console.ReadLine(), out a))
                {
                    a += 1;
                    config.Add(a * 2);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer value");
                }
            }
            int x = (config[0] / 2) - 1;
            Console.WriteLine("You have designated the width of the grid to be: " + x);
            Console.WriteLine("Please enter the desired height of the grid.");
            int b;
            validInput = false;
            while (validInput == false)
            {
                if (int.TryParse(Console.ReadLine(), out b))
                {
                    b += 1;
                    config.Add(b);
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer value");
                }
            }
            int y = config[1] - 1;
            Console.WriteLine("You have designated the height of the grid to be: " + y);
            Console.Clear();
            Console.WriteLine("Grid Dimensions: " + x + "x" + y);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            Console.SetCursorPosition(config[0] + 4, 0);
            Console.Write("Your grid dimensions are: " + x + "x" + y);
            return config;
        }
        public static List<string> InitializeBorders(List<int> config)
        {
            List<string> borders = new List<string>();
            string topBottom = "";
            for (int i = 0; i <= config[0] / 2; ++i)
            {
                topBottom += "# ";
            }
            borders.Add(topBottom);
            string leftRight = "";
            for (int i = 0; i <= config[0]; ++i)
            {
                if (i == 0 || i == config[0])
                {
                    leftRight += "#";
                }
                else
                {
                    leftRight += " ";
                }
            }
            borders.Add(leftRight);
            return borders;
        }
        public static void DrawBorders(List<int> config, List<string> borders)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= config[1]; ++i)
            {
                if (i == 0 || i == config[1])
                {
                    Console.WriteLine(borders[0]);
                }
                else
                {
                    Console.WriteLine(borders[1]);
                }
            }
        }
        public static int[][] PopulateGrid(Track.Point Play)
        {
            Random rnd = new Random();
            int innerXDimension = Play.xEnd / 2;
            int innerYDimension = Play.yEnd;
            int[][] grid = new int[innerXDimension][];
            for (int i = 0; i < grid.Length; ++i)
            {
                grid[i] = new int[innerYDimension];
            }
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[i].Length; ++j)
                {
                    grid[i][j] = rnd.Next(0, 99) % 2;
                }
            }
            return grid;
        }
        public static void InitializePlayerCursor(List<int> config)
        {
            Console.SetCursorPosition(config[0] + 1, 1);
            Console.Write('<');
            Console.SetCursorPosition(2, config[1] + 1);
            Console.Write('^');
        }
        public static void PrintStatus(List<int> config, Track.Point Player, ConsoleKeyInfo userInput, int data)
        {
            Console.SetCursorPosition(0, config[1] + 2);
            Console.WriteLine("#######################################################################################");
            Console.SetCursorPosition(0, config[1] + 3);
            Console.WriteLine("###### USE ARROW KEYS TO MOVE INDICES, SPACE TO CHANGE TILE, ESCAPE OR Q TO QUIT ######");
            Console.SetCursorPosition(0, config[1] + 4);
            Console.WriteLine("#######################################################################################");
            Console.SetCursorPosition(0, config[1] + 6);
            Console.Write("Step Number: N/A");
        }
        public static void PrintDebug(Track.Point Player, List<int> config, int[][] grid)
        {
            //Tests Player.xEnd, Player.xStart, Player.yEnd, and Player.yStart values
            Console.SetCursorPosition(Player.xEnd, Player.yEnd);
            Console.Write("O");
            Console.SetCursorPosition(Player.xStart, Player.yStart);
            Console.Write("O");
            Console.SetCursorPosition(0, config[1] + 8);
            Console.WriteLine("Last input: N/A");
            Console.SetCursorPosition(0, config[1] + 10);
            Console.WriteLine("xStart: " + Player.xStart + " xEnd: " + Player.xEnd + "        ");
            Console.SetCursorPosition(0, config[1] + 12);
            Console.WriteLine("xTrack: " + Player.xTrack + " xTrackLine: " + Player.xTrackLine + "        ");
            Console.SetCursorPosition(0, config[1] + 14);
            Console.WriteLine("yStart: " + Player.yStart + " yEnd: " + Player.yEnd + "        ");
            Console.SetCursorPosition(0, config[1] + 16);
            Console.WriteLine("yTrack: " + Player.yTrack + " yTrackLine: " + Player.yTrackLine + "        ");
            //Prints Grid inner-dimensions
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("grid.Length: " + grid.Length + "\ngrid[0].Length: " + grid[0].Length);
        }
    }
}
