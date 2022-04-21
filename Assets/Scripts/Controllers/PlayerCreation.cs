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
            return new GameObject().SetName(NameConstants.PLAYER)
                .AddRigidbody2D(0f)
                .AddSprite(_playerModel.Sprite)
                .AddPolygonCollider2D(true)
                .transform;
        }
    }
}