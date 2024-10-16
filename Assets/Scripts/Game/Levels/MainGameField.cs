using System;
using Configs;
using Core.Services.GameFactory;
using Core.Services.SaveDataHandler;
using Data;
using UnityEngine;
using UnityEngine.Splines;
using VContainer;

namespace Game.Levels
{
    public class MainGameField : MonoBehaviour, ISaveReader
    {
        public event Action OnPlayerFinished; 
        
        private Level _level;
        private IGameFactory _gameFactory;
        private GameConfigs _gameConfigs;

        private LevelConfig _levelConfig;
        
        public Vector3 SpawnPoint => _level.SpawnPoint;
        public SplineContainer MoveSpline => _level.MoveSpline;
        
        [Inject]
        public void Construct(IGameFactory gameFactory, ISaveDataHandler saveDataHandler,
            GameConfigs gameConfigs)
        {
            saveDataHandler.RegisterSaveReader(this);
            _gameFactory = gameFactory;
            _gameConfigs = gameConfigs;
        }

        public void Init()
        {
            _level.Init(_levelConfig, PlayerFinish);
        }

        public void ReadSave(SaveData saveData)
        {
            var currentLevel = saveData.LevelSaveData.CurrentLevel;
            _level = _gameFactory.CreateLevel(currentLevel);
            _levelConfig = _gameConfigs.LevelsConfig.Levels[currentLevel];
        }

        private void PlayerFinish()
        {
            OnPlayerFinished?.Invoke();
        }
    }
}