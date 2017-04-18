using NConsoleGraphics;

namespace OOPGame_Snake
{
    public class GameEngineSnake : GameEngine
    {
        public GameEngineSnake(ConsoleGraphics graphics) 
                        : base(graphics)
        {
            AddObject(new Walls());
            AddObject(new Snake(graphics));
            AddObject(new Food());
        }
    }
}
