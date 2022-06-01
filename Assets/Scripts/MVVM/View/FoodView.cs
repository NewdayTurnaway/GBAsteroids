using UnityEngine;

namespace GBSnakeMVVM
{
    public class FoodView : MonoBehaviour, IFoodView
    {
        private IFoodViewModel _viewModel;
        private ISnakeViewModel _snakeViewModel;

        public IViewModel ViewModel => _viewModel;

        public void Initialize(IFoodViewModel viewModel, ISnakeViewModel snakeViewModel)
        {
            _viewModel = viewModel;
            _snakeViewModel = snakeViewModel;
            _snakeViewModel.OnReset += Reset;
            _viewModel.RandomizePosition(transform);
        }

        private void Reset()
        {
            _viewModel.RandomizePosition(transform);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<ISnakeView>(out _))
            {
                _viewModel.RandomizePosition(transform);
                _snakeViewModel.EatFood(_viewModel.Model.SpeedIncrease);
            }
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _snakeViewModel.OnReset -= Reset;
        }
    }
}
