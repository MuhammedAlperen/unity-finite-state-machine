using System.Collections.Generic;
using System.Linq;
using FiniteStateMachine.Runtime.States;
using FiniteStateMachine.Runtime.Transitions;

namespace FiniteStateMachine.Demo.Scripts.CustomStates
{
    public class CrouchState : IState
    {
        public StateDelegate OnEntered { get; set; }
        public StateDelegate OnExited { get; set; }

        private readonly MovementController _movementController;
        private ITransition[] _transitions;

        public CrouchState(MovementController movementController)
        {
            _movementController = movementController;
        }

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
            // _animationController.SetCrouch();
            _movementController.SetSpeedMultiplier(0.5f);
        }

        void IState.OnExit()
        {
            // _animationController.ResetCrouch();
            _movementController.SetSpeedMultiplier(1f);
        }
    }
}