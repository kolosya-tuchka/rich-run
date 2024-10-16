using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(PlayerConfig), fileName = nameof(PlayerConfig))]
    public class PlayerConfig : ScriptableObject
    {
        public float ForwardSpeed = 1f;
        [FormerlySerializedAs("SideSpeed")] public float SidewaysSpeed = 2f;
        [Range(0, 1)] public float SidewaysMovementThreshold = 0.1f;
    }
}