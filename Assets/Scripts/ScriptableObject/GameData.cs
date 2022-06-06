using System.IO;
using UnityEngine;

namespace GBAsteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/Data")]
    public sealed class GameData : ScriptableObject
    {
        [Tooltip("Название для PlayerData в Resources")]
        [SerializeField] private string _playerDataPath;
        [Tooltip("Название для WeaponData в Resources")]
        [SerializeField] private string _weaponPath;
        [Tooltip("Название для EnemyData в Resources")]
        [SerializeField] private string _enemyDataPath;
        private PlayerData _player;
        private WeaponData _weaponData;
        private EnemyData _enemyData;
        private const string DATA = "Data";

        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>(Path.Combine(DATA, _playerDataPath));
                }
                return _player;
            }
        }

        public WeaponData WeaponData
        {
            get
            {
                if (_weaponData == null)
                {
                    _weaponData = Load<WeaponData>(Path.Combine(DATA, _weaponPath));
                }
                return _weaponData;
            }
        }

        public EnemyData EnemyData
        {
            get
            {
                if (_enemyData == null)
                {
                    _enemyData = Load<EnemyData>(Path.Combine(DATA, _enemyDataPath));
                }
                return _enemyData;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object
        {
            return Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        }
    }
}