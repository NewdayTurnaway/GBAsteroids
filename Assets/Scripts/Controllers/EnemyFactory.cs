using UnityEngine;

namespace GBAsteroids
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyData _enemyData;

        public EnemyFactory(EnemyData data)
        {
            _enemyData = data;
        }

        public IEnemy CreateEnemy(EnemyType type)
        {
            Enemy enemy = _enemyData.GetEnemy(type);
            return Object.Instantiate(enemy);
        }
    }
}