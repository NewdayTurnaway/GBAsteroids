using System.Collections.Generic;
using UnityEngine;

namespace GBAsteroids
{
    public abstract class DictionaryInspector<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TKey> _keys = new();

        [SerializeField]
        private List<TValue> _values = new();

        public void OnAfterDeserialize()
        {
            Clear();
            for (int i = 0; i < _keys.Count && i < _values.Count; i++)
            {
                this[_keys[i]] = _values[i];
            }
        }

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (KeyValuePair<TKey, TValue> item in this)
            {
                _keys.Add(item.Key);
                _values.Add(item.Value);
            }
        }
    }
}