using System.Collections.Generic;
using Configs;
using UnityEngine;
using VContainer;

namespace Game.Player
{
    public class PlayerModelSwapper : MonoBehaviour
    {
        [SerializeField] private List<GameObject> models;
        private GameObject _currentModel;
        private PointsController _pointsController;

        [Inject]
        public void Construct(PointsController pointsController)
        {
            _pointsController = pointsController;
        }

        public void Init()
        {
            _pointsController.OnLevelChange += OnLevelChange;
            ChangeModel(_pointsController.CurrentLevelIndex);
        }

        private void OnLevelChange(PointsLevelConfig pointsLevelConfig)
        {
            ChangeModel(_pointsController.CurrentLevelIndex);
        }

        private void ChangeModel(int modelIndex)
        {
            _currentModel?.SetActive(false);
            _currentModel = models[modelIndex];
            _currentModel.SetActive(true);
        }
    }
}
