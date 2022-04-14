using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GBAsteroids
{
    internal sealed class ProjectilePool
    {
        private readonly Dictionary<WeaponType, HashSet<Ammunition>> _projectilePool;
        private readonly Ammunition _prefabAmmunition;
        private readonly int _capacityPool;
        private readonly Transform _rootPool;

        public ProjectilePool(Ammunition prefabAmmunition, int capacityPool)
        {
            _prefabAmmunition = prefabAmmunition;
            _projectilePool = new();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameConstants.POOL_PROJECTILE).transform;
            }
        }

        public Ammunition GetAmmunition(WeaponType type)
        {
            Ammunition result;

            switch (type)
            {
                case WeaponType.Bullet:
                    result = GetProjectile(GetListAmmunition(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return result;
        }

        private HashSet<Ammunition> GetListAmmunition(WeaponType type)
        {
            return _projectilePool.ContainsKey(type) ? _projectilePool[type] : _projectilePool[type] = new(); 
        }

        private Ammunition GetProjectile(HashSet<Ammunition> ammunitions)
        {
            Ammunition projectile = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (projectile == null)
            {
                for (int i = 0; i < _capacityPool; i++)
                {
                    Ammunition instantiate = GameObject.Instantiate(_prefabAmmunition);
                    ReturnToPool(instantiate.transform);
                    ammunitions.Add(instantiate);
                }

                GetProjectile(ammunitions);
            }
            projectile = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            return projectile;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector2.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            GameObject.Destroy(_rootPool.gameObject);
        }
    }
}