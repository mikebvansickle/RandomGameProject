using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Track
    {
        public class Point
        {
            public int xTrack;
            public int xTrackLine;
            public int yTrack;
            public int yTrackLine;
            public int xStart;
            public int xEnd;
            public int yStart;
            public int yEnd;
            public Point(int width, int height)
            {
                this.xStart = 2;
                this.xEnd = width - 2;
                this.yStart = 1;
                this.yEnd = height - 1;
                this.xTrack = xStart;
                this.xTrackLine = height + 1;
                this.yTrack = yStart;
                this.yTrackLine = width + 1;

            }
            public bool MoveTracker(string userInput)
            {
                if (userInput == "RightArrow")
                {
                    if (this.xTrack < this.xEnd)
                    {
                        this.xTrack += 2;
                        Console.SetCursorPosition(this.xTrack - 2, this.xTrackLine);
                        Console.Write(" ");
                        Console.SetCursorPosition(this.xTrack, this.xTrackLine);
                        Console.Write("^");
                        return true;
                    }
                }
                else if (userInput == "LeftArrow")
                {
                    if (this.xTrack > this.xStart)
                    {
                        this.xTrack -= 2;
                        Console.SetCursorPosition(this.xTrack + 2, this.xTrackLine);
                        Console.Write(" ");
                        Console.SetCursorPosition(this.xTrack, this.xTrackLine);
                        Console.Write("^");
                        return true;
                    }
                }
                else if (userInput == "UpArrow")
                {
                    if (this.yTrack > this.yStart)
                    {
                        this.yTrack -= 1;
                        Console.SetCursorPosition(this.yTrackLine, this.yTrack + 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(this.yTrackLine, this.yTrack);
                        Console.Write("<");
                        return true;
                    }
                }
                else if (userInput == "DownArrow")
                {
                    if (this.yTrack < this.yEnd)
                    {
                        this.yTrack += 1;
                        Console.SetCursorPosition(this.yTrackLine, this.yTrack - 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(this.yTrackLine, this.yTrack);
                        Console.Write("<");
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
