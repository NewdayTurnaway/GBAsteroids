using UnityEngine;

namespace GBAsteroids
{
    internal sealed class WeaponModel
    {
        public Sprite Sprite;
        public float Damage;
        public float ShotForce;
        public float TimeToDestroy;

        public WeaponModel(Sprite sprite, float damage, float shotForce, float timeToDestroy)
        {
            Sprite = sprite;
            Damage = damage;
            ShotForce = shotForce;
            TimeToDestroy = timeToDestroy;
        }
    }
}