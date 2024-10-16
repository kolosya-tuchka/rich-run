using Configs;
using UnityEngine;
using UnityEngine.Splines;
using VContainer;

namespace Game.Player.Movement
{
    public class PlayerSplineMove : PlayerMove
    {
        [SerializeField] private SplineAnimate splineAnimate;
        [SerializeField] private Rigidbody rigidbody;
        private PlayerConfig _playerConfig;
        
        [Inject]
        public void Construct(GameConfigs gameConfigs)
        {
            //splineAnimate.Container = moveSpline;
            _playerConfig = gameConfigs.PlayerConfig;
        }

        public override void StartMove()
        {
            splineAnimate.MaxSpeed = _playerConfig.ForwardSpeed;
        }

        public override void UpdateMove(float direction)
        {
            float sidewaysMovement = Mathf.Abs(direction) < _playerConfig.SidewaysMovementThreshold
                ? 0
                : Mathf.Clamp(direction, -1, 1) * _playerConfig.SidewaysSpeed;
            rigidbody.velocity = new Vector3(sidewaysMovement, rigidbody.velocity.y, rigidbody.velocity.z);
        }
    }
}