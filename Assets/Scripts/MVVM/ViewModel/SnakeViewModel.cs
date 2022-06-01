using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBSnakeMVVM
{
    internal sealed class SnakeViewModel : ISnakeViewModel, IExecute
    {
        private Transform _transform;
        private float _inputHorizontal;
        private SnakeMove _snakeMove;
        private readonly List<Transform> _segments = new();
        private readonly List<Vector2> _positions = new();
        private float _distance;
        private float _startingSpeed;

        public event Action<List<Transform>, List<Vector2>> ChangeSize;
        public event Action OnReset;

        public ISnakeModel Model { get; }

        public SnakeViewModel(ISnakeModel model)
        {
            Model = model;
        }

        public void InitializeViewModel(Transform transform)
        {
            _transform = transform;
            _startingSpeed = Model.Speed;
            _snakeMove = new(_transform, Model.Speed, Model.RotationSpeed);
            _positions.Add(_transform.position);
        }

        public void Execute()
        {
            _inputHorizontal = Input.GetAxis(Constants.HORIZONTAL);
            _snakeMove.Move(_inputHorizontal);

            Tail();
        }

        private void Tail()
        {
            _distance = ((Vector2)_transform.position - _positions[0]).magnitude;

            if (_distance > Model.OffsetTail)
            {
                _positions.Insert(0, _transform.position);
                _positions.RemoveAt(_positions.Count - 1);

                _distance -= Model.OffsetTail;
            }

            for (int i = 0; i < _segments.Count; i++)
            {
                _segments[i].position = Vector2.Lerp(_positions[i + 1], _positions[i], _distance / Model.OffsetTail);
            }
        }

        public void Reset()
        {
            for (int i = 0; i < _segments.Count; i++)
            {
                UnityEngine.Object.Destroy(_segments[i].gameObject);
            }
            _segments.Clear();
            _positions.Clear();
            _positions.Add(_transform.position);
            _transform.position = Vector3.zero;
            Model.Speed = _startingSpeed;
            OnReset?.Invoke();
        }

        public void EatFood(float speedIncrease)
        {
            ChangeSize?.Invoke(_segments, _positions);
            Model.Speed += speedIncrease;
            _snakeMove = new(_transform, Model.Speed, Model.RotationSpeed);
        }
    }
}
