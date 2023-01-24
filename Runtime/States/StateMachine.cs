using StateMachineSystem.Runtime.Transitions;

namespace StateMachineSystem.Runtime.States
{
    public class StateMachine : StateController, IState
    {
        private ITransition[] Transitions { get; }


        public StateMachine(ITransition[] transitions, IState initialState) : base(initialState)
        {
            Transitions = transitions;
        }

        ITransition[] IState.GetTransitions() => Transitions;

        void IState.OnEnter() => Enter();
        void IState.OnUpdate(float deltaTime) => Update(deltaTime);
        void IState.OnFixedUpdate(float fixedDeltaTime) => FixedUpdate(fixedDeltaTime);
        void IState.OnExit() => Exit();
    }
}