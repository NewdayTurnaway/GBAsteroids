using System;
using UnityEngine;

namespace GBAsteroids
{
    public interface IEnemy : IMove
    {
        public event Action<IEnemy, Collision2D> OnCollisionEnterChange;
        public event Action ChangeScore;
        public float Health { get; set; }
        public float StopDistance { get ; }
        public void Death();
        public Transform GetPlayerTransform();
        public Rigidbody2D GetPlayerRigidbody2D();
    }
}