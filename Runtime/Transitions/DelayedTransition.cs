using FiniteStateMachine.Runtime.States;
using Utils.Runtime.TimeSystem;

namespace FiniteStateMachine.Runtime.Transitions
{
    public class DelayedTransition : ITransition
    {
        private readonly ITimeController _timeController;
        private readonly IState _nextState;
        private readonly float _delay;
        private float _elapsed;

        public DelayedTransition(IState nextState, ITimeController timeController, float delay)
        {
            _timeController = timeController;
            _nextState = nextState;
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

        IState ITransition.GetNextState()
        {
            return _nextState;
        }

        private void OnUpdate()
        {
            _elapsed += _timeController.DeltaTime;
        }
    }
}