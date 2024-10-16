using Core.Services.SaveDataHandler;
using Game.Camera;
using Game.Levels;
using Game.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game
{
    public class MainGameManager : IInitializable
    {
        private readonly PlayerController _player;
        private readonly MainGameField _mainGameField;
        private readonly CameraFollow _cameraFollow;
        private readonly ISaveDataHandler _saveDataHandler;

        [Inject]
        public MainGameManager(PlayerController player, MainGameField mainGameField,
            CameraFollow cameraFollow, ISaveDataHandler saveDataHandler)
        {
            _player = player;
            _mainGameField = mainGameField;
            _cameraFollow = cameraFollow;
            _saveDataHandler = saveDataHandler;
        }

        public void Initialize()
        {
            InformSaveReaders();
            
            _player.Init(_mainGameField.SpawnPoint);
            _cameraFollow.Init(_player.CameraTarget);
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