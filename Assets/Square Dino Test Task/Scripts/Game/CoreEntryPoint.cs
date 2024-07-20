using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Services.Input;
using SquareDinoTestTask.Services.SceneManagement;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;
using UnityEngine;
using Zenject;

namespace SquareDinoTestTask.Game
{
    public class CoreEntryPoint : MonoBehaviour
    {
        [SerializeField] 
        private CoreSceneBindings coreSceneBindings;
            
        private Game game;
        private NpcFactory npcFactory;
        private PlayerFactory playerFactory;
        private IInputService inputService;
        private ProjectileSpawner projectileSpawner;
        private SceneLoader sceneLoader;
        private MenuFactory menuFactory;

        [Inject]
        private void Construct(
            IInputService inputService,
            SceneLoader sceneLoader,
            NpcFactory npcFactory,
            PlayerFactory playerFactory,
            ProjectileSpawner projectileSpawner,
            MenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
            this.sceneLoader = sceneLoader;
            this.projectileSpawner = projectileSpawner;
            this.inputService = inputService;
            this.playerFactory = playerFactory;
            this.npcFactory = npcFactory;
        }
        
        private void Awake()
        {
            game = new Game(
                inputService, 
                sceneLoader,
                coreSceneBindings, 
                npcFactory, 
                playerFactory,
                projectileSpawner,
                menuFactory);
            
            game.LoadLevel();
        }
    }
}