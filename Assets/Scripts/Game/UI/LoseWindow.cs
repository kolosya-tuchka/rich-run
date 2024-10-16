using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class LoseWindow : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        private Action _onRestartButtonClicked;

        public void Init()
        {
            restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        public void Open(Action onRestartButtonClicked)
        {
            gameObject.SetActive(true);
            _onRestartButtonClicked = onRestartButtonClicked;
        }

        private void OnRestartButtonClicked()
        {
            _onRestartButtonClicked?.Invoke();
        }
    }
}
