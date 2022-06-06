using System.IO;
using UnityEngine;

namespace GBAsteroids
{
    public class DataSaveLoad<T>
    {
        private readonly IData<T> _data;
        private const string DATA = "Scripts\\UnitTest";
        private const string FILE_NAME = "UnitData.txt";
        private readonly string _path;
        private readonly string _fullPath;

        public DataSaveLoad()
        {
            _data = new JsonData<T>();
            _path = Path.Combine(Application.dataPath, DATA);
            _fullPath = Path.Combine(_path, FILE_NAME);
        }

        public void Save(T toSave)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            _data.Save(toSave, _fullPath);
        }


        public T Load()
        {
            if (!File.Exists(_fullPath))
            {
                return default;
            }

            return _data.Load(_fullPath);
        }

        public T[] LoadWithJsonHelper()
        {
            if (!File.Exists(_fullPath))
            {
                return default;
            }

            return _data.LoadWithJsonHelper(_fullPath);
        }
    }
}