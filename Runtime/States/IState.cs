using System.Collections.Generic;
using FiniteStateMachine.Runtime.Transitions;

namespace FiniteStateMachine.Runtime.States
{
    public delegate void StateDelegate();

    public interface IState
    {
        StateDelegate OnEntered { get; set; }
        StateDelegate OnExited { get; set; }

        protected internal IEnumerable<ITransition> GetTransitions();

        protected internal void Enter()
        {
            OnEnter();
            OnEntered?.Invoke();
        }

        protected internal void Update(float deltaTime)
        {
            OnUpdate(deltaTime);
        }

        protected internal void FixedUpdate(float fixedDeltaTime)
        {
            OnFixedUpdate(fixedDeltaTime);
        }

        protected internal void Exit()
        {
            OnExit();
            OnExited?.Invoke();
        }

        protected internal void OnEnter() { }
        protected internal void OnUpdate(float deltaTime) { }
        protected internal void OnFixedUpdate(float fixedDeltaTime) { }
        protected internal void OnExit() { }
    }
}
