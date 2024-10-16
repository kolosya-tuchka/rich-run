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
        private Level _level;
        private IGameFactory _gameFactory;

        public Vector3 SpawnPoint => _level.SpawnPoint;
        public SplineContainer MoveSpline => _level.MoveSpline;
        
        [Inject]
        public void Construct(IGameFactory gameFactory, ISaveDataHandler saveDataHandler)
        {
            saveDataHandler.RegisterSaveReader(this);
            _gameFactory = gameFactory;
        }

        public void ReadSave(SaveData saveData)
        {
            _level = _gameFactory.CreateLevel(saveData.LevelSaveData.CurrentLevel);
        }
    }
}