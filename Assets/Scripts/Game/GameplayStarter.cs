using System;
using System.Collections;
using Core;
using Core.Services.Input;
using UnityEngine;
using VContainer;

namespace Game
{
    public class GameplayStarter
    {
        private readonly IInputService _inputService;
        private readonly ICoroutineRunner _coroutineRunner;
        private Action _onGameplayStarted;

        [Inject]
        public GameplayStarter(IInputService inputService, ICoroutineRunner coroutineRunner)
        {
            _inputService = inputService;
            _coroutineRunner = coroutineRunner;
        }

        public void Init(Action onGameplayStarted)
        {
            _onGameplayStarted = onGameplayStarted;
            _coroutineRunner.StartCoroutine(WaitForPlayer());
        }

        private IEnumerator WaitForPlayer()
        {
            yield return new WaitUntil(() => _inputService.GetMouseButtonDown());
            _onGameplayStarted?.Invoke();
        }
    }
}
