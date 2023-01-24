using System;
using StateMachineSystem.Runtime.States;
using StateMachineSystem.Runtime.Transitions;
using UnityEngine;

namespace StateMachineSystem.Demo.Scripts
{
    public class CustomState : IState
    {
        ITransition[] IState.GetTransitions() => Array.Empty<ITransition>();

        void IState.OnEnter()
        {
            Debug.Log("Entered Custom State");
        }

        void IState.OnUpdate(float deltaTime)
        {
            Debug.Log("Updated Custom State");
        }

        void IState.OnFixedUpdate(float fixedDeltaTime)
        {
            Debug.Log("Fixed Updated Custom State");
        }

        void IState.OnExit()
        {
            Debug.Log("Exited Custom State");
        }
    }
}