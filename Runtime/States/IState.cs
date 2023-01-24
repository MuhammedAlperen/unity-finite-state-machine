using StateMachineSystem.Runtime.Transitions;

namespace StateMachineSystem.Runtime.States
{
    public interface IState
    {
        protected internal ITransition[] GetTransitions();

        protected internal void OnEnter() { }
        protected internal void OnUpdate(float deltaTime) { }
        protected internal void OnFixedUpdate(float fixedDeltaTime) { }
        protected internal void OnExit() { }
    }
}
