using System.Collections.Generic;

namespace GBAsteroids
{
    internal sealed class EnemyInitialization : IInitialization
    {
        private readonly IEnemyFactory _enemyFactory;
        private readonly CompositeMove _compositeMove;
        private readonly List<IEnemy> _enemies = new();

        public EnemyInitialization(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _compositeMove = new();
            AddEnemy(EnemyType.Small);
            AddEnemy(EnemyType.Big);
        }

        public void Initialization()
        {
        }

        public void AddEnemy(EnemyType type)
        {
            IEnemy enemy = _enemyFactory.CreateEnemy(type);
            _compositeMove.AddUnit(enemy);
            _enemies.Add(enemy);
        }

        public void RemoveEnemy(IEnemy enemy)
        {
            _compositeMove.RemoveUnit(enemy);
            _enemies.Remove(enemy);
        }

        public IMove GetMoveEnemies()
        {
            return _compositeMove;
        }

        public List<IEnemy> GetEnemies()
        {
            return _enemies;
        }
    }
}