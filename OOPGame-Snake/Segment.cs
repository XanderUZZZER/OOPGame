using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Segment
    {
        private ConsoleGraphics graphics;

        public int X { get; set; }
        public int Y { get; set; }
        public int Size { get; private set; }
        private Color innerColor = Color.Red;
        private Color borderColor = Color.DarkRed;
        private int borderThickness = 4;

        public Segment()
        {
            this.X = 2;
            this.Y = 2;
            Size = 20;
        }

        public Segment(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Size = 20;
        }

        public void DrawSegment(ConsoleGraphics graphics)
        {
            graphics.FillRectangle((uint)innerColor, X, Y, Size, Size);
            graphics.DrawRectangle((uint)borderColor, X, Y, Size, Size, borderThickness);
            
        }
    }
}
