using NConsoleGraphics;
using System;

namespace OOPGame_Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 60;     //Window width in columns
            Console.WindowHeight = 40;    //Window height in rows
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Title = "Snake The Game";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            GameEngine engine = new GameEngineSnake(graphics);
            engine.Start();
        }
    }
}
