using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class PlayingArea : IGameObject
    {
        public ConsoleGraphics graphics { get; private set; }
        
        public int TotalWidth { get; private set; }
        public int TotalHeight { get; private set; }
        public static int PlayingWidth { get; private set; }
        public static int PlayingHeight { get; private set; }
        public static int X { get; private set; }
        public static int Y { get; private set; }
        public int BorderThickness { get; private set; } = 4;
        public uint BorderColor { get; private set; } = (uint)Color.Black;
        public uint BackgroundColor { get; private set; } = (uint)Color.BackgroundColor;
        public Segment segment;

        public PlayingArea(ConsoleGraphics graphics)
        {
            this.graphics = graphics;            
            PlayingWidth = Segment.CellSize * 10;
            PlayingHeight = Segment.CellSize * 20;
            TotalWidth = PlayingWidth + BorderThickness*2;
            TotalHeight = PlayingHeight + BorderThickness*2;
            X = (TotalWidth - PlayingWidth) / 2;
            Y = (TotalHeight - PlayingHeight) / 2;
            segment = new Segment(X, Y, graphics);
        }

        void DrawPlayingArea()
        {
            graphics.FillRectangle(BorderColor, 0, 0, TotalWidth, TotalHeight);          //Draw border
            graphics.FillRectangle(BackgroundColor, X, Y , PlayingWidth, PlayingHeight); //Draw background
            for ( int y = Y; y < PlayingHeight; y += Segment.CellSize)
            {
                for (int x = X; x < PlayingWidth; x += Segment.CellSize)
                {
                    segment.DrawSegment(x, y);                                          //Draw background cells
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            DrawPlayingArea();
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
