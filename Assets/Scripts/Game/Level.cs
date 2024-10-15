using UnityEngine;

namespace Game
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;

        public Vector3 SpawnPoint => playerSpawnPoint.position;
    }
}