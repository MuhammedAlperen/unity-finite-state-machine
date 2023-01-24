using StateMachineSystem.Runtime.Conditions;
using StateMachineSystem.Runtime.States;

namespace StateMachineSystem.Runtime.Transitions
{
    public class ConditionedTransition : ITransition
    {
        private readonly ICondition[] _conditions;
        private readonly IState _nextState;

        public ConditionedTransition(ICondition[] conditions, IState nextState)
        {
            _conditions = conditions;
            _nextState = nextState;
        }

        bool ITransition.CanTransition()
        {
            foreach (var condition in _conditions)
            {
                if (!condition.IsMet()) return false;
            }

            return true;
        }

        IState ITransition.GetNextState()
        {
            return _nextState;
        }
    }
}