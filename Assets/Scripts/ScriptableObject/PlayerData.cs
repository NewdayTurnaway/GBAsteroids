using UnityEngine;

namespace GBAsteroids
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "GameData/PlayerData")]
    public sealed class PlayerData : ScriptableObject
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private float _health;
        [SerializeField] private float _speed;
        [SerializeField] private float _turnSpeed;

        public Sprite Sprite => _sprite;
        public float Health => _health;
        public float Speed => _speed;
        public float TurnSpeed => _turnSpeed;
    }
}