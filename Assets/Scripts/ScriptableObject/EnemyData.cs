using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace GBAsteroids
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "GameData/EnemyData")]
    public sealed class EnemyData : ScriptableObject
    {
        [Serializable]
        private struct EnemyInfo
        {
            public EnemyType Type;
            public Enemy EnemyPrefab;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public Enemy GetEnemy(EnemyType type)
        {
            EnemyInfo enemyInfo = _enemyInfos.FirstOrDefault(info => info.Type == type);
            if (enemyInfo.EnemyPrefab == null)
            {
                throw new InvalidOperationException($"Противник типа {type} не найден");
            }
            return enemyInfo.EnemyPrefab;
        }
    }
}