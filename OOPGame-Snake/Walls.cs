using System;
using NConsoleGraphics;

namespace OOPGame_Snake
{
    class Walls : IGameObject
    {
        private ConsoleGraphics graphics;
        
        private Color color = Color.Red;
        private float thickness = 30;

        public Walls(ConsoleGraphics graphics)
        {
            this.graphics = graphics;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.DrawLine((uint)color, 0, 0, graphics.ClientWidth, 0, thickness);
            graphics.DrawLine((uint)color, graphics.ClientWidth, 0, graphics.ClientWidth, graphics.ClientHeight, thickness);
            graphics.DrawLine((uint)color, graphics.ClientWidth, graphics.ClientHeight, 0, graphics.ClientHeight, thickness);
            graphics.DrawLine((uint)color, 0, graphics.ClientHeight, 0, 0, thickness);
        }

        public void Update(GameEngine engine)
        {
        }
    }
}
