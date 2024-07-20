using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Services.Input;
using SquareDinoTestTask.Services.SceneManagement;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;

namespace SquareDinoTestTask.Game
{
    public class Game
    {
        private GameStateMachine stateMachine;

        public Game(
            IInputService inputService, 
            SceneLoader sceneLoader,
            CoreSceneBindings coreSceneBindings, 
            NpcFactory npcFactory, 
            PlayerFactory playerFactory,
            ProjectileSpawner projectileSpawner,
            MenuFactory menuFactory)
        {
            stateMachine = new GameStateMachine(
                inputService, 
                sceneLoader,
                coreSceneBindings, 
                npcFactory, 
                playerFactory, 
                projectileSpawner,
                menuFactory);
        }

        public void LoadLevel()
        {
            stateMachine.Enter<LoadLevelState>();
        }
    }
}