using System.Collections.Generic;
using UnityEngine;

namespace GBAsteroids
{
    internal class EnemyController : IExecute
    {
        private readonly List<IEnemy> _enemies;
        private readonly IMove _move;
        private readonly Transform _target;

        public EnemyController(EnemyInitialization enemyInitialization, Transform target)
        {
            _enemies = enemyInitialization.GetEnemies();
            _move = enemyInitialization.GetMoveEnemies();
            _target = target;

            ConnectListener(enemyInitialization);
        }

        private void ConnectListener(EnemyInitialization enemyInitialization)
        {
            ListenerCollisionEnter listenerCollision = new(enemyInitialization);

            for (var i = 0; i < _enemies.Count; i++)
            {
                listenerCollision.Add(_enemies[i]);
            }
        }

        public void Execute()
        {
            _move.Move(_target.position.x, _target.position.y);
        }
    }
}