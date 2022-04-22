using UnityEngine;

namespace GBAsteroids
{
    public class EnemyController : IExecute
    {
        private readonly IMove _move;
        private readonly Transform _target;

        public EnemyController(IMove move, Transform target)
        {
            _move = move;
            _target = target;
        }

        public void Execute()
        {
            _move.Move(_target.position.x, _target.position.y);
        }
    }
}