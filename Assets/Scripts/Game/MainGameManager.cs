using Core.Services.SaveDataHandler;
using Core.Services.SaveLoad;
using Core.StateMachine;
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
        private readonly WinLoseController _winLoseController;
        private readonly GameUI _gameUI;
        private readonly StateMachine _stateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly PlayerModelSwapper _playerModelSwapper;
        private readonly PlayerAnimations _playerAnimations;

        [Inject]
        public MainGameManager(PlayerController player, MainGameField mainGameField,
            CameraFollow cameraFollow, ISaveDataHandler saveDataHandler, GameplayStarter gameplayStarter,
            PointsController pointsController, PlayerLevelView playerLevelView,
            WinLoseController winLoseController, GameUI gameUI, StateMachine stateMachine,
            ISaveLoadService saveLoadService, PlayerModelSwapper playerModelSwapper, PlayerAnimations playerAnimations)
        {
            _player = player;
            _mainGameField = mainGameField;
            _cameraFollow = cameraFollow;
            _saveDataHandler = saveDataHandler;
            _gameplayStarter = gameplayStarter;
            _pointsController = pointsController;
            _playerLevelView = playerLevelView;
            _winLoseController = winLoseController;
            _gameUI = gameUI;
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
            _playerModelSwapper = playerModelSwapper;
            _playerAnimations = playerAnimations;
        }

        public void Initialize()
        {
            InformSaveReaders();
            
            _player.Init(_mainGameField.SpawnPoint);
            _pointsController.Init();
            _playerModelSwapper.Init();
            _playerAnimations.Init();
            _cameraFollow.Init(_player.CameraTarget);
            _mainGameField.Init();
            _playerLevelView.Init();
            _winLoseController.Init();
            _gameUI.Init(RestartGame);
            
            _gameplayStarter.Init(StartGameplay);
        }

        private void StartGameplay()
        {
            _player.StartGameplay();
            _playerAnimations.StartGameplay();
            _playerLevelView.StartGameplay();
            _gameUI.StartGameplay();
        }
        
        private void InformSaveReaders()
        {
            foreach (var saveReader in _saveDataHandler.SaveReaders)
            {
                saveReader.ReadSave(_saveDataHandler.SaveData);
            }
        }

        private void RestartGame()
        {
            _saveLoadService.SaveData();
            _saveDataHandler.CleanUp();
            _stateMachine.Enter<LoadGameState>();
        }
    }
}