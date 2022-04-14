using UnityEngine;

namespace GBAsteroids
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private readonly PlayerCreation _playerCreation;
        private readonly Transform _player;
        private readonly Rigidbody2D _playerRigidbody2D;

        public PlayerInitialization(PlayerCreation playerCreation)
        {
            _playerCreation = playerCreation;
            _player = _playerCreation.CreateGameObject();
            _player.position = Vector3.zero;
            _playerRigidbody2D = _player.gameObject.GetComponent<Rigidbody2D>();
            _playerRigidbody2D.gravityScale = 0f;
        }
        public void Initialization()
        {
        }

        public Transform GetPlayerTransform()
        {
            return _player;
        }

        public Rigidbody2D GetPlayerRigidbody2D()
        {
            return _playerRigidbody2D;
        }
    }
}