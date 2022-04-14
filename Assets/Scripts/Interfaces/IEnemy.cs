using System;

namespace GBAsteroids
{
    public interface IEnemy : IMove
    {
        event Action<int> OnTriggerEnterChange;
    }
}