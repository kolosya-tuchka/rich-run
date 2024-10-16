using System;
using Configs;
using Game.Levels;
using UnityEngine;
using UnityEngine.Splines;
using VContainer;

namespace Game.Player.Movement
{
    public class PlayerSplineMove : PlayerMove
    {
        [SerializeField] private SplineAnimate splineAnimate;
        private PlayerConfig _playerConfig;
        private MainGameField _mainGameField;
        
        [Inject]
        public void Construct(GameConfigs gameConfigs, MainGameField mainGameField)
        {
            _mainGameField = mainGameField;
            _playerConfig = gameConfigs.PlayerConfig;
        }

        public override void Init()
        {
            splineAnimate.Container = _mainGameField.MoveSpline;
        }

        public override void StartMove()
        {
            splineAnimate.MaxSpeed = _playerConfig.ForwardSpeed;
            splineAnimate.Play();
        }

        public override void StopMove()
        {
            splineAnimate.Pause();
        }

        public override void UpdateMove(float direction)
        {
            transform.Translate(Vector3.right * (direction * _playerConfig.SidewaysSpeed));
        }
    }
}