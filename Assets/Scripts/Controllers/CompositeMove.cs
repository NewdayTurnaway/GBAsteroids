using System.Collections.Generic;

namespace GBAsteroids
{
    public sealed class CompositeMove : IMove
    {
        private readonly List<IMove> _moves = new();

        public float Speed { get; }

        public void AddUnit(IMove unit)
        {
            _moves.Add(unit);
        }

        public void RemoveUnit(IMove unit)
        {
            _moves.Remove(unit);
        }

        public void Move(float horizontal, float vertical)
        {
            for (var i = 0; i < _moves.Count; i++)
            {
                _moves[i].Move(horizontal, vertical);
            }
        }
    }
}