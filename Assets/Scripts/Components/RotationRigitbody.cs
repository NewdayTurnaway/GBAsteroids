using UnityEngine;

namespace GBAsteroids
{
    internal sealed class RotationRigitbody : IRotation
    {
        private readonly Rigidbody2D _rigidbody2D;
        private float _turnDirection;
        public float TurnSpeed { get; private set; }

        public RotationRigitbody(Rigidbody2D rigidbody2D, float turnSpeed)
        {
            _rigidbody2D = rigidbody2D;
            TurnSpeed = turnSpeed;
        }

        public void Rotation(float horizontal)
        {
            _turnDirection = horizontal == 0 ? 0 : Mathf.Sign(horizontal);

            if (_turnDirection != 0)
            {
                _rigidbody2D.AddTorque(-_turnDirection * TurnSpeed);
            }
        }
    }
}