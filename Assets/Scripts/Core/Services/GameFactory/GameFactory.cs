using Configs;
using Game;
using Game.Camera;
using Game.Levels;
using Game.Player;
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

        public PlayerController CreatePlayer()
        {
            return Instantiate(AssetsPath.Player).GetComponentInChildren<PlayerController>();
        }

        public CameraFollow CreateCamera()
        {
            return Instantiate(AssetsPath.Camera).GetComponent<CameraFollow>();
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