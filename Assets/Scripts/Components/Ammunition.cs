using UnityEngine;

namespace GBAsteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Ammunition : MonoBehaviour
    {
        [SerializeField] private WeaponType _weaponType;
        [SerializeField] private float _damage;
        [SerializeField] private float _shotForce;
        [SerializeField] private float _timeToDestroy;
        private Rigidbody2D _rigidbody2D;
        private Transform _rootPool;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 0f;
        }

        private void OnBecameInvisible()
        {
            if (gameObject.activeSelf)
            {
                ReturnToPool();
            }
        }

        internal void SetAmmunitionFields(PlayerWeaponModel playerWeaponModel)
        {
            _weaponType = playerWeaponModel.WeaponType;
            _damage = playerWeaponModel.Damage;
            _shotForce = playerWeaponModel.ShotForce;
            _timeToDestroy = playerWeaponModel.TimeToDestroy;
        }

        public Rigidbody2D GetAmmunitionRigidbody2D()
        {
            return _rigidbody2D;
        }

        public Transform RootPool
        {
            get
            {
                if (_rootPool == null)
                {
                    var find = GameObject.Find(NameConstants.POOL_PROJECTILE);
                    _rootPool = find == null ? null : find.transform;
                }

                return _rootPool;
            }
        }

        public void ActiveAmmunition(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            Invoke(nameof(ReturnToPool), _timeToDestroy);
            transform.SetParent(null);
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector2.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            CancelInvoke(nameof(ReturnToPool));
            transform.SetParent(RootPool);

            if (!RootPool)
            {
                Destroy(gameObject);
            }
        }
    }
}