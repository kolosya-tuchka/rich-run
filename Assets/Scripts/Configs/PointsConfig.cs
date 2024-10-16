using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(PointsConfig), fileName = nameof(PointsConfig))]
    public class PointsConfig : ScriptableObject
    {
        public int InitialPoints = 10;
        public int InitialLevel = 1;
        public List<PointsLevelConfig> PointLevels;
    }

    [Serializable]
    public struct PointsLevelConfig
    {
        public string Name;
        public int PointsToUpgrade;
    }
}