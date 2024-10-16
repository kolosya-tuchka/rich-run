using Configs;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    public class PlayerLevelView : MonoBehaviour
    {
        [SerializeField] private Image pointsBar;
        [SerializeField] private TMP_Text levelText;
        private PointsController _pointsController;

        private int _maxPoints;
        
        [Inject]
        public void Construct(PointsController pointsController)
        {
            _pointsController = pointsController;
        }

        public void Init()
        {
            _pointsController.OnLevelChange += OnLevelChange;
            _pointsController.OnPointsChange += OnPointsChange;
            
            OnLevelChange(_pointsController.CurrentLevel);
            OnPointsChange(_pointsController.Points);       
            
            gameObject.SetActive(false);
        }

        public void StartGameplay()
        {
            gameObject.SetActive(true);
        }

        private void OnLevelChange(PointsLevelConfig pointsLevelConfig)
        {
            levelText.text = pointsLevelConfig.Name;
            _maxPoints = pointsLevelConfig.PointsToUpgrade;
            OnPointsChange(_pointsController.Points);
        }

        private void OnPointsChange(int points)
        {
            pointsBar.fillAmount = (float)points / _maxPoints;
        }
    }
}