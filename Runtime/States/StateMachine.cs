using System.Collections.Generic;
using FiniteStateMachine.Runtime.Transitions;

namespace FiniteStateMachine.Runtime.States
{
    public class StateMachine : StateController, IState
    {
        public StateDelegate OnEntered { get; set; }
        public StateDelegate OnExited { get; set; }

        private ITransition[] Transitions { get; }


        public StateMachine(ITransition[] transitions, IState initialState) : base(initialState)
        {
            Transitions = transitions;
        }

        IEnumerable<ITransition> IState.GetTransitions() => Transitions;

        void IState.Enter()
        {
            Enter();
            OnEntered?.Invoke();
        }

        void IState.Update(float deltaTime)
        {
            Update(deltaTime);
        }

        void IState.FixedUpdate(float fixedDeltaTime)
        {
            FixedUpdate(fixedDeltaTime);
        }

        void IState.Exit()
        {
            Exit();
            OnExited?.Invoke();
        }
    }
}