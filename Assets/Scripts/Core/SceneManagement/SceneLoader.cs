using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Core.SceneManagement
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneName CurrentSceneName { get; private set; }

        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(SceneName sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(SceneName sceneName, Action onLoaded = null)
        {
            var nextScene = SceneManager.LoadSceneAsync(sceneName.ToString());

            while ( !nextScene.isDone )
            {
                yield return null;
            }

            CurrentSceneName = sceneName;
            onLoaded?.Invoke();
        }
    }
}