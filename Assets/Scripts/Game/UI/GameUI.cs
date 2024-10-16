using System;
using Configs;
using Core.Services.SaveDataHandler;
using Data;
using Game.Player;
using UnityEngine;
using VContainer;

namespace Game.UI
{
    public class GameUI : MonoBehaviour, ISaveReader
    {
        [SerializeField] private GameObject menuUI, commonUI;
        [SerializeField] private GameplayUI gameplayUI;
        [SerializeField] private LoseWindow loseWindow;
        [SerializeField] private WinWindow winWindow;

        private PointsController _pointsController;
        private LevelsConfig _levelsConfig;
        private LevelConfig _levelConfig;
        private WinLoseController _winLoseController;

        private Action _restartGame;
        
        [Inject]
        public void Construct(PointsController pointsController, ISaveDataHandler saveDataHandler,
            GameConfigs gameConfigs, WinLoseController winLoseController)
        {
            _pointsController = pointsController;
            _levelsConfig = gameConfigs.LevelsConfig;
            _winLoseController = winLoseController;
            saveDataHandler.RegisterSaveReader(this);
        }
        
        public void Init(Action restartGame)
        {
            menuUI.SetActive(true);
            gameplayUI.gameObject.SetActive(false);
            commonUI.SetActive(true);
            loseWindow.gameObject.SetActive(false);
            winWindow.gameObject.SetActive(false);
            
            winWindow.Init();
            loseWindow.Init();
            gameplayUI.Init(_pointsController, _levelConfig.Title);

            _winLoseController.OnPlayerLose += OnLose;
            _winLoseController.OnPlayerWin += OnWin;
            
            _restartGame = restartGame;
        }

        public void StartGameplay()
        {
            menuUI.SetActive(false);
            gameplayUI.gameObject.SetActive(true);   
        }

        public void ReadSave(SaveData saveData)
        {
            int currentLevel = saveData.LevelSaveData.CurrentLevel;
            _levelConfig = _levelsConfig.Levels[currentLevel];
        }

        private void OnLose()
        {
            gameplayUI.gameObject.SetActive(false);
            loseWindow.Open(_restartGame);
        }

        private void OnWin()
        {
            gameplayUI.gameObject.SetActive(false);
            winWindow.Open(_restartGame, _pointsController.TotalPoints);
        }
    }
}
