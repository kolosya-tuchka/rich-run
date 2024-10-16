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
        [SerializeField] private GameObject menuUI, commonUI, loseWindow, winWindow;
        [SerializeField] private GameplayUI gameplayUI;

        private PointsController _pointsController;
        private LevelsConfig _levelsConfig;
        private LevelConfig _levelConfig;
        
        [Inject]
        public void Construct(PointsController pointsController, ISaveDataHandler saveDataHandler,
            GameConfigs gameConfigs)
        {
            _pointsController = pointsController;
            _levelsConfig = gameConfigs.LevelsConfig;
            saveDataHandler.RegisterSaveReader(this);
        }
        
        public void Init()
        {
            menuUI.SetActive(true);
            gameplayUI.gameObject.SetActive(false);
            commonUI.SetActive(true);
            loseWindow.SetActive(false);
            winWindow.SetActive(false);
            
            gameplayUI.Init(_pointsController, _levelConfig.Title);
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
    }
}
