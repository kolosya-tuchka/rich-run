using UnityEngine.SceneManagement;

namespace Core.SceneManagement
{
    public class SceneLoader
    {
        public void LoadScene(SceneName sceneName)
        {
            SceneManager.LoadScene(sceneName.ToString());
        }

        public void ReloadScene()
        {
            var buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(buildIndex);
        }
    }
}