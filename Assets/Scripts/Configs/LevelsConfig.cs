using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(LevelsConfig), fileName = nameof(LevelsConfig))]
    public class LevelsConfig : ScriptableObject
    {
        public List<LevelConfig> Levels;
    }

    [Serializable]
    public class LevelConfig
    {
        public string Name;
        public int AlcoholPoints, MoneyPoints;
    } 
}