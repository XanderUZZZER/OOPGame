using NConsoleGraphics;

namespace OOPGame_Snake
{
    public interface IGameObject
    {
        void Render(ConsoleGraphics graphics);

        void Update(GameEngine engine);
    }
}
