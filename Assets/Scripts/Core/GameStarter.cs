using Core.SceneManagement;
using Core.Services.SaveLoad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameStarter : MonoBehaviour, IInitializable
    {
        private ISaveLoadService _saveLoadService;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(ISaveLoadService saveLoadService, SceneLoader sceneLoader)
        {
            _saveLoadService = saveLoadService;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _sceneLoader.LoadScene(SceneName.MainGame);
        }
    }
}