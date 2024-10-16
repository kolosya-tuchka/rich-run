using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;
using VContainer;

namespace Game.Player
{
    public class PointsController : MonoBehaviour
    {
        private PointsConfig _pointsConfig;

        private int _points;
        private int Points
        {
            get => _points;
            set
            {
                _points = value;
                OnPointsChange?.Invoke(_points);
            }
        }

        private List<PointsLevelConfig> _levels;
        private int _currentLevelIndex;
        private PointsLevelConfig CurrentLevel => _levels[_currentLevelIndex];

        public event Action<PointsLevelConfig> OnLevelChange;
        public event Action<int> OnPointsChange, OnPointsTake, OnPointsAdd;

        [Inject]
        public void Construct(GameConfigs gameConfigs)
        {
            _pointsConfig = gameConfigs.PointsConfig;
        }

        public void Init()
        {
            Points = _pointsConfig.InitialPoints;
            _levels = _pointsConfig.PointLevels;
            _currentLevelIndex = _pointsConfig.InitialLevel;
        }

        public void Add(int points)
        {
            points = Mathf.Clamp(points, 0, points);
            Points += points;

            if (Points >= CurrentLevel.PointsToUpgrade && _currentLevelIndex < _levels.Count - 1)
            {
                Points -= CurrentLevel.PointsToUpgrade;
                ++_currentLevelIndex;
                OnLevelChange?.Invoke(CurrentLevel);
            }
            
            OnPointsChange?.Invoke(Points);
            OnPointsAdd?.Invoke(Points);
        }

        public void Take(int points)
        {
            points = Mathf.Clamp(points, 0, points);
            Points -= points;
            
            if (Points < 0 && _currentLevelIndex > 0)
            {
                --_currentLevelIndex;
                Points += CurrentLevel.PointsToUpgrade;
                OnLevelChange?.Invoke(CurrentLevel);
            }
            
            OnPointsChange?.Invoke(Points);
            OnPointsTake?.Invoke(Points);
        }
    }
}