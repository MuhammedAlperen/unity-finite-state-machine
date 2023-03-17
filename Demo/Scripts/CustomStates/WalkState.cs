using System.Collections.Generic;
using System.Linq;
using FiniteStateMachine.Demo.Scripts.InputSystem;
using FiniteStateMachine.Runtime.States;
using FiniteStateMachine.Runtime.Transitions;
using UnityEngine;

namespace FiniteStateMachine.Demo.Scripts.CustomStates
{
    public class WalkState : IState
    {
        public StateDelegate OnEntered { get; set; }
        public StateDelegate OnExited { get; set; }

        private readonly MovementController _movementController;
        private readonly IInputController _inputController;

        private ITransition[] _transitions;

        public WalkState(MovementController movementController, IInputController inputController)
        {
            _movementController = movementController;
            _inputController = inputController;
        }

        IEnumerable<ITransition> IState.GetTransitions()
        {
            return _transitions;
        }

        public void SetTransitions(IEnumerable<ITransition> transitions)
        {
            _transitions = transitions.ToArray();
        }

        void IState.OnEnter()
        {
            // _animationController.SetWalk();
        }

        void IState.OnUpdate(float deltaTime)
        {
            var moveVector = new Vector2(_inputController.GetMoveHorizontal(), _inputController.GetMoveVertical());
            _movementController.Move(moveVector.normalized * deltaTime);
        }

        void IState.OnExit()
        {
            // _animationController.ResetWalk();
        }
    }
}