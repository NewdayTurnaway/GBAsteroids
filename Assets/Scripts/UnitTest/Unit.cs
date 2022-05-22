using System;

namespace GBAsteroids
{
    [Serializable]
    public sealed class Unit
    {
        public string type;
        public int health;

        public override string ToString() => $"Юнит. Тип: {type} | Здоровье: {health}";
    }
}