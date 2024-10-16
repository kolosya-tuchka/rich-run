using System;
using Core.Services.GameFactory;
using Game;
using VContainer;
using VContainer.Unity;

namespace Core.StateMachine
{
    public class GameplayState : IState
    {
        private LifetimeScope _projectScope, _mainGameScope;
        private IGameFactory _gameFactory;

        [Inject]
        public void Construct(LifetimeScope projectScope, IGameFactory gameFactory)
        {
            _projectScope = projectScope;
            _gameFactory = gameFactory;
        }
        
        public void Enter()
        {
            _mainGameScope = _projectScope.CreateChild(builder =>
            {
                builder.RegisterComponent(_gameFactory.CreateMainGameField());

                var player = _gameFactory.CreatePlayer();
                builder.RegisterComponent(player);
                builder.RegisterComponent(player.PlayerMove);
                
                builder.RegisterComponent(_gameFactory.CreateCamera());
                builder.Register<GameplayStarter>(Lifetime.Singleton);

                builder.RegisterEntryPoint<MainGameManager>();
            });
        }

        public void Exit()
        {
            _mainGameScope.Dispose();
        }
    }
}