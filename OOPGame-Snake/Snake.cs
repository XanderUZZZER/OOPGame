using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Snake : IGameObject
    {
        public ConsoleGraphics graphics { get; private set; }

        public List<Segment> body = new List<Segment>(3);
        int X = PlayingArea.PlayingWidth / 2 + 4;                           //Snake tail start position
        int Y = PlayingArea.PlayingHeight / 2 + 4 + Segment.CellSize * 2;   //
        Color SnakeColor = Color.Black;

        public Direction Direction = Direction.Up;
        public Direction ProhibitedDirection = Direction.Down;

        public Snake(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
            body.Add(new Segment(X, Y, graphics, SnakeColor));
            body.Add(new Segment(X, Y - Segment.CellSize, graphics, SnakeColor));
            body.Add(new Segment(X, Y - Segment.CellSize * 2, graphics, SnakeColor));
        }

        void DarwSnake()
        {
            foreach (var segment in body)
            {
                segment.DrawSegment(segment.X, segment.Y, SnakeColor);
            }
        }

        void MoveSnake()
        {

            if (Input.IsKeyDown(Keys.UP))//AllowedDirection == Direction.Up)
            {
                var tail = body.First();
                var head = body.Last();
                body.Remove(tail);                
                head.Y -= Segment.CellSize;
                body.Add(head);
            }
            else if (Input.IsKeyDown(Keys.RIGHT))//AllowedDirection == Direction.Right)
            {
                var tail = body.First();
                var head = body.Last();
                body.Remove(tail);                
                head.X += Segment.CellSize;
                body.Add(head);
            }
            else if (Input.IsKeyDown(Keys.DOWN))//AllowedDirection == Direction.Down)
            {
                var tail = body.First();
                var head = body.Last();
                body.Remove(tail);                
                head.Y += Segment.CellSize;
                body.Add(head);
            }
            else if (Input.IsKeyDown(Keys.LEFT))//AllowedDirection == Direction.Left)
            {
                var tail = body.First();
                var head = body.Last();
                body.Remove(tail);                
                head.X -= Segment.CellSize;
                body.Add(head);
            }
        }

        public void Render(ConsoleGraphics graphics)
        {
            DarwSnake();
        }

        public void Update(GameEngine engine)
        {
            MoveSnake();
            if (Input.IsKeyDown(Keys.UP) && (ProhibitedDirection != Direction.Up))
            {
                Direction = Direction.Up;
                ProhibitedDirection = Direction.Down;
            }
            else if (Input.IsKeyDown(Keys.RIGHT) && (ProhibitedDirection != Direction.Right))
            {
                Direction = Direction.Right;
                ProhibitedDirection = Direction.Left;
            }
            else if (Input.IsKeyDown(Keys.DOWN) && (ProhibitedDirection != Direction.Down))
            {
                Direction = Direction.Down;
                ProhibitedDirection = Direction.Up;
            }
            else if (Input.IsKeyDown(Keys.LEFT) && (ProhibitedDirection != Direction.Left))
            {
                Direction = Direction.Left;
                ProhibitedDirection = Direction.Right;
            }
        }
    }
}
