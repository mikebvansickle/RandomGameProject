using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {

        public static int initDebug = 0;
        public static int initInterface = 0;
        public static int consoleWidth = Console.LargestWindowWidth - 20;
        public static int consoleHeight = Console.LargestWindowHeight - 20;
        static void Main(string[] args)
        {
            //######################################### INITIALIZATION #########################################
            //INCREASE WINDOW SIZE AND TAKE IN USER INPUT ON GRID SPECIFICATIONS
            Console.SetWindowSize(consoleWidth, consoleHeight);
            List<int> config = Init.InitializeBoard();
            List<string> borders = Init.InitializeBorders(config);
            Init.DrawBorders(config, borders);
            Init.InitializePlayerCursor(config);
            //CREATE PLAYER TRACKING OBJECT
            Track.Point Player = new Track.Point(config[0], config[1]);
            //POPULATES GRID VALUES AND PRINTS
            int[][] grid = Init.PopulateGrid(Player);
            GridManip.PrintGrid(grid);
            //HIDES CURSOR FROM BLINKING
            Console.CursorVisible = false;
            //##################################################################################################

            //######################################### DEBUG & INTERFACE #########################################
            //SET UP INTERFACE
            if (initInterface == 1)
            {
                ConsoleKeyInfo placeholder = new ConsoleKeyInfo();
                Init.PrintStatus(config, Player, placeholder, 0);
            }
            //DEBUG INITIALIZING
            if (initDebug == 1)
            {
                Init.PrintDebug(Player, config, grid);
            }
            //#####################################################################################################
            //MAY IMPLEMENT STOPWATCH LATER; MIGHT REQUIRE MULTITHREADING IN ORDER TO COUNT TIME WHILE WAITING FOR USER INPUT
            //System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
            //clock.Start();
            //Program Run Loop, waits for user input, breaks on Escape or Q
            //#####################################################################################################

            //COUNTS INPUTS BY USER
            int data = 1;
            //##################################### MAIN GAME LOOP #####################################
            while (true)
            {
                Console.SetCursorPosition(Player.xTrack, Player.yTrack);
                Console.CursorVisible = true;
                var userInput = Console.ReadKey(true);
                Console.CursorVisible = false;
                //MOVE TRACKERS
                if (userInput.Key == ConsoleKey.RightArrow || userInput.Key == ConsoleKey.LeftArrow || userInput.Key == ConsoleKey.UpArrow || userInput.Key == ConsoleKey.DownArrow)
                {
                    bool moved = false;
                    moved = Player.MoveTracker(userInput.Key.ToString());
                    if (moved == true)
                    {
                        data++;
                    }
                }
                else if (userInput.Key == ConsoleKey.Spacebar)
                {
                    List<GridManip.Coords> coordsToChange = new List<GridManip.Coords>();
                    coordsToChange = GridManip.GetConnectedNodes(grid, Player);
                    GridManip.UpdateGridValues(grid, coordsToChange, Player);
                    data++;
                }
                else if (userInput.Key == ConsoleKey.Escape || userInput.Key == ConsoleKey.Q)
                {
                    break;
                }
                else if (userInput.Key == ConsoleKey.T) //TEST CASE
                {
                    Console.SetCursorPosition(0, 20);
                    List<GridManip.Coords> coordsToChange = new List<GridManip.Coords>();
                    coordsToChange = GridManip.GetConnectedNodes(grid, Player);
                    for(int i = 0; i < coordsToChange.Count; ++i)
                    {
                        Console.SetCursorPosition(0, i+20);
                        Console.WriteLine("Need to change: (" + coordsToChange[i].x + "," + coordsToChange[i].y + ")                       ");
                    }
                    GridManip.UpdateGridValues(grid, coordsToChange, Player);
                }
                if (initInterface == 1)
                {
                    Init.PrintStatus(config, Player, userInput, data);
                }
                //WAS PRINTING STOPWATCH STATUS
                //Console.SetCursorPosition(0, config[1] + 7);
                //Console.Write("Running Time: " + clock.Elapsed.TotalSeconds.ToString());
            }
            //##########################################################################################
        }
    }
}
