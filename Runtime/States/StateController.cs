using UnityEngine;

namespace FiniteStateMachine.Runtime.States
{
    public class StateController
    {
        private IState InitialState { get; }
        private IState CurrentState { get; set; }

        public StateController(IState initialState)
        {
            InitialState = initialState;
        }

        public void Enter()
        {
            CurrentState = InitialState;
            CurrentState.Enter();
        }

        public void Update(float deltaTime)
        {
            CurrentState.Update(deltaTime);

            foreach (var transition in CurrentState.GetTransitions())
            {
                if (!transition.CanTransition()) continue;

                SwitchState(transition.GetNextState());
                break;
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            CurrentState.FixedUpdate(fixedDeltaTime);
        }

        public void Exit()
        {
            CurrentState.Exit();
        }

        private void SwitchState(IState newState)
        {
            Debug.Log("Switching State: " + CurrentState.GetType().Name + " => " + newState.GetType().Name);
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
