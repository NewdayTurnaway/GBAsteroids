namespace GBAsteroids
{
    public interface IData<T>
    {
        void Save(T data, string path = null);

        T Load(string path = null);

        T[] LoadWithJsonHelper(string path = null);
    }
}