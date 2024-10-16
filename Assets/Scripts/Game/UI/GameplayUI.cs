using Game.Player;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class GameplayUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text pointsText;
        [SerializeField] private TMP_Text levelText;

        public void Init(PointsController pointsController, string levelName)
        {
            pointsController.OnTotalPointsChange += UpdatePointsText;
            UpdatePointsText(pointsController.TotalPoints);
            levelText.text = levelName;
        }

        private void UpdatePointsText(int points)
        {
            pointsText.text = points.ToString();
        }
    }
}
