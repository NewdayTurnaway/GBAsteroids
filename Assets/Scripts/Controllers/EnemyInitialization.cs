using System.Collections.Generic;

namespace GBAsteroids
{
    internal sealed class EnemyInitialization : IInitialization
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly CompositeMove _compositeMove;
        private readonly List<IEnemy> _enemies;

        public EnemyInitialization(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _compositeMove = new();
            IEnemy enemy = _enemyFactory.CreateEnemy(EnemyType.Small);
            _compositeMove.AddUnit(enemy);
            _enemies = new List<IEnemy>
            {
                enemy
            };
        }

        public void Initialization()
        {
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