using UnityEngine;

namespace GBAsteroids
{
    public sealed class ProjectileCreation : IProjectileCreate
    {
        private readonly WeaponData _weaponData;

        public ProjectileCreation(WeaponData weaponData)
        {
            _weaponData = weaponData;
        }

        public Ammunition CreateProjectile(WeaponType type)
        {
            WeaponModel weaponModel = _weaponData.GetWeaponModel(type);
            Ammunition instantiate = new GameObject()
                        .SetName(NameConstants.PROJECTILE)
                        .AddRigidbody2D(0f)
                        .AddSprite(weaponModel.Sprite, Color.red)
                        .AddBoxCollider2D(false)
                        .AddComponent<Bullet>();
            instantiate.SetAmmunitionFields(weaponModel);
            return instantiate;
        }
    }
}