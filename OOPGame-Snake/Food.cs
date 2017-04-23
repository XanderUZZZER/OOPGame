using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Food : Segment
    {
        Random random = new Random();

        public Food()
        {
            AddNext();
            SegmentColor = Color.Red;
        }

        public Food(int x, int y, Color color) : base(x, y, color)
        {
        }

        public void AddNext()
        {
            X = random.Next(PlayingArea.X, PlayingArea.PlayingWidth / Segment.CellSize) * Segment.CellSize + 4;
            Y = random.Next(PlayingArea.Y, PlayingArea.PlayingHeight / Segment.CellSize) * Segment.CellSize + 4;
        }
    }
}
