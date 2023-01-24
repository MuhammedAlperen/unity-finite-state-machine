using StateMachineSystem.Runtime.States;
using UnityEngine;

namespace StateMachineSystem.Demo.Scripts
{
    public class TestStateMachine : MonoBehaviour
    {
        private StateController m_controller;

        private void Awake()
        {
            m_controller = new StateController(new CustomState());
        }

        private void Start()
        {
            m_controller.Enter();
        }

        private void OnDestroy()
        {
            m_controller.Exit();
        }

        private void Update()
        {
            m_controller.Update(Time.deltaTime);
        }
        
        private void FixedUpdate()
        {
            m_controller.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}
