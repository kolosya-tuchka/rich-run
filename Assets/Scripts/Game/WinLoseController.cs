using System;
using Configs;
using Game.Levels;
using Game.Player;
using UnityEngine;
using VContainer;

namespace Game
{
    public class WinLoseController
    {
        public event Action OnPlayerWin, OnPlayerLose; 
        
        private readonly MainGameField _mainGameField;
        private readonly PointsController _pointsController;

        [Inject]
        public WinLoseController(MainGameField mainGameField, PointsController pointsController)
        {
            _mainGameField = mainGameField;
            _pointsController = pointsController;
        }

        public void Init()
        {
            _mainGameField.OnPlayerFinished += OnPlayerFinished;
            _pointsController.OnLevelChange += OnLevelChange;
        }

        private void OnPlayerFinished()
        {
            Debug.Log("Finish!");
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
    }
}
