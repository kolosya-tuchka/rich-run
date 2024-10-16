using Core.Services.GameFactory;
using Game;
using Game.Player;
using Game.Player.Movement;
using Game.UI;
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
                builder.RegisterComponent(player.GetComponent<PlayerMove>());
                builder.RegisterComponent(player.GetComponent<PointsController>());
                builder.RegisterComponent(player.GetComponentInChildren<PlayerLevelView>());
                
                builder.RegisterComponent(_gameFactory.CreateCamera());
                builder.Register<WinLoseController>(Lifetime.Singleton);
                builder.Register<GameplayStarter>(Lifetime.Singleton);

                builder.RegisterComponent(_gameFactory.CreateGameUI());

                builder.RegisterEntryPoint<MainGameManager>();
            });
        }

        public void Exit()
        {
            _mainGameScope.Dispose();
        }
    }
}