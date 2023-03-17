using FiniteStateMachine.Runtime.States;

namespace FiniteStateMachine.Runtime.Transitions
{
    public interface ITransition
    {
        protected internal bool CanTransition();
        protected internal IState GetNextState();
    }
}