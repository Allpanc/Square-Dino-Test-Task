using SquareDinoTestTask.Services;
using SquareDinoTestTask.Services.SceneManagement;
using UnityEngine;
using Zenject;

namespace Square_Dino_Test_Task.Scripts.Preload
{
    public class PreloadEntryPoint : MonoBehaviour
    {
        private SceneLoader sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
        }
        
        private async void Awake()
        {
            await sceneLoader.LoadCoreScene();
        }
    }
}