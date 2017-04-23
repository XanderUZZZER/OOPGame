using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class PlayingArea : IGameObject
    {
        public static int TotalWidth { get; private set; }
        public static int TotalHeight { get; private set; }
        public static int PlayingWidth { get; private set; }
        public static int PlayingHeight { get; private set; }

        public static int X { get; private set; }
        public static int Y { get; private set; }

        public int BorderThickness { get; private set; } = 4;
        public Color BorderColor { get; private set; } = Color.Black;
        public Color BackgroundColor { get; private set; } = Color.BackgroundColor;
        public Color CellsColor { get; private set; } = Color.ForegroundColor;
        public Color FoodColor { get; private set; } = Color.Red;
        public Color SnakColor { get; private set; } = Color.Black;

        public Segment segment;
        public Snake snake;
        public Food food;

        public static int Score = 0;
        public static int LastScore = 0;
        public static int HiScore = 0;

        public PlayingArea()
        {      
            PlayingWidth = Segment.CellSize * 10;
            PlayingHeight = Segment.CellSize * 20;
            TotalWidth = PlayingWidth + BorderThickness*2;
            TotalHeight = PlayingHeight + BorderThickness*2;
            X = (TotalWidth - PlayingWidth) / 2;
            Y = (TotalHeight - PlayingHeight) / 2;
            StartNewGame();
        }

        public void StartNewGame()
        {
            segment = new Segment(X, Y, CellsColor);
            snake = new Snake();
            food = new Food();
        }

        void DrawPlayingArea(ConsoleGraphics graphics)
        {
            graphics.FillRectangle((uint)BorderColor, 0, 0, TotalWidth, TotalHeight);          //Draw border
            graphics.FillRectangle((uint)BackgroundColor, X, Y , PlayingWidth, PlayingHeight); //Draw background
            for ( int y = Y; y < PlayingHeight; y += Segment.CellSize)
            {
                for (int x = X; x < PlayingWidth; x += Segment.CellSize)
                {
                    segment.Render(x, y, CellsColor,graphics);                                  //Draw background cells
                }
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            DrawPlayingArea(graphics);
            snake.Render(graphics);
            food.Render(graphics);
        }

        public void Update(GameEngine engine)
        {
            snake.Update(engine);
            snake.Eat(food);
            Score = snake.SegmentsEated * 10;
            if (Score > HiScore)
            {
                HiScore = Score;
            }
            if (snake.HitItself())
            {
                LastScore = Score;
                StartNewGame();
            }
        }
    }
}
