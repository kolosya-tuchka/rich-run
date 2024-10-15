using System;
using Core.Services.SaveDataHandler;
using Data;
using UnityEngine;
using VContainer;

namespace Core.Services.SaveLoad 
{
    public sealed class PlayerPrefsJsonSaveLoadService : ISaveLoadService
    {
        private readonly ISaveDataHandler _saveDataHandler;

        [Inject]
        public PlayerPrefsJsonSaveLoadService(ISaveDataHandler saveDataHandler)
        {
            _saveDataHandler = saveDataHandler;
        }

        public void SaveData() 
        {
            foreach (var saveWriter in _saveDataHandler.SaveWriters) {
                saveWriter.WriteSave(_saveDataHandler.SaveData);
            }
            
            if ( _saveDataHandler.SaveData == null ) {
                return;
            }
            
            var json = JsonUtility.ToJson(_saveDataHandler.SaveData);
            
            Debug.Log("Save data");
            PlayerPrefs.SetString("save_data", json);
        }
        
        public void LoadData(Action<SaveData> onComplete) 
        {
            var json = PlayerPrefs.GetString("save_data");
            
            var saveData = JsonUtility.FromJson<SaveData>(json);
            onComplete?.Invoke(saveData);
        }
    }
}