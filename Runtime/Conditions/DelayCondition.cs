using FiniteStateMachine.Runtime.States;
using Utils.Runtime.TimeSystem;

namespace FiniteStateMachine.Runtime.Conditions
{
    public class DelayCondition : ICondition
    {
        private readonly ITimeController _timeController;
        private readonly IState _sourceState;
        private readonly float _delay;
        private float _elapsed;

        public DelayCondition(IState sourceState, ITimeController timeController, float delay)
        {
            _timeController = timeController;
            _sourceState = sourceState;
            _delay = delay;
   
            _sourceState.OnEntered += BeginDelay;
            _sourceState.OnExited += EndDelay;
        }

        ~DelayCondition()
        {
            _sourceState.OnEntered -= BeginDelay;
            _sourceState.OnExited -= EndDelay;
        }

        public bool IsMet()
        {
            return _elapsed >= _delay;
        }

        private void BeginDelay()
        {
            _timeController.OnUpdate += OnUpdate;
            _elapsed = 0f;
        }

        private void EndDelay()
        {
            _timeController.OnUpdate -= OnUpdate;
        }

        private void OnUpdate()
        {
            _elapsed += _timeController.DeltaTime;
        }
    }
}