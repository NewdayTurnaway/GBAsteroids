using UnityEngine;

namespace GBAsteroids
{
    internal sealed class MoveRigitbody : IMove
    {
        private readonly Rigidbody2D _rigidbody2D;
        private Vector2 _direction;

        public float Speed { get; private set; }

        public MoveRigitbody(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical)
        {
            _direction.Set(horizontal, vertical);

            if (_direction.magnitude > 1f)
            {
                _direction.Normalize();
            }

            _rigidbody2D.AddForce(_direction * Speed);
        }
    }
}