using SquareDinoTestTask.Camera;
using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;

namespace SquareDinoTestTask.Game
{
    public class LoadLevelState : IState
    {
        private readonly GameStateMachine stateMachine;
        private readonly CoreSceneBindings coreSceneBindings;
        private readonly NpcFactory npcFactory;
        private readonly PlayerFactory playerFactory;
        private readonly ProjectileSpawner projectileSpawner;
        private readonly MenuFactory menuFactory;
        
        private Player.Player player;
        private StartMenu startMenu;

        public LoadLevelState(
            GameStateMachine stateMachine, 
            CoreSceneBindings coreSceneBindings,
            NpcFactory npcFactory, 
            PlayerFactory playerFactory,
            ProjectileSpawner projectileSpawner,
            MenuFactory menuFactory)
        {
            this.projectileSpawner = projectileSpawner;
            this.menuFactory = menuFactory;
            this.stateMachine = stateMachine;
            this.coreSceneBindings = coreSceneBindings;
            this.npcFactory = npcFactory;
            this.playerFactory = playerFactory;
        }

        public void Enter()
        {
            InitializeGameWorld();
            InitializeUi();
            EnterGameStart();
        }

        public void Exit()
        {

        }

        private void EnterGameStart()
        {
            var context = new GameStartState.Context
            {
                playerMove = player.GetComponent<PlayerMoveBetweenWayPoints>(),
                startMenu = startMenu
            };
            
            stateMachine.Enter<GameStartState, GameStartState.Context>(context);
        }

        private void InitializeGameWorld()
        {
            player = SpawnPlayer();
            
            SpawnNpcs();

            SpawnProjectiles();
            
            CameraTarget cameraTarget = player.GetComponent<CameraTarget>();
            SetCameraTarget(cameraTarget);
        }

        private void InitializeUi()
        {
            startMenu = menuFactory.CreateStartMenu(coreSceneBindings.uiRoot.transform);
        }

        private Player.Player SpawnPlayer()
        {
            return playerFactory.Create(coreSceneBindings.playerSpawnPoint.transform);
        }

        private void SpawnNpcs()
        {
            foreach (NpcSpawnPoint npcSpawnPoint in coreSceneBindings.npcSpawnPoints)
            {
                npcFactory.Create(npcSpawnPoint);
            }
        }

        private void SpawnProjectiles()
        {
            projectileSpawner.SpawnProjectiles(coreSceneBindings.projectilesParent);
        }

        private void SetCameraTarget(CameraTarget cameraTarget)
        {
            coreSceneBindings.cameraFollower.SetTarget(cameraTarget);
        }
    }
}