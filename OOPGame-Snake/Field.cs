using System;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class PlayingField : IGameObject
    {
        public const int CellSize = 32;//0x

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int PlayingWidth { get; private set; }
        public int PlayingHeight { get; private set; }
        public int Cols { get; private set; }
        public int Rows { get; private set; }
        
        public PlayingField(ConsoleGraphics graphics)
        {
            Width = graphics.ClientWidth;
            Height = graphics.ClientHeight;
        }

        public void Render(ConsoleGraphics graphics)
        {
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
