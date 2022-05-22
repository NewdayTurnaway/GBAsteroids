using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBAsteroids
{
    public class TestUnitFileParser : MonoBehaviour
    {
        private List<Unit> _units;
        private DataSaveLoad<Root> _saver;

        void Awake()
        {
            _saver = new DataSaveLoad<Root>();
            _units = new List<Unit>();

            foreach (var root in _saver.LoadWithJsonHelper())
            {
                _units.Add(root.unit);
            }
            foreach (var unit in _units)
            {
                Debug.Log(unit.ToString());
            }
        }

        [Serializable]
        public class Root
        {
            public Unit unit;
        }
    }
}