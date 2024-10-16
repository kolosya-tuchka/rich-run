using System;
using Game.Player;
using UnityEngine;

namespace Game.Levels
{
    public class Finish : MonoBehaviour
    {
        private Action _onPlayerFinished;
        private bool _finished;

        public void Init(Action onPlayerFinished)
        {
            _onPlayerFinished = onPlayerFinished;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController player) && !_finished)
            {
                _onPlayerFinished?.Invoke();
                _finished = true;
            }
        }
    }
}
