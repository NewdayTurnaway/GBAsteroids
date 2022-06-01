using System.Collections.Generic;

namespace GBAsteroids
{
    public sealed class CompositeMove : IMove
    {
        private readonly List<IEnemy> _enemies = new();

        public float Speed { get; }

        public void AddUnit(IEnemy unit)
        {
            _enemies.Add(unit);
        }

        public void RemoveUnit(IEnemy unit)
        {
            _enemies.Remove(unit);
        }

        public void Move(float horizontal, float vertical)
        {
            for (var i = 0; i < _enemies.Count; i++)
            {
                MoveRigitbodyFollow follow = new(_enemies[i].GetPlayerRigidbody2D(), _enemies[i].GetPlayerTransform().localPosition, _enemies[i].Speed, _enemies[i].StopDistance);
                follow.Move(horizontal, vertical);
            }
        }
    }
}