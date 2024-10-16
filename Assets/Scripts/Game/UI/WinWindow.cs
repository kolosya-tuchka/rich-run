using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.UI
{
    public class WinWindow : MonoBehaviour
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private TMP_Text pointsText;
        private Action _onNextLevelButtonClicked;

        public void Init()
        {
            nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
        }

        public void Open(Action onNextLevelButtonClicked, int points)
        {
            gameObject.SetActive(true);
            _onNextLevelButtonClicked = onNextLevelButtonClicked;
            pointsText.text = $"+{points}";
        }

        private void OnNextLevelButtonClicked()
        {
            _onNextLevelButtonClicked?.Invoke();
        }
    }
}
