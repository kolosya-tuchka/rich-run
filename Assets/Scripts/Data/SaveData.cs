using System;

namespace Data
{
    [Serializable]
    public class SaveData
    {
        public LevelSaveData LevelSaveData = new();
        public MoneySaveData MoneySaveData = new();
    }
}