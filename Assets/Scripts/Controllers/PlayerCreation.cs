using UnityEngine;

namespace GBAsteroids
{
    internal sealed class PlayerCreation : ICreateGameObject
    {
        private readonly PlayerModel _playerModel;

        public PlayerCreation(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public Transform CreateGameObject()
        {
            GameObject temp = new("Player");
            temp.AddComponent<SpriteRenderer>().sprite = _playerModel.Sprite;
            temp.AddComponent<Rigidbody2D>();
            return temp.transform;
        }
    }
}