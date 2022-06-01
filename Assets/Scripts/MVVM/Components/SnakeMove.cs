using UnityEngine;

namespace GBSnakeMVVM
{
    internal class SnakeMove
    {
        private readonly Transform _transform;
        private readonly float _speed;
        private readonly float _rotationSpeed;

        public SnakeMove(Transform transform, float speed, float rotationSpeed)
        {
            _transform = transform;
            _speed = speed;
            _rotationSpeed = rotationSpeed;
        }

        public void Move(float horizontal)
        {
            _transform.Translate(_speed * Time.deltaTime * Vector2.up, Space.Self);
            _transform.Rotate(_rotationSpeed * -horizontal * Time.deltaTime * Vector3.forward);
        }
    } 
}
