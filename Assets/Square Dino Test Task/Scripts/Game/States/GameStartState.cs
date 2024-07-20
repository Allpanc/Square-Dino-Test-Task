using SquareDinoTestTask.Player;
using SquareDinoTestTask.UI;

namespace SquareDinoTestTask.Game
{
    public class GameStartState : IPayloadedState<GameStartState.Context>
    {
        public class Context
        {
            public PlayerMoveBetweenWayPoints playerMove;
            public StartMenu startMenu;
        }
        
        private readonly GameStateMachine stateMachine;
        private StartMenu startMenu;
        private PlayerMoveBetweenWayPoints playerMove;

        public GameStartState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public async void Enter(Context context)
        {
            playerMove = context.playerMove;
            startMenu = context.startMenu;
            await startMenu.Show();
            startMenu.OnStartButtonClick += HandleStartButtonClick;
        }

        public async void Exit()
        {
            startMenu.OnStartButtonClick -= HandleStartButtonClick;
            await startMenu.Hide();
        }

        private void HandleStartButtonClick()
        {
            playerMove.MoveToTargetWayPoint();
            stateMachine.Enter<GameLoopState>();
        }
    }


}