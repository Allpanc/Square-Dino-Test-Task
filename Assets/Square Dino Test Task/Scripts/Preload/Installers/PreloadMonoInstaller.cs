using SquareDinoTestTask.Services.Input;
using SquareDinoTestTask.Services.SceneManagement;
using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Preload
{
    public class PreloadMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
            BindInstance(new SceneLoader());
        }

        private void BindInputService()
        {
            IInputService inputService = GetInputService();
            
            Container
                .BindInterfacesAndSelfTo<IInputService>()
                .FromInstance(inputService);
        }

        private IInputService GetInputService()
        {
            return Application.isEditor
                ? new StandaloneInputService()
                : new MobileInputService();
        }

        private void BindInstance<TInstance>(TInstance instance)
        {
            Container
                .Bind<TInstance>()
                .FromInstance(instance)
                .AsSingle();
        }
    }
}