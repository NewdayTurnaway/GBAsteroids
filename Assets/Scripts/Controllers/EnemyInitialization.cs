using System.Collections.Generic;

namespace GBAsteroids
{
    internal sealed class EnemyInitialization : IInitialization
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly CompositeMove _compositeMove;
        private List<IEnemy> _enemies;

        public EnemyInitialization(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _compositeMove = new();
            AddEnemy(EnemyType.Small);
        }

        public void Initialization()
        {
        }

        public void AddEnemy(EnemyType type)
        {
            IEnemy enemy = _enemyFactory.CreateEnemy(type);
            _compositeMove.AddUnit(enemy);
            _enemies = new List<IEnemy>
            {
                enemy
            };
        }

        public IMove GetMoveEnemies()
        {
            return _compositeMove;
        }

        public IEnumerable<IEnemy> GetEnemies()
        {
            foreach (IEnemy enemy in _enemies)
            {
                yield return enemy;
            }
        }
    }
}