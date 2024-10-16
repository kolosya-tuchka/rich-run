using System;
using System.Collections.Generic;
using Core.SceneManagement;
using Core.Services.SaveDataHandler;
using Core.Services.SaveLoad;
using VContainer;

namespace Core.StateMachine
{
    public class StateMachine
    {
        private readonly IObjectResolver _container;
        private readonly Dictionary<Type, IState> _states;
        
        private IState _activeState;

        [Inject]
        public StateMachine(IObjectResolver container)
        {
            _container = container;
            _states = new();
        }

        public void Initialize()
        {
            _states[typeof(LoadProgressState)] = new LoadProgressState(this);
            _states[typeof(LoadGameState)] = new LoadGameState(this);
            _states[typeof(GameplayState)] = new GameplayState();

            foreach (var state in _states.Values)
            {
                _container.Inject(state);
            } 
        }
        
        public void Enter<T>() where T : class, IState 
        {
            var state = ChangeState<T>();
            state.Enter();
        }
        
        private T ChangeState<T>() where T : class, IState 
        {
            _activeState?.Exit();

            var state = GetState<T>();
            _activeState = state;

            return state;
        }

        private T GetState<T>() where T : class, IState => _states[typeof(T)] as T;
    }
}