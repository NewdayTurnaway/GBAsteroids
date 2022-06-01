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
            _player.position = new Vector3(0, -10, 0);
            _playerRigidbody2D = _player.gameObject.GetComponent<Rigidbody2D>();
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