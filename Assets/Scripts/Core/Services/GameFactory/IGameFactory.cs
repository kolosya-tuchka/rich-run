using Game;

namespace Core.Services.GameFactory
{
    public interface IGameFactory
    {
        MainGameField CreateMainGameField();
        Level CreateLevel(int levelIndex);
    }
}