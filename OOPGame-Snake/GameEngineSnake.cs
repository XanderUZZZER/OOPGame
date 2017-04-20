using NConsoleGraphics;

namespace OOPGame_Snake
{
    public class GameEngineSnake : GameEngine
    {
        public GameEngineSnake(ConsoleGraphics graphics) 
                        : base(graphics)
        {
            AddObject(new PlayingField(graphics));
        }
    }
}
