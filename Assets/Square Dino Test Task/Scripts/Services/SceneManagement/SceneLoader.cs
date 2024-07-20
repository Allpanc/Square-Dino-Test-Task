using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquareDinoTestTask.Services.SceneManagement
{
    public class SceneLoader
    {
        private const string CoreSceneName = "Core";
        
        public async UniTask LoadCoreScene()
        {
            await LoadScene(CoreSceneName);
        }

        private async UniTask Load(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                return;
            }

            await LoadScene(name, onLoaded);
        }

        private async UniTask LoadScene(string nextScene, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            await waitNextScene.ToUniTask();

            onLoaded?.Invoke();
        }
    }
}