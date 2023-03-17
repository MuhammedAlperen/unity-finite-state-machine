namespace FiniteStateMachine.Demo.Scripts.InputSystem
{
    public interface IInputController
    {
        bool IsMoving { get; }
        bool IsCrouching { get; }
        bool IsJumping { get; }

        float GetMoveHorizontal();
        float GetMoveVertical();
    }
}