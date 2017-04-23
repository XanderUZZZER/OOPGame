using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class StatArea : IGameObject
    {
        public int TotalWidth { get; private set; }
        public int TotalHeight { get; private set; }
        public static int StatWidth { get; private set; }
        public static int StatHeight { get; private set; }

        public static int X { get; private set; }
        public static int Y { get; private set; }

        public int BorderThickness { get; private set; } = 4;
        public Color BorderColor { get; private set; } = Color.Black;
        public Color BackgroundColor { get; private set; } = Color.BackgroundColor;
        //public Color CellsColor { get; private set; } = Color.ForegoundColor;
        //public Color FoodColor { get; private set; } = Color.Red;
        //public Color SnakColor { get; private set; } = Color.Black;

        //public Segment segment;
        //public Snake snake;
        //public Food food;
        

        public StatArea(ConsoleGraphics graphics)
        {
            StatWidth = graphics.ClientWidth - PlayingArea.TotalWidth;
            StatHeight = PlayingArea.TotalHeight;
            TotalWidth = StatWidth + BorderThickness * 2;
            TotalHeight = StatHeight + BorderThickness * 2-8;
            X = PlayingArea.TotalWidth;
            Y = 0;
        }



        void DrawStatArea(ConsoleGraphics graphics)
        {
            graphics.FillRectangle((uint)BorderColor, X, Y, TotalWidth, TotalHeight);          //Draw border
            graphics.FillRectangle((uint)Color.White, X +4 , Y+4, StatWidth, StatHeight);       //Draw background
            graphics.DrawString("Score:", "", (uint)Color.Black, X + 5, Y + 10);
            graphics.DrawString($"{PlayingArea.Score}", "DS-Digital", (uint)Color.Black, X + 3, Y + 30, 30);
            graphics.DrawString("Last score:", "", (uint)Color.Black, X + 5, Y + 90);
            graphics.DrawString($"{PlayingArea.LastScore}", "DS-Digital", (uint)Color.Black, X + 3, Y + 110, 30);
            graphics.DrawString("HiScore:", "", (uint)Color.Red, X + 5, Y + 170);
            graphics.DrawString($"{PlayingArea.HiScore}", "DS-Digital", (uint)Color.Red, X + 3, Y + 190, 30);
        }

        public void Render(ConsoleGraphics graphics)
        {
            DrawStatArea(graphics);
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
