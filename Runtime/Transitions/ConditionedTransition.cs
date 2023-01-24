using StateMachineSystem.Runtime.Conditions;
using StateMachineSystem.Runtime.States;

namespace StateMachineSystem.Runtime.Transitions
{
    public class ConditionedTransition : ITransition
    {
        public IState FromState { get; }
        public IState ToState { get; }

        private ICondition[] _conditions;

        public ConditionedTransition(IState fromState, IState toState)
        {
            FromState = fromState;
            ToState = toState;
        }

        bool ITransition.CanTransition()
        {
            foreach (var condition in _conditions)
            {
                if (!condition.IsMet()) return false;
            }

            return true;
        }
    }
}