using Core.SceneManagement;
using Core.Services.SaveLoad;
using Core.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameStarter : MonoBehaviour, IInitializable
    {
        private StateMachine.StateMachine _stateMachine;
        
        [Inject]
        public void Construct(StateMachine.StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            _stateMachine.Initialize();
            _stateMachine.Enter<LoadProgressState>();
        }
    }
}