using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(GameConfigs), fileName = nameof(GameConfigs))]
    public class GameConfigs : ScriptableObject
    {
        public AudioConfig AudioConfig;
        public LevelsConfig LevelsConfig;
        public PlayerConfig PlayerConfig;
    }
}