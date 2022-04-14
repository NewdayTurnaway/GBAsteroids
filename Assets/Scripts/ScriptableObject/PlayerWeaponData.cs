using UnityEngine;

namespace GBAsteroids
{
    [CreateAssetMenu(fileName = "PlayerWeaponData", menuName = "GameData/PlayerWeaponData")]
    public sealed class PlayerWeaponData : ScriptableObject
    {
        [SerializeField] private WeaponType _weaponType;
        [Tooltip("Префабы с классами наследниками класса Ammunition")]
        [SerializeField] private Ammunition _prefabAmmunition;
        [SerializeField] private float _damage;
        [SerializeField] private float _shotForce;
        [SerializeField] private float _timeToDestroy;

        public WeaponType WeaponType => _weaponType;
        public Ammunition PrefabAmmunition => _prefabAmmunition;
        public float Damage => _damage;
        public float ShotForce => _shotForce;
        public float TimeToDestroy => _timeToDestroy;
    }
}