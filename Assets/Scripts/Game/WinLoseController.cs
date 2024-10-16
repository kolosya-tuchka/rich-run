using System;
using Configs;
using Core.Services.SaveDataHandler;
using Data;
using Game.Levels;
using Game.Player;
using UnityEngine;
using VContainer;

namespace Game
{
    public class WinLoseController : ISaveWriter, ISaveReader
    {
        public event Action OnPlayerWin, OnPlayerLose; 
        
        private readonly MainGameField _mainGameField;
        private readonly PointsController _pointsController;

        private int _currentLevel;

        [Inject]
        public WinLoseController(MainGameField mainGameField, PointsController pointsController,
            ISaveDataHandler saveDataHandler)
        {
            _mainGameField = mainGameField;
            _pointsController = pointsController;
            
            saveDataHandler.RegisterSaveReader(this);
            saveDataHandler.RegisterSaveWriter(this);
        }

        public void Init()
        {
            _mainGameField.OnPlayerFinished += OnPlayerFinished;
            _pointsController.OnLevelChange += OnLevelChange;
        }

        private void OnPlayerFinished()
        {
            Debug.Log("Finish!");
            ++_currentLevel;
            OnPlayerWin?.Invoke();
        }

        private void OnLevelChange(PointsLevelConfig pointsLevelConfig)
        {
            if (_pointsController.CurrentLevelIndex == 0)
            {
                Debug.Log("Lose!");
                OnPlayerLose?.Invoke();
            }
        }

        public void WriteSave(SaveData saveData)
        {
            saveData.LevelSaveData.CurrentLevel = _currentLevel;
        }

        public void ReadSave(SaveData saveData)
        {
            _currentLevel = saveData.LevelSaveData.CurrentLevel;
        }
    }
}
