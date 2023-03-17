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
            return Input.GetAxis("Horizontal");
        }

        public float GetMoveVertical()
        {
            return Input.GetAxis("Vertical");
        }
    }
}