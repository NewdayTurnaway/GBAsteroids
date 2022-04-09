namespace GBAsteroids
{
    public class Ship : IMove, IRotation
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;

        public float Speed => _move.Speed;
        public float TurnSpeed => _rotation.TurnSpeed;

        public Ship(IMove move, IRotation rotation)
        {
            _move = move;
            _rotation = rotation;
        }

        public void Move(float horizontal, float vertical)
        {
            _move.Move(horizontal, vertical);
        }

        public void Rotation(float horizontal)
        {
            _rotation.Rotation(horizontal);
        }
    }
}