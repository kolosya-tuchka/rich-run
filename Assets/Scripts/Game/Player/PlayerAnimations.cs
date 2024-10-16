using UnityEngine;
using VContainer;

namespace Game.Player
{
    public class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private string gameplayParameterName, winParameterName, loseParameterName;
        [SerializeField] private Animator animator;
        private WinLoseController _winLoseController;

        [Inject]
        public void Construct(WinLoseController winLoseController)
        {
            _winLoseController = winLoseController;
        }

        public void Init()
        {
            _winLoseController.OnPlayerWin += OnWin;
            _winLoseController.OnPlayerLose += OnLose;
        }

        public void StartGameplay()
        {
            animator.SetTrigger(gameplayParameterName);
        }

        private void OnLose()
        {
            animator.SetTrigger(loseParameterName);
        }

        private void OnWin()
        {
            animator.SetTrigger(winParameterName);
        }
    }
}
