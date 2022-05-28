using System;
using System.Collections;
using System.Collections.Generic;
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