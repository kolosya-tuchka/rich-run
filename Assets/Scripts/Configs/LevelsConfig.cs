﻿using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(LevelsConfig), fileName = nameof(LevelsConfig))]
    public class LevelsConfig : ScriptableObject
    {
        public List<string> LevelNames;
    }
}