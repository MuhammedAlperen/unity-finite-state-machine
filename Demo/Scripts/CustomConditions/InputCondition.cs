using FiniteStateMachine.Demo.Scripts.InputSystem;
using FiniteStateMachine.Runtime.Conditions;

namespace FiniteStateMachine.Demo.Scripts.CustomConditions
{
    public class InputCondition : ICondition
    {
        private readonly IInputController _inputController;
        private readonly InputType _inputType;
        private readonly bool _inverted;

        public InputCondition(IInputController inputController, InputType inputType, bool inverted = false)
        {
            _inputController = inputController;
            _inputType = inputType;
            _inverted = inverted;
        }

        public bool IsMet()
        {
            var input = _inputType switch
            {
                InputType.Move => _inputController.IsMoving,
                InputType.Jump => _inputController.IsJumping,
                InputType.Crouch => _inputController.IsCrouching,
                _ => false
            };
            return _inverted ? !input : input;
        }

        public enum InputType
        {
            None = 0,
            Move = 1,
            Jump = 2,
            Crouch = 3
        }
    }
}