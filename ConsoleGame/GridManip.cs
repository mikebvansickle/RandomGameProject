using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleGame
{
    class GridManip
    {
        public struct Coords
        {
            public int x, y;

            public Coords(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        public static void PrintGrid(int[][] grid)
        {
            for (int i = 0; i < grid.Length; ++i)
            {
                for (int j = 0; j < grid[i].Length; ++j)
                {
                    Console.SetCursorPosition((i + 1) * 2, j + 1);
                    if (grid[i][j] == 0)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write("+");
                    }
                }
            }
        }
        public static int GetCurrentValue(Track.Point Player, int[][] grid)
        {
            return grid[Player.xTrack / 2 - 1][Player.yTrack - 1];
        }
        public static int GetValue(int x, int y, int[][] grid)
        {
            return grid[x][y];
        }
        public static bool SameValue(int x, int y, int[][] grid, int currentVal)
        {
            if(grid[x][y] == currentVal)
            {
                return true;
            }
            return false;
        }
        public static bool GridPositionExists(int[][]grid, int x, int y) //Checks if passed point is within the indices of the array
        {   
             if(x < grid.Length && x > -1)
             {
                if(y < grid[x].Length && y > -1)
                {
                    return true;
                }
             }
            return false;
        }
        public static bool AlreadyRecorded(Coords set, List<Coords> trackedCoords)
        {
            if (trackedCoords.Contains(set))
            {
                return true;
            }
            return false;
        }
        public static List<Coords> GetConnectedNodes(int[][] grid, Track.Point Player)
        {
            int xCurrent = Player.xTrack / 2 - 1;
            int yCurrent = Player.yTrack - 1;
            int top = yCurrent - 1;
            int bottom = yCurrent + 1;
            int right = xCurrent + 1;
            int left = xCurrent - 1;
            int currentVal = GetCurrentValue(Player, grid);
            bool newCoord = false;
            List<Coords> trackedCoords = new List<Coords>();
            Coords current = new Coords(xCurrent, yCurrent);
            trackedCoords.Add(current);
            List<Coords> coordsToProcess = new List<Coords>();
            //TOP POINT
            if (GridPositionExists(grid, xCurrent, top))
            { 
                if (SameValue(xCurrent, top, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(xCurrent, top);
                    if(!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            //BOTTOM POINT
            if(GridPositionExists(grid, xCurrent, bottom))
            {
                if(SameValue(xCurrent, bottom, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(xCurrent, bottom);
                    if (!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            //LEFT POINT
            if(GridPositionExists(grid, left, yCurrent))
            {
                if(SameValue(left, yCurrent, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(left, yCurrent);
                    if (!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            //RIGHT POINT
            if(GridPositionExists(grid, right, yCurrent))
            {
                if(SameValue(right, yCurrent, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(right, yCurrent);
                    if (!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            List<Coords> coordsProcessed = new List<Coords>();
            coordsProcessed.Add(current);
            foreach(Coords set in coordsToProcess)
            {
                if (coordsProcessed.Contains(set))
                {
                    continue;
                }
                else
                {
                    coordsProcessed.Add(set);
                    RecursiveCoordCollection(grid, set, trackedCoords, coordsProcessed);
                }
            }
            return trackedCoords;

        }
        public static List<Coords> RecursiveCoordCollection(int[][] grid, Coords currentPos, List<Coords> trackedCoords, List<Coords> coordsProcessed)
        {
            int top = currentPos.y - 1;
            int bottom = currentPos.y + 1;
            int right = currentPos.x + 1;
            int left = currentPos.x - 1;
            int currentVal = grid[currentPos.x][currentPos.y];
            bool newCoord = false;
            Coords current = new Coords(currentPos.x, currentPos.y);
            List<Coords> coordsToProcess = new List<Coords>();
            //TOP POINT
            if (GridPositionExists(grid, currentPos.x, top))
            {
                if (SameValue(currentPos.x, top, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(currentPos.x, top);
                    if (!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            //BOTTOM POINT
            if (GridPositionExists(grid, currentPos.x, bottom))
            {
                if (SameValue(currentPos.x, bottom, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(currentPos.x, bottom);
                    if (!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            //LEFT POINT
            if (GridPositionExists(grid, left, currentPos.y))
            {
                if (SameValue(left, currentPos.y, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(left, currentPos.y);
                    if (!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            //RIGHT POINT
            if (GridPositionExists(grid, right, currentPos.y))
            {
                if (SameValue(right, currentPos.y, grid, currentVal))
                {
                    Coords evaluateCoord = new Coords(right, currentPos.y);
                    if (!AlreadyRecorded(evaluateCoord, trackedCoords))
                    {
                        coordsToProcess.Add(evaluateCoord);
                        trackedCoords.Add(evaluateCoord);
                        newCoord = true;
                    }
                }
            }
            foreach(Coords set in coordsToProcess)
            {
                if (coordsProcessed.Contains(set))
                {
                    continue;
                }
                else
                {
                    coordsProcessed.Add(set);
                    RecursiveCoordCollection(grid, set, trackedCoords, coordsProcessed);
                }
            }
            return trackedCoords;
        }
        public static double GetDistance(int xPlayer, int yPlayer, int xCoord, int yCoord)
        {
            return Math.Sqrt(Math.Pow(xPlayer - xCoord, 2) + Math.Pow(yPlayer - yCoord, 2));
        }
        public static void UpdateGridValues(int[][] grid, List<Coords> trackedCoords, Track.Point Player)
        {
            int xPlayer = Player.xTrack / 2 - 1;
            int yPlayer = Player.yTrack - 1;
            string newVal;
            int newGridVal;
            if(grid[trackedCoords[0].x][trackedCoords[0].y] == 0)
            {
                newGridVal = 1;
                newVal = "+";
            }
            else
            {
                newGridVal = 0;
                newVal = "O";
            }
            //Prints in random sequence
            //Random rnd = new Random();
            //while(trackedCoords.Count > 0)
            //{
            //    int x = rnd.Next(0, trackedCoords.Count);
            //    grid[trackedCoords[x].x][trackedCoords[x].y] = newGridVal;
            //    Console.SetCursorPosition((trackedCoords[x].x + 1) * 2, trackedCoords[x].y + 1);
            //    Console.SetWindowPosition(0, 0);
            //    Console.Write(newVal);
            //    trackedCoords.RemoveAt(x);
            //    Thread.Sleep(15);
            //
            //}


            //Prints procedurally in the order the nodes were collected
            //foreach(Coords set in trackedCoords)
            //{
            //    grid[set.x][set.y] = newGridVal;
            //    Console.SetCursorPosition((set.x + 1) * 2, set.y + 1);
            //    Console.SetWindowPosition(0, 0);
            //    Console.Write(newVal);
            //    Thread.Sleep(15);
            //}

            //Prints radially based on closest point to Player Coords
            //Simple Insertion sort method -> O(n^2)
            for (int i = 0; i < trackedCoords.Count - 1; ++i)
            {
                for(int j = i + 1; j > 0; --j)
                {
                    double distA = GetDistance(xPlayer, yPlayer, trackedCoords[j].x, trackedCoords[j].y);
                    double distB = GetDistance(xPlayer, yPlayer, trackedCoords[j - 1].x, trackedCoords[j - 1].y);
                    if(distB > distA)
                    {
                        Coords temp = new Coords(trackedCoords[j - 1].x, trackedCoords[j - 1].y);
                        trackedCoords[j - 1] = trackedCoords[j];
                        trackedCoords[j] = temp;
                    }
                }
            }
            for (int i = 0; i < trackedCoords.Count; ++i)
            {
                grid[trackedCoords[i].x][trackedCoords[i].y] = newGridVal;
                Console.SetCursorPosition((trackedCoords[i].x + 1) * 2, trackedCoords[i].y + 1);
                Console.SetWindowPosition(0, 0);
                Console.Write(newVal);
                Thread.Sleep(2);
            }

            //Poorly optimized radial version
            //List<Coords> orderedList = new List<Coords>();
            //double distanceMin = 99999;
            //int distanceMinIndex = 0;
            //while(trackedCoords.Count > 0)
            //{
            //    distanceMin = 99999;
            //    for (int i = 0; i < trackedCoords.Count; ++i)
            //    {
            //        double x = trackedCoords[i].x - xPlayer;
            //        double y = trackedCoords[i].y - yPlayer;
            //        x = Math.Pow(x, 2);
            //        y = Math.Pow(y, 2);
            //        double numToSquare = x + y;
            //        double dist = Math.Sqrt(numToSquare);
            //         if(dist < distanceMin)
            //        {
            //            distanceMin = dist;
            //            distanceMinIndex = i;
            //        }
            //    }
            //    orderedList.Add(trackedCoords[distanceMinIndex]);
            //    trackedCoords.RemoveAt(distanceMinIndex);
            //}
            //for(int i = 0; i < orderedList.Count; ++i)
            //{
            //    grid[orderedList[i].x][orderedList[i].y] = newGridVal;
            //    Console.SetCursorPosition((orderedList[i].x + 1) * 2, orderedList[i].y + 1);
            //    Console.SetWindowPosition(0, 0);
            //    Console.Write(newVal);
            //    Thread.Sleep(2);
            //}

        }
    }
}
