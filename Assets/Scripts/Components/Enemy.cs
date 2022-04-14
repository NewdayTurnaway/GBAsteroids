using System;
using UnityEngine;

namespace GBAsteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PolygonCollider2D))]
    public sealed class Enemy : MonoBehaviour, IEnemy
    {
        public event Action<int> OnTriggerEnterChange;
        [SerializeField] private float _stopDistance;
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody2D;
        private const float INTERPOLATIONSTEP = 0.02f;

        public float Speed => _speed;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 0f;
        }

        public void Move(float horizontal, float vertical)
        {
            Vector3 playerPosition = new(horizontal, vertical);
            Vector3 direction = (playerPosition - transform.localPosition).normalized;
            if ((transform.localPosition - playerPosition).sqrMagnitude >= _stopDistance * _stopDistance)
            {

                _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, direction * _speed, INTERPOLATIONSTEP);
            }
            else
            {
                _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, Vector2.zero, INTERPOLATIONSTEP);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnTriggerEnterChange?.Invoke(collision.gameObject.GetInstanceID());
        }
    }
}