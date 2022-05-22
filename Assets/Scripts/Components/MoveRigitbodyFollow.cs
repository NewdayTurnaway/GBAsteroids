using UnityEngine;

namespace GBAsteroids
{
    internal sealed class MoveRigitbodyFollow : IMove
    {
        private readonly Rigidbody2D _rigidbody2D;
        private Vector3 _direction;
        private Vector3 _localPosition;
        private readonly float _stopDistance;
        private const float INTERPOLATION_STEP = 0.02f;

        public float Speed { get; private set; }

        public MoveRigitbodyFollow(Rigidbody2D rigidbody2D, Vector3 localPosition, float speed, float stopDistance)
        {
            _rigidbody2D = rigidbody2D;
            _localPosition = localPosition;
            Speed = speed;
            _stopDistance = stopDistance;
        }

        public void Move(float horizontal, float vertical)
        {
            Vector3 targetPosition = new(horizontal, vertical);
            _direction = (targetPosition - _localPosition).normalized;
            if ((_localPosition - targetPosition).sqrMagnitude >= _stopDistance * _stopDistance)
            {

                _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, _direction * Speed, INTERPOLATION_STEP);
            }
            else
            {
                _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, Vector2.zero, INTERPOLATION_STEP);
            }
        }
    }
}