using System;
using UnityEngine;

namespace GBAsteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PolygonCollider2D))]
    public sealed class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<IEnemy, Collision2D> OnCollisionEnterChange;
        public event Action ChangeScore;
        [SerializeField] private float _stopDistance;
        [SerializeField] private float _health = 100f;
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody2D;

        public float Speed => _speed;
        public float Health { get => _health; set => _health = value; }
        public float StopDistance => _stopDistance;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 0f;
        }

        public void Move(float horizontal, float vertical)
        {
        }

        public Transform GetPlayerTransform()
        {
            return transform;
        }

        public Rigidbody2D GetPlayerRigidbody2D()
        {
            return _rigidbody2D;
        }

        public void Death()
        {
            ChangeScore?.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEnterChange?.Invoke(this, collision);
        }

        private void OnEnable()
        {
            Log(new ConsoleDisplay());
        }

        public void Log(IVisit visit)
        {
            visit.Visit(this, new InfoLog(name, Health, Speed));
        }
    }
}