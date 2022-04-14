using UnityEngine;

namespace GBAsteroids
{
    internal sealed class PlayerWeaponModel
    {
        public WeaponType WeaponType;
        public Ammunition PrefabAmmunition;
        public float Damage;
        public float ShotForce;
        public float TimeToDestroy;

        public PlayerWeaponModel(WeaponType weaponType, Ammunition prefabAmmunition, float damage, float shotForce, float timeToDestroy)
        {
            WeaponType = weaponType;
            PrefabAmmunition = prefabAmmunition;
            Damage = damage;
            ShotForce = shotForce;
            TimeToDestroy = timeToDestroy;
        }
    }
}