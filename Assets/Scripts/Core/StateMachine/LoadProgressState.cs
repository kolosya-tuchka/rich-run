using System;
using Core.Services.SaveDataHandler;
using Core.Services.SaveLoad;
using Data;
using UnityEngine;
using VContainer;

namespace Core.StateMachine
{
    public class LoadProgressState : IState
    {
        private readonly StateMachine _stateMachine;
        private ISaveDataHandler _saveDataHandler;
        private ISaveLoadService _saveLoadService;
        
        public LoadProgressState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        [Inject]
        public void Construct(ISaveDataHandler saveDataHandler, ISaveLoadService saveLoadService)
        {
            _saveDataHandler = saveDataHandler;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _saveLoadService.LoadData(OnSaveDataLoaded);
        }

        public void Exit() {}
        
        private void OnSaveDataLoaded(SaveData saveData)
        {
            _saveDataHandler.SaveData = saveData ?? CreateData();
            
            _stateMachine.Enter<LoadGameState>();
        }

        private SaveData CreateData()
        {
            Debug.Log("Create new save data");

            var saveData = new SaveData();
            return saveData;
        }
    }
}