using FiniteStateMachine.Demo.Scripts.CustomConditions;
using FiniteStateMachine.Demo.Scripts.CustomStates;
using FiniteStateMachine.Demo.Scripts.InputSystem;
using FiniteStateMachine.Runtime.Conditions;
using FiniteStateMachine.Runtime.States;
using FiniteStateMachine.Runtime.Transitions;
using UnityEngine;
using Utils.Runtime.TimeSystem;

namespace FiniteStateMachine.Demo.Scripts
{
    public class TestStateMachine : MonoBehaviour
    {
        private StateController _controller;

        private void Awake()
        {
            var inputController = new UnityInputController();
            var movementController = GetComponent<MovementController>();

            var idleState = new IdleState();
            var walkState = new WalkState(movementController, inputController);
            var jumpState = new JumpState(movementController, 5f);
            var crouchState = new CrouchState(movementController);

            idleState.SetTransitions(new []
            {
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Move) }, walkState),
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Jump) }, jumpState),
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Crouch) }, crouchState),
            });

            walkState.SetTransitions(new []
            {
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Jump) }, jumpState),
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Crouch) }, crouchState),
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Move, inverted: true) }, idleState),
            });

            const float jumpDuration = 1f;
            var delayCondition = new DelayCondition(jumpState, UnityTimeManager.Instance, jumpDuration);
            jumpState.SetTransitions(new []
            {
                new ConditionedTransition(new ICondition[] { delayCondition, new InputCondition(inputController, InputCondition.InputType.Move, inverted: false) }, walkState),
                new ConditionedTransition(new ICondition[] { delayCondition, new InputCondition(inputController, InputCondition.InputType.Move, inverted: true) }, idleState),
            });

            crouchState.SetTransitions(new []
            {
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Move, inverted: false) }, walkState),
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Move, inverted: true) }, idleState),
                new ConditionedTransition(new ICondition[] { new InputCondition(inputController, InputCondition.InputType.Jump) }, jumpState),
            });

            _controller = new StateController(idleState);
        }

        private void Start()
        {
            _controller.Enter();
        }

        private void OnDestroy()
        {
            _controller.Exit();
        }

        private void Update()
        {
            _controller.Update(Time.deltaTime);
        }
        
        private void FixedUpdate()
        {
            _controller.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}
