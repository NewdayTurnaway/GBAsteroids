namespace GBSnakeMVVM
{
    public interface IViewModel
    {
    }

    public interface IViewModel<out T> : IViewModel where T : IModel
    {
        T Model { get; }
    }
}
