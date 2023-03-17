using System.Collections.Generic;
using System.Linq;
using FiniteStateMachine.Runtime.States;
using FiniteStateMachine.Runtime.Transitions;

namespace FiniteStateMachine.Demo.Scripts.CustomStates
{
    public class IdleState : IState
    {
        public StateDelegate OnEntered { get; set; }
        public StateDelegate OnExited { get; set; }

        private ITransition[] _transitions;

        public void SetTransitions(IEnumerable<ITransition> transitions)
        {
            _transitions = transitions.ToArray();
        }

        IEnumerable<ITransition> IState.GetTransitions()
        {
            return _transitions;
        }

        void IState.OnEnter()
        {
            // _animationController.SetIdle();
        }

        void IState.OnExit()
        {
            // _animationController.ResetIdle();
        }
    }
}