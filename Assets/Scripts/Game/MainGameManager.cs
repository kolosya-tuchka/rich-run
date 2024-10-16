using Core.Services.SaveDataHandler;
using Game.Camera;
using Game.Levels;
using Game.Player;
using Game.UI;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class MainGameManager : IInitializable
    {
        private readonly PlayerController _player;
        private readonly PointsController _pointsController;
        private readonly MainGameField _mainGameField;
        private readonly CameraFollow _cameraFollow;
        private readonly ISaveDataHandler _saveDataHandler;
        private readonly GameplayStarter _gameplayStarter;
        private readonly PlayerLevelView _playerLevelView;

        [Inject]
        public MainGameManager(PlayerController player, MainGameField mainGameField,
            CameraFollow cameraFollow, ISaveDataHandler saveDataHandler, GameplayStarter gameplayStarter, PointsController pointsController, PlayerLevelView playerLevelView)
        {
            _player = player;
            _mainGameField = mainGameField;
            _cameraFollow = cameraFollow;
            _saveDataHandler = saveDataHandler;
            _gameplayStarter = gameplayStarter;
            _pointsController = pointsController;
            _playerLevelView = playerLevelView;
        }

        public void Initialize()
        {
            InformSaveReaders();
            
            _player.Init(_mainGameField.SpawnPoint);
            _pointsController.Init();
            _cameraFollow.Init(_player.CameraTarget);
            _mainGameField.Init();
            _playerLevelView.Init();
            
            _gameplayStarter.Init(StartGameplay);
        }

        private void StartGameplay()
        {
            _player.StartGameplay();
            _playerLevelView.StartGameplay();
        }
        
        private void InformSaveReaders()
        {
            foreach (var saveReader in _saveDataHandler.SaveReaders)
            {
                saveReader.ReadSave(_saveDataHandler.SaveData);
            }
        }
    }
}