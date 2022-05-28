using System.IO;
using UnityEngine;

namespace GBAsteroids
{
    public class JsonData<T> : IData<T>
    {
        public T Load(string path = null)
        {
            string loadAllText = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(loadAllText);;
        }
        
        public T[] LoadWithJsonHelper(string path = null)
        {
            string loadAllText = File.ReadAllText(path);
            return JsonHelper.GetJsonArray<T>(loadAllText);
        }

        public void Save(T data, string path = null)
        {
            string saveAllText = JsonUtility.ToJson(data);
            File.WriteAllText(path, saveAllText);
        }
    }
}