using System;
using UnityEngine;

namespace GBAsteroids
{
    [Serializable]
    public class DictionaryStringInt : DictionaryInspector<string, int> { }

    public class TestDictionaryOnInspector : MonoBehaviour
    {
        public DictionaryStringInt keys;
    }
}