namespace StateMachineSystem.Runtime.States
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
            CurrentState.OnEnter();
        }

        public void Update(float deltaTime)
        {
            CurrentState.OnUpdate(deltaTime);

            foreach (var transition in CurrentState.GetTransitions())
            {
                if(transition.FromState != CurrentState) continue;
                if (!transition.CanTransition()) continue;

                SwitchState(transition.ToState);
            }
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            CurrentState.OnFixedUpdate(fixedDeltaTime);
        }

        public void Exit()
        {
            CurrentState.OnExit();
        }

        private void SwitchState(IState newState)
        {
            CurrentState.OnExit();
            CurrentState = newState;
            CurrentState.OnEnter();
        }
    }
}
