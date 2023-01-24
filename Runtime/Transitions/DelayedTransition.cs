using StateMachineSystem.Runtime.States;
using TimeSystem.Runtime;

namespace StateMachineSystem.Runtime.Transitions
{
    public class DelayedTransition : ITransition
    {
        public IState FromState { get; }
        public IState ToState { get; }
        
        private readonly ITimeController _timeController;
        private readonly float _delay;
        private float _elapsed;

        public DelayedTransition(IState fromState, IState toState, ITimeController timeController, float delay)
        {
            FromState = fromState;
            ToState = toState;

            _timeController = timeController;
            _delay = delay;

            _timeController.OnUpdate += OnUpdate;
        }
        
        ~DelayedTransition()
        {
            _timeController.OnUpdate -= OnUpdate;
        }

        bool ITransition.CanTransition()
        {
            return _elapsed >= _delay;
        }

        private void OnUpdate()
        {
            _elapsed += _timeController.DeltaTime;
        }
    }
}