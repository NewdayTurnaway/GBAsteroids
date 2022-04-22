using UnityEngine;

namespace GBAsteroids
{
    internal sealed class ShootProjectile : IWeapon
    {
        private readonly ProjectilePool _projectilePool;
        private readonly PlayerWeaponModel _playerWeaponModel;
        private readonly Transform _transformBarrel;

        public float ShotForce { get; private set; }
        public ShootProjectile(PlayerWeaponModel playerWeaponModel, Transform transformBarrel)
        {
            _playerWeaponModel = playerWeaponModel;
            _projectilePool = new(_playerWeaponModel.PrefabAmmunition, 8);
            _transformBarrel = transformBarrel;
            ShotForce = _playerWeaponModel.ShotForce;
        }

        public void Shoot()
        {
            if (Input.GetButtonDown(InputConstants.FIRE1))
            {
                Ammunition bullet = _projectilePool.GetAmmunition(_playerWeaponModel.WeaponType);
                bullet.SetAmmunitionFields(_playerWeaponModel);
                bullet.ActiveAmmunition(_transformBarrel.position, _transformBarrel.rotation);
                bullet.GetAmmunitionRigidbody2D().AddForce(_transformBarrel.up * ShotForce);
            }
        }
    }
}