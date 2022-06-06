using System.Collections.Generic;
using UnityEngine;

namespace GBSnakeMVVM
{
    internal sealed class SnakeView : MonoBehaviour, ISnakeView
    {
        private ISnakeViewModel _viewModel;

        public IViewModel ViewModel => _viewModel;

        public void Initialize(ISnakeViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.InitializeViewModel(transform);
            _viewModel.ChangeSize += Grow;
        }

        private void Grow(List<Transform> segments, List<Vector2> positions)
        {
            Transform segment = Instantiate(_viewModel.Model.SnakeSegment.transform,
                positions[^1],
                Quaternion.identity,
                transform);
            segment.localRotation = new(0f, 0f, 0f, 0f);
            segment.gameObject.SetActive(true);

            segments.Add(segment);
            positions.Add(segment.position);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(Constants.TAG_OBSTACLE))
            {
                _viewModel.Reset();
            }
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            _viewModel.ChangeSize -= Grow;
        }
    }
}
