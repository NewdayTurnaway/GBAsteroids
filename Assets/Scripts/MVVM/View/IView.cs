namespace GBSnakeMVVM
{
    public interface IView
    {
        IViewModel ViewModel { get; }
        void Activate();
        void Deactivate();
    } 

    public interface IView<in T>: IView where T : IViewModel
    {
        void Initialize(T viewModel);
    }

    public interface IView<in T1, in T2> : IView where T1 : IViewModel where T2 : IViewModel
    {
        void Initialize(T1 viewModel, T2 secondViewModel);
    }
}
