using System;
using Data;

namespace Core.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveData();
        void LoadData(Action<SaveData> onComplete);
    }
}