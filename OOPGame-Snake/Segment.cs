using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Segment
    {
        public const int CellSize = 34;

        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public Color SegmentColor { get; set; }

        public Segment()
        {
            
        }
        
        public Segment(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Segment(int x, int y, Color color)
        {
            X = x;
            Y = y;
            SegmentColor = color;
        }

        private void DrawSegment(ConsoleGraphics graphics)
        {
            graphics.DrawRectangle((uint)SegmentColor, X + 4, Y + 4, 26, 26, 4);
            graphics.FillRectangle((uint)SegmentColor, X + 10, Y + 10, 14, 14);
        }

        private void DrawSegment(int x, int y, ConsoleGraphics graphics)
        {
            graphics.DrawRectangle((uint)SegmentColor, x + 4, y + 4, 26, 26, 4);
            graphics.FillRectangle((uint)SegmentColor, x + 10, y + 10, 14, 14);
        }

        private void DrawSegment(int x, int y, Color color, ConsoleGraphics graphics)
        {            
            graphics.DrawRectangle((uint)color, x + 4, y + 4, 26, 26, 4);
            graphics.FillRectangle((uint)color, x + 10, y + 10, 14, 14);
        }

        public void DrawSegmentInfo(string str, int x, int y, Color color, ConsoleGraphics graphics)
        {
            graphics.DrawString(str,"Consolas", (uint)color, x, y,18);
        }

        public void Render(ConsoleGraphics graphics)
        {
            DrawSegment(graphics);
        }

        public void Render(int x, int y,ConsoleGraphics graphics)
        {
            DrawSegment(x, y, graphics);
        }

        public void Render(int x, int y, Color color, ConsoleGraphics graphics)
        {
            DrawSegment(x, y, color, graphics);
        }
    }
}
