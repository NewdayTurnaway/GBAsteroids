using UnityEngine;

namespace GBAsteroids
{
    internal sealed class ListenerCollisionEnter
    {
        private readonly EnemyInitialization _enemyInitialization;

        public ListenerCollisionEnter(EnemyInitialization enemyInitialization)
        {
            _enemyInitialization = enemyInitialization;
        }

        public void Add(IEnemy enemy)
        {
            enemy.OnCollisionEnterChange += MakeAmmunitionDamage;
        }

        public void Remove(IEnemy enemy)
        {
            enemy.OnCollisionEnterChange -= MakeAmmunitionDamage;
        }

        private void MakeAmmunitionDamage(IEnemy enemy, Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(NameConstants.TAG_AMMUNITION))
            {
                return;
            }

            enemy.Health -= collision.gameObject.GetComponent<Ammunition>().Damage;

            if (enemy.Health <= 0)
            {
                enemy.Death();
                GameObject tempObject = enemy.GetPlayerTransform().gameObject;
                tempObject.SetActive(false);
                //Object.Destroy(tempObject);
                _enemyInitialization.RemoveEnemy(enemy);
                Debug.Log($"Противник {tempObject.name} уничтожен!");
                Remove(enemy);
            }
        }
    }
}