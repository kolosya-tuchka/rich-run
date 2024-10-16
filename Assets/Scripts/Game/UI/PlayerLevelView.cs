using Configs;
using Game.Player;
using UnityEngine;
using VContainer;

namespace Game.UI
{
    public class PlayerLevelView : MonoBehaviour
    {
        private PointsController _pointsController;
        
        [Inject]
        public void Construct(PointsController pointsController)
        {
            _pointsController = pointsController;
        }

        public void Init()
        {
            _pointsController.OnLevelChange += OnLevelChange;
            _pointsController.OnPointsChange += OnPointsChange;
            
            gameObject.SetActive(false);
        }

        public void StartGameplay()
        {
            gameObject.SetActive(true);
        }

        private void OnLevelChange(PointsLevelConfig pointsLevelConfig)
        {
            Debug.Log(pointsLevelConfig.Name);
        }

        private void OnPointsChange(int points)
        {
            Debug.Log($"Points: {points}");
        }
    }
}