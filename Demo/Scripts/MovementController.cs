using UnityEngine;

namespace FiniteStateMachine.Demo.Scripts
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody m_rigidbody;
        [SerializeField] private float m_baseSpeed;

        private Vector3 _movementBuffer;
        private float _speedMultiplier = 1f;

        private void FixedUpdate()
        {
            var speed = m_baseSpeed * _speedMultiplier;
            m_rigidbody.MovePosition(m_rigidbody.position + (_movementBuffer * speed));

            _movementBuffer = Vector3.zero;
        }

        public void Move(Vector2 movement)
        {
            _movementBuffer += new Vector3(movement.x, 0f, movement.y);
        }

        public void AddVelocity(Vector3 velocity)
        {
            m_rigidbody.velocity += velocity;
        }

        public void SetSpeedMultiplier(float multiplier)
        {
            _speedMultiplier = multiplier;
        }
    }
}
