using Core.Services.SaveLoad;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameStarter : MonoBehaviour, IInitializable
    {
        private ISaveLoadService _saveLoadService;

        [Inject]
        public void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void Initialize()
        {
            
        }
    }
}