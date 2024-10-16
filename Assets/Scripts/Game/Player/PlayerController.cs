using System;
using Configs;
using Core.Services.Input;
using Game.Player.Movement;
using UnityEngine;
using UnityEngine.Splines;
using VContainer;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform playerParent;
        [SerializeField] private PlayerMove playerMove;
        [SerializeField] private Transform cameraTarget;
        private bool _playing;

        private IInputService _inputService;
        private PlayerConfig _playerConfig;
        private WinLoseController _winLoseController;

        public Transform CameraTarget => cameraTarget;

        [Inject]
        public void Construct(IInputService inputService, GameConfigs gameConfigs, WinLoseController winLoseController)
        {
            _inputService = inputService;
            _playerConfig = gameConfigs.PlayerConfig;
            _winLoseController = winLoseController;
        }
        
        public void Init(Vector3 spawnPosition)
        {
            playerParent.position = spawnPosition;
            playerMove.Init();
            _winLoseController.OnPlayerWin += OnPlayerWin;
            _winLoseController.OnPlayerLose += OnPlayerLose;
        }

        public void StartGameplay()
        {
            playerMove.StartMove();
            _playing = true;
        }

        private void Update()
        {
            if (!_playing)
            {
                return;
            }

            if (_inputService.GetMouseButton())
            {
                var direction = _inputService.GetMouseMoveX() * Time.deltaTime;
                playerMove.UpdateMove(direction);
            }
            
            var x = Mathf.Clamp(transform.localPosition.x, -_playerConfig.RoadWidth, _playerConfig.RoadWidth);
            transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        }

        private void OnPlayerLose()
        {
            _playing = false;
            playerMove.StopMove();
        }

        private void OnPlayerWin()
        {
            _playing = false;
            playerMove.StopMove();
        }
    }
}