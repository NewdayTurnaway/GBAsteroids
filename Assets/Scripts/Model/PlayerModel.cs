using UnityEngine;

namespace GBAsteroids
{
    internal sealed class PlayerModel
    {
        public Sprite Sprite;
        public float Health;
        public float Speed;
        public float TurnSpeed;

        public PlayerModel(Sprite sprite, float health, float speed, float turnSpeed)
        {
            Sprite = sprite;
            Health = health;
            Speed = speed;
            TurnSpeed = turnSpeed;
        }
    }
}