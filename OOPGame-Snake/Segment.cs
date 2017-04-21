using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Segment : IGameObject
    {
        public const int CellSize = 34;

        public ConsoleGraphics graphics { get; private set; }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public Color ForegroundColor{ get; private set; } = Color.ForegoundColor;

        public Segment(int x, int y, ConsoleGraphics graphics, Color color = Color.ForegoundColor)
        {
            this.graphics = graphics;
            X = x;
            Y = y;
            ForegroundColor = color;
        }

        public void DrawSegment()
        {            
            graphics.DrawRectangle((uint)ForegroundColor, X + 4, Y + 4, 26, 26, 4);
            graphics.FillRectangle((uint)ForegroundColor, X + 10, Y + 10, 14, 14);

        }

        public void DrawSegment(int x, int y, Color color = Color.ForegoundColor)
        {            
            graphics.DrawRectangle((uint)color, x + 4, y + 4, 26, 26, 4);
            graphics.FillRectangle((uint)color, x + 10, y + 10, 14, 14);

        }

        public void Render(ConsoleGraphics graphics)
        {
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
