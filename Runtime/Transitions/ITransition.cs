using StateMachineSystem.Runtime.States;

namespace StateMachineSystem.Runtime.Transitions
{
    public interface ITransition
    {
        IState FromState { get; }
        IState ToState { get; }

        internal bool CanTransition();
    }
}