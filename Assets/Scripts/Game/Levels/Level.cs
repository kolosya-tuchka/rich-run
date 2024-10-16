using UnityEngine;
using UnityEngine.Splines;

namespace Game.Levels
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private SplineContainer moveSpline;
        
        public Vector3 SpawnPoint => playerSpawnPoint.position;
        public SplineContainer MoveSpline => moveSpline;
    }
}