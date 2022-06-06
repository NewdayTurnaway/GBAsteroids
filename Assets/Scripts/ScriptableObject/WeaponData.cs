using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GBAsteroids
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "GameData/WeaponData")]
    public sealed class WeaponData : ScriptableObject
    {
        [Serializable]
        private struct WaeponInfo
        {
            [SerializeField] private WeaponType _type;
            [SerializeField] private Sprite _sprite;
            [SerializeField] private float _damage;
            [SerializeField] private float _shotForce;
            [SerializeField] private float _timeToDestroy;

            public WeaponType Type => _type;
            public Sprite Sprite => _sprite;
            public float Damage => _damage;
            public float ShotForce => _shotForce;
            public float TimeToDestroy => _timeToDestroy;
        }

        [SerializeField] private List<WaeponInfo> _weaponInfos;

        internal WeaponModel GetWeaponModel(WeaponType type)
        {
            WaeponInfo weaponInfo = _weaponInfos.FirstOrDefault(info => info.Type == type);
            if (weaponInfo.Sprite == null)
            {
                throw new InvalidOperationException($"Sprite для оружия типа {type} не найден");
            }
            return new(weaponInfo.Sprite, weaponInfo.Damage, weaponInfo.ShotForce, weaponInfo.TimeToDestroy);
        }
    }
}