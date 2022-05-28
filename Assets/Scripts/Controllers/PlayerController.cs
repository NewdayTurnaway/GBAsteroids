using UnityEngine;

namespace GBAsteroids
{
    internal sealed class PlayerController : IExecute
    {
        private float _inputHorizontal;
        private float _inputVertical;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly Transform _transformBarrel;
        private readonly Ship _ship;

        public PlayerController(PlayerModel playerModel, ProjectileCreation projectileCreation, Transform transformBarrel, Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
            _transformBarrel = transformBarrel;
            MoveRigitbody moveRigitbody = new(_rigidbody2D, playerModel.Speed);
            RotationRigitbody rotationRigitbody = new(_rigidbody2D, playerModel.TurnSpeed);
            ShootProjectile shootProjectile = new(projectileCreation, _transformBarrel);
            _ship = new(moveRigitbody, rotationRigitbody, shootProjectile);
        }

        public void Execute()
        {
            _inputHorizontal = Input.GetAxis(InputConstants.HORIZONTAL);
            _inputVertical = Input.GetAxis(InputConstants.VERTICAL);
            _ship.Move(_inputHorizontal, _inputVertical);
            _ship.Rotation(_inputHorizontal);
            _ship.Shoot();
        }
    }
}