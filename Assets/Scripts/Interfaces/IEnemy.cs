using System;
using UnityEngine;

namespace GBAsteroids
{
    public interface IEnemy : IMove
    {
        event Action<IEnemy, Collision2D> OnCollisionEnterChange;
        event Action ChangeScore;
        float Health { get; set; }
        float StopDistance { get; }

        void Death();
        Transform GetPlayerTransform();
        Rigidbody2D GetPlayerRigidbody2D();
        void Log(IVisit visit);

    }
}