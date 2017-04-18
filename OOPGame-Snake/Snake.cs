using System;
using System.Collections.Generic;
using System.Globalization;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Snake : IGameObject
    {
        private ConsoleGraphics graphics;
        private List<Segment> snake = new List<Segment>(3);
        private int speed = 3;

        public Snake(ConsoleGraphics graphics)
        {
            Segment head = new Segment(graphics.ClientWidth / 2 - 10, graphics.ClientHeight / 2 - 10);
            snake.Add(head);
            snake.Add(new Segment(head.X, head.Y + 26));
            snake.Add(new Segment(head.X, head.Y + 52));
            this.graphics = graphics;
        }

        public void Move()
        {
            foreach (var segment in snake)
            {
                if (Input.IsKeyDown(Keys.UP))
                    segment.Y -= speed ;
                else if (Input.IsKeyDown(Keys.DOWN))
                    segment.Y += speed;
                else if (Input.IsKeyDown(Keys.RIGHT))
                    segment.X += speed;
                else if (Input.IsKeyDown(Keys.LEFT))
                    segment.X -= speed;
            }
        }

        public void DrawSnake(ConsoleGraphics graphics)
        {
            foreach (var segment in snake)
            {
                segment.DrawSegment(graphics);
            }
        }



        public void Render(ConsoleGraphics graphics)
        {
            DrawSnake(graphics);
        }

        public void Update(GameEngine engine)
        {
            Move();
        }
    }
}
