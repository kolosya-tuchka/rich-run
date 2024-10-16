using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(PlayerConfig), fileName = nameof(PlayerConfig))]
    public class PlayerConfig : ScriptableObject
    {
        public float ForwardSpeed = 1f;
        public float SidewaysSpeed = 2f;
        public float RoadWidth = 0.45f;
    }
}