using StateMachineSystem.Runtime.States;

namespace StateMachineSystem.Runtime.Transitions
{
    public interface ITransition
    {
        protected internal bool CanTransition();
        protected internal IState GetNextState();
    }
}