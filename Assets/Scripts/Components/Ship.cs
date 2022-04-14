namespace GBAsteroids
{
    public class Ship : IMove, IRotation, IWeapon
    {
        private readonly IMove _move;
        private readonly IRotation _rotation;
        private readonly IWeapon _weapon;

        public float Speed => _move.Speed;
        public float TurnSpeed => _rotation.TurnSpeed;
        public float ShotForce => _weapon.ShotForce;

        public Ship(IMove move, IRotation rotation, IWeapon weapon)
        {
            _move = move;
            _rotation = rotation;
            _weapon = weapon;
        }

        public void Move(float horizontal, float vertical)
        {
            _move.Move(horizontal, vertical);
        }

        public void Rotation(float horizontal)
        {
            _rotation.Rotation(horizontal);
        }

        public void Shoot()
        {
            _weapon.Shoot();
        }
    }
}