using Core.SceneManagement;
using VContainer;

namespace Core.StateMachine
{
    public class LoadGameState : IState
    {
        private readonly StateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        
        public LoadGameState(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneName.MainGame, OnLoaded);
        }
        
        public void Exit() {}

        private void OnLoaded()
        {
            _stateMachine.Enter<GameplayState>();
        }
    }
}