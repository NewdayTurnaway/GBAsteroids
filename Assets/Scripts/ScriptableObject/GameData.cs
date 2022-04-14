using System.IO;
using UnityEngine;

namespace GBAsteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/Data")]
    public sealed class GameData : ScriptableObject
    {
        [Tooltip("Название для PlayerData в Resources")]
        [SerializeField] private string _playerDataPath;
        [Tooltip("Название для PlayerWeaponData в Resources")]
        [SerializeField] private string _playerWeaponPath;
        private PlayerData _player;
        private PlayerWeaponData _playerWeapon;

        public PlayerData Player 
        { 
            get 
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>(Path.Combine("Data", _playerDataPath));
                }
                return _player; 
            } 
        }

        public PlayerWeaponData PlayerWeapon 
        {
            get 
            {
                if (_playerWeapon == null)
                {
                    _playerWeapon = Load<PlayerWeaponData>(Path.Combine("Data", _playerWeaponPath));
                }
                return _playerWeapon; 
            }
        }

        private T Load<T>(string resourcesPath) where T : Object
        {
            return Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        }
    }
}