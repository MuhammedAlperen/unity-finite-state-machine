using UnityEngine;

namespace FiniteStateMachine.Demo.Scripts.InputSystem
{
    public class UnityInputController : IInputController
    {
        public bool IsMoving => GetMoveHorizontal() != 0 || GetMoveVertical() != 0;
        public bool IsCrouching => Input.GetKey(KeyCode.LeftControl);
        public bool IsJumping => Input.GetKey(KeyCode.Space);

        public float GetMoveHorizontal()
        {
            var horizontalInput = 0;
            if (Input.GetKey(KeyCode.A)) horizontalInput += -1;
            if (Input.GetKey(KeyCode.D)) horizontalInput += 1;
            return horizontalInput;
        }

        public float GetMoveVertical()
        {
            var verticalInput = 0;
            if (Input.GetKey(KeyCode.W)) verticalInput += 1;
            if (Input.GetKey(KeyCode.S)) verticalInput += -1;
            return verticalInput;
        }
    }
}