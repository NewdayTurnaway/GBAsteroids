using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GBAsteroids
{
    public static partial class ObjectExtensions
    {
        public static T DeepCopy<T>(this T self)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("Тип должен быть сериализуемым");
            }

            if (self is null)
            {
                return default;
            }

            BinaryFormatter formatter = new();
            using MemoryStream stream = new();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }
}