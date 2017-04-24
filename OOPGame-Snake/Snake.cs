using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Snake : IGameObject
    {
        public List<Segment> body = new List<Segment>(3);
        int X = PlayingArea.PlayingWidth / 2 + 4;                           //Snake tail start position
        int Y = PlayingArea.PlayingHeight / 2 + 4 ;
        Color SnakeColor = Color.Black;
        public int SegmentsEated = 0;

        public Direction Direction = Direction.Up;
        public Direction ProhibitedDirection = Direction.Down;

        private bool canMove = false;

        public Snake()
        {
            AddSegemnt(X, Y);
            AddSegemnt(X, Y + Segment.CellSize);
            AddSegemnt(X, Y + Segment.CellSize * 2);
        }

        void AddSegemnt(int x, int y)
        {
            body.Add(new Segment(x, y, SnakeColor));
        }

        void DarwSnake(ConsoleGraphics graphics)
        {
            foreach (var segment in body)
            {
                segment.Render(graphics);
            }
        }

        void Move()
        {
            switch (Direction)
            {
                case Direction.Up:
                    {
                        if (body.First().Y != PlayingArea.Y)//if (body.First().Y - 4 != 0)
                        {
                            body.Insert(0, new Segment(body.First().X, body.First().Y - Segment.CellSize, SnakeColor));
                        }
                        else
                        {
                            body.Insert(0, new Segment(body.First().X, PlayingArea.PlayingHeight - Segment.CellSize + 4, SnakeColor));
                        }
                        body.Remove(body.Last());
                        break;
                    }
                case Direction.Right:
                    {
                        if (body.First().X - 4 + Segment.CellSize != PlayingArea.PlayingWidth)
                        {
                            body.Insert(0, new Segment(body.First().X + Segment.CellSize, body.First().Y, SnakeColor));
                        }
                        else
                        {
                            body.Insert(0, new Segment(4, body.First().Y, SnakeColor));
                        }
                        body.Remove(body.Last());
                        break;
                    }
                case Direction.Down:
                    {
                        if (body.First().Y - 4 + Segment.CellSize != PlayingArea.PlayingHeight)
                        {
                            ; body.Insert(0, new Segment(body.First().X, body.First().Y + Segment.CellSize, SnakeColor));
                        }
                        else
                        {
                            body.Insert(0, new Segment(body.First().X, 4, SnakeColor));
                        }
                        body.Remove(body.Last());
                        break;
                    }
                case Direction.Left:
                    {
                        if (body.First().X != PlayingArea.X)//if (body.First().X - 4 != 0)
                        {
                            body.Insert(0, new Segment(body.First().X - Segment.CellSize, body.First().Y, SnakeColor));
                        }
                        else
                        {
                            body.Insert(0, new Segment(PlayingArea.PlayingWidth - Segment.CellSize + 4, body.First().Y, SnakeColor));
                        }
                        body.Remove(body.Last());
                        break;
                    }
            }
        }

        public void Eat(Food food)
        {
            if (body.First().X == food.X && body.First().Y == food.Y)
            {
                body.Insert(0, new Segment(food.X, food.Y, SnakeColor));
                bool addNext = true;
                do
                {
                    addNext = false;
                    foreach (var segment in body)
                    {
                        if (food.X == segment.X && food.Y == segment.Y)
                        {
                            food.AddNext();
                            addNext = true;
                            break;
                        }
                    }
                } while (addNext);
                SegmentsEated++;                                    
            }
        }

        public bool HitItself()
        {
            var Head = body[0];
            bool IsHit = false;
            for (int i = 3; i < body.Count(); i++)
            {
                if (Head.X == body[i].X && Head.Y == body[i].Y)
                {
                    IsHit = true;
                    break;
                }
            }
            return IsHit;
        }

        public void Render(ConsoleGraphics graphics)
        {
            DarwSnake(graphics);
        }              

        public void Update(GameEngine engine)
        {
            if (canMove)
            {
                Move();
            }
            if (Input.IsKeyDown(Keys.UP) && (ProhibitedDirection != Direction.Up))
            {
                canMove = true;
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
            if (Input.IsKeyDown(Keys.ESCAPE))
            {
                canMove = false;
            }
        }
    }
}
