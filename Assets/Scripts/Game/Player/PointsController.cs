using System;
using System.Collections.Generic;
using Configs;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Game.Player
{
    public class PointsController : MonoBehaviour
    {
        private PointsConfig _pointsConfig;

        private int _points;
        public int Points
        {
            get => _points;
            private set
            {
                _points = value;
                OnPointsChange?.Invoke(_points);
            }
        }
        
        public int CurrentLevelIndex { get; private set; }
        public PointsLevelConfig CurrentLevel => _levels[CurrentLevelIndex];
        private List<PointsLevelConfig> _levels;

        public event Action<PointsLevelConfig> OnLevelChange;
        public event Action<int> OnPointsChange, OnPointsTake, OnPointsAdd;

        [Inject]
        public void Construct(GameConfigs gameConfigs)
        {
            _pointsConfig = gameConfigs.PointsConfig;
        }

        public void Init()
        {
            _levels = _pointsConfig.PointLevels;
            CurrentLevelIndex = _pointsConfig.InitialLevel;
            Points = _pointsConfig.InitialPoints;
        }

        public void Add(int points)
        {
            points = Mathf.Clamp(points, 0, points);
            Points += points;

            if (Points >= CurrentLevel.PointsToUpgrade && CurrentLevelIndex < _levels.Count - 1)
            {
                Points -= CurrentLevel.PointsToUpgrade;
                ++CurrentLevelIndex;
                OnLevelChange?.Invoke(CurrentLevel);
            }
            
            OnPointsChange?.Invoke(Points);
            OnPointsAdd?.Invoke(Points);
        }

        public void Take(int points)
        {
            points = Mathf.Clamp(points, 0, points);
            Points -= points;
            
            if (Points < 0 && CurrentLevelIndex > 0)
            {
                --CurrentLevelIndex;
                Points += CurrentLevel.PointsToUpgrade;
                OnLevelChange?.Invoke(CurrentLevel);
            }
            
            OnPointsChange?.Invoke(Points);
            OnPointsTake?.Invoke(Points);
        }
    }
}