using System.IO;
using UnityEngine;

namespace GBAsteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "GameData/Data")]
    public sealed class GameData : ScriptableObject
    {
        [Tooltip("Название для PlayerData в Resources")]
        [SerializeField] private string _playerDataPath;
        private PlayerData _player;

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

        private T Load<T>(string resourcesPath) where T : Object
        {
            return Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        }
    }
}