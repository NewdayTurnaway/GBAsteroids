using UnityEngine;

namespace GBSnakeMVVM
{
    internal sealed class SnakeModel : ISnakeModel
    {
        public GameObject SnakeSegment { get; }
        public float Speed { get; set; }
        public float RotationSpeed { get; }
        public float OffsetTail { get; }

        public SnakeModel(GameObject snakeSegment, float speed, float rotationSpeed, float offsetTail)
        {
            SnakeSegment = snakeSegment;
            Speed = speed;
            RotationSpeed = rotationSpeed;
            OffsetTail = offsetTail;
        }
    }
}
