using UnityEngine;

namespace GBAsteroids
{
    public sealed class ConsoleDisplay : IVisit
    {
        public void Visit(IEnemy enemy, InfoLog infoLog)
        {
            Debug.Log($"Имя: {infoLog.Name} | Здоровье: {infoLog.Health} | Скорость: {infoLog.Speed}");
        }
    }
}
