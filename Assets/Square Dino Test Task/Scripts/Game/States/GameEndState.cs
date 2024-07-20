using System;
using Cysharp.Threading.Tasks;
using SquareDinoTestTask.Services.SceneManagement;
using SquareDinoTestTask.UI;

namespace SquareDinoTestTask.Game
{
    public class GameEndState : IState
    {
        private readonly MenuFactory menuFactory;
        private readonly UiRoot uiRoot;
        private readonly SceneLoader sceneLoader;

        public GameEndState(MenuFactory menuFactory, UiRoot uiRoot, SceneLoader sceneLoader)
        {
            this.menuFactory = menuFactory;
            this.uiRoot = uiRoot;
            this.sceneLoader = sceneLoader;
        }

        public async void Enter()
        {
            menuFactory.CreateReloadMenu(uiRoot.transform);
            await UniTask.Delay(TimeSpan.FromSeconds(3f));
            await sceneLoader.LoadCoreScene();
        }

        public void Exit()
        {
            
        }
    }
}