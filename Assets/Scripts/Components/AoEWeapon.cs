using UnityEngine;

namespace GBAsteroids
{
    public class AoEWeapon : IWeapon
    {
        private readonly float _aoERadius;
        private readonly float _aoEForce;
        private readonly Transform _weaponPosition;

        public AoEWeapon(float aoERadius, float aoEForce, Transform weaponPosition)
        {
            _aoERadius = aoERadius;
            _aoEForce = aoEForce;
            _weaponPosition = weaponPosition;
        }

        public float ShotForce { get; private set; }

        public void Shoot()
        {
            if (Input.GetButtonDown(InputConstants.FIRE2))
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(_weaponPosition.position, _aoERadius);
                foreach (Collider2D collider in colliders)
                {
                    collider.attachedRigidbody.AddExplosionForce(_aoEForce, _weaponPosition.position, _aoERadius);
                }
            }
        }
    }
}