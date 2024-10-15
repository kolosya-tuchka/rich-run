using Configs;
using Core.Services.PlatformInfo;
using Core.Services.SaveDataHandler;
using Game;
using UnityEngine;
using VContainer;

namespace Core.Services.GameFactory
{
    public sealed class GameFactory : IGameFactory
    {
        private readonly LevelsConfig _levelsConfig;
        
        private MainGameField _mainGameField;

        [Inject]
        public GameFactory(GameConfigs gameConfigs)
        {
            _levelsConfig = gameConfigs.LevelsConfig;
        }

        public MainGameField CreateMainGameField()
        {
            if ( _mainGameField )
            {
                return _mainGameField;
            }

            _mainGameField = Instantiate(AssetsPath.MainGameField).GetComponent<MainGameField>();
            return _mainGameField;
        }

        public Level CreateLevel(int levelIndex)
        {
            var levelPath = AssetsPath.LevelsFolder + _levelsConfig.LevelNames[levelIndex];
            return Instantiate(levelPath, _mainGameField.transform).GetComponent<Level>();
        }

        private GameObject Instantiate(string address, Transform parent)
        {
            var gameObject = Resources.Load<GameObject>(address);
            return Object.Instantiate(gameObject, parent);
        }

        private GameObject Instantiate(string address)
        {
            var gameObject = Resources.Load<GameObject>(address);
            return Object.Instantiate(gameObject);
        }
    }
}