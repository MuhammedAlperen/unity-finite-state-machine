using System.Collections.Generic;
using System.Linq;
using FiniteStateMachine.Runtime.States;
using FiniteStateMachine.Runtime.Transitions;
using UnityEngine;

namespace FiniteStateMachine.Demo.Scripts.CustomStates
{
    public class JumpState : IState
    {
        public StateDelegate OnEntered { get; set; }
        public StateDelegate OnExited { get; set; }

        private readonly MovementController _movementController;

        private ITransition[] _transitions;
        private readonly float _jumpForce;

        public JumpState(MovementController movementController, float jumpForce)
        {
            _movementController = movementController;
            _jumpForce = jumpForce;
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
            _movementController.AddVelocity(Vector3.up * _jumpForce);
            // _animationController.SetJump();
        }

        void IState.OnExit()
        {
            // _animationController.ResetJump();
        }
    }
}