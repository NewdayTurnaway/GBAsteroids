using System;
using UnityEngine;

namespace GBAsteroids
{
    internal sealed class ShootProjectile : IWeapon
    {
        private readonly ProjectilePool _projectilePool;
        private readonly ProjectileCreation _projectileCreation;
        private readonly Transform _transformBarrel;
        private readonly int _length = Enum.GetValues(typeof(WeaponType)).Length;
        private WeaponType _weapon;
        private float _timer;
        private float _wait = 0f;
        private bool _shootStatus = true;

        public float ShotForce { get; private set; }

        public ShootProjectile(ProjectileCreation projectileCreation, Transform transformBarrel)
        {
            _weapon = (WeaponType)1;
            _projectileCreation = projectileCreation;
            _projectilePool = new(_projectileCreation, 8);
            _transformBarrel = transformBarrel;
        }

        public void Shoot()
        {
            CheckShootStatus(ref _shootStatus, ref _timer, _wait);

            if (Input.GetButtonDown(InputConstants.FIRE1))
            {
                if (_shootStatus)
                {
                    Ammunition bullet = _projectilePool.GetAmmunition(_weapon);
                    bullet.ActiveAmmunition(_transformBarrel.position, _transformBarrel.rotation);
                    bullet.GetAmmunitionRigidbody2D().AddForce(_transformBarrel.up * bullet.ShotForce);
                    _wait = (bullet.GetAmmunitionRigidbody2D().mass / bullet.ShotForce);
                    _shootStatus = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _weapon = SwitchWeaponType(_weapon, _length);
            }
        }

        private WeaponType SwitchWeaponType(WeaponType weapon, int length)
        {
            int type = (int)weapon;
            if (type == length - 1)
            {
                return (WeaponType)1;
            }
            type++;
            return (WeaponType)type;
        }

        private void CheckShootStatus(ref bool shootStatus, ref float timer, float wait)
        {
            if (!shootStatus)
            {
                timer += Time.deltaTime;
                if (timer < wait)
                {
                    return;
                }
                shootStatus = true;
                timer = 0;
            }
        }

        public Transform GetTransformBarrel()
        {
            return _transformBarrel;
        }
    }
}