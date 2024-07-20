using SquareDinoTestTask.Services.Input;
using SquareDinoTestTask.Services.SceneManagement;

namespace SquareDinoTestTask.Game
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine stateMachine;
        private readonly Way.Way way;
        private readonly IInputService inputService;

        public GameLoopState(
            GameStateMachine stateMachine,
            Way.Way way, 
            IInputService inputService)
        {
            this.stateMachine = stateMachine;
            this.way = way;
            this.inputService = inputService;
        }

        public void Enter()
        {
            inputService.IsListening = true;
            way.OnCompleted += HandleWayCompleted;
        }

        public void Exit()
        {
            inputService.IsListening = false;
            way.OnCompleted -= HandleWayCompleted;
        }

        private async void HandleWayCompleted()
        {
            stateMachine.Enter<GameEndState>();
        }
    }
}