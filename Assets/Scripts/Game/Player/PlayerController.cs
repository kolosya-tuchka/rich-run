using Game.Player.Movement;
using UnityEngine;
using UnityEngine.Splines;

namespace Game.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform playerParent;
        [SerializeField] private PlayerMove playerMove;
        [SerializeField] private Transform cameraTarget;

        public Transform CameraTarget => cameraTarget;

        public void Init(Vector3 spawnPosition)
        {
            playerParent.position = spawnPosition;
        }
    }
}