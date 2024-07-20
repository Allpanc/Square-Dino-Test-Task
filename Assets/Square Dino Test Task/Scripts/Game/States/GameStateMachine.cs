using System;
using System.Collections.Generic;
using SquareDinoTestTask.Npc;
using SquareDinoTestTask.Player;
using SquareDinoTestTask.Services.Input;
using SquareDinoTestTask.Services.SceneManagement;
using SquareDinoTestTask.Shooting;
using SquareDinoTestTask.UI;

namespace SquareDinoTestTask.Game
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> states;
        private IExitableState activeState;

        public GameStateMachine(
            IInputService inputService, 
            SceneLoader sceneLoader,
            CoreSceneBindings coreSceneBindings, 
            NpcFactory npcFactory,
            PlayerFactory playerFactory,
            ProjectileSpawner projectileSpawner,
            MenuFactory menuFactory)
        {
            states = new Dictionary<Type, IExitableState>
            {
                [typeof(LoadLevelState)] = new LoadLevelState(
                    this, 
                    coreSceneBindings, 
                    npcFactory, 
                    playerFactory,
                    projectileSpawner,
                    menuFactory),
                
                [typeof(GameStartState)] = new GameStartState(this),
                
                [typeof(GameLoopState)] = new GameLoopState(
                    this,
                    coreSceneBindings.way, 
                    inputService),
                
                [typeof(GameEndState)] = new GameEndState(
                    menuFactory,
                    coreSceneBindings.uiRoot,
                    sceneLoader)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            activeState?.Exit();

            TState state = GetState<TState>();
            activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            states[typeof(TState)] as TState;
    }
}
