using System.Collections.Generic;
using Configs;
using Game.Pickups;
using UnityEngine;
using UnityEngine.Splines;

namespace Game.Levels
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private SplineContainer moveSpline;
        [SerializeField] private List<Pickup> _pickups;

        public void Init(LevelConfig levelConfig)
        {
            foreach (var pickup in _pickups)
            {
                pickup.Init(levelConfig);
            }
        }
        
        public Vector3 SpawnPoint => playerSpawnPoint.position;
        public SplineContainer MoveSpline => moveSpline;
    }
}