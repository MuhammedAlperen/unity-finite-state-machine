using System.Collections.Generic;
using System.Linq;
using FiniteStateMachine.Demo.Scripts.InputSystem;
using FiniteStateMachine.Runtime.States;
using FiniteStateMachine.Runtime.Transitions;
using UnityEngine;

namespace FiniteStateMachine.Demo.Scripts.CustomStates
{
    public class CrouchState : IState
    {
        public StateDelegate OnEntered { get; set; }
        public StateDelegate OnExited { get; set; }

        private readonly MovementController _movementController;
        private readonly IInputController _inputController;
        private ITransition[] _transitions;

        public CrouchState(MovementController movementController, IInputController inputController)
        {
            _movementController = movementController;
            _inputController = inputController;
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

        void IState.OnFixedUpdate(float fixedDeltaTime)
        {
            var moveVector = new Vector2(_inputController.GetMoveHorizontal(), _inputController.GetMoveVertical());
            _movementController.Move(moveVector.normalized * fixedDeltaTime);
        }

        void IState.OnExit()
        {
            // _animationController.ResetCrouch();
            _movementController.SetSpeedMultiplier(1f);
        }
    }
}