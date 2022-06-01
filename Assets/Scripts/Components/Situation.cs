using UnityEngine;

namespace GBAsteroids
{
    internal sealed class Situation
    {
        private State _state;
        private readonly Rigidbody2D _rigidbody2D;

        public Situation(State state, Rigidbody2D rigidbody2D)
        {
            State = state;
            _rigidbody2D = rigidbody2D;
        }

        public State State
        {
            get => _state;
            set
            {
                _state = value;
                Debug.Log($"State: {_state.GetType().Name}");
            }
        }

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public void Request()
        {
            _state.Handle(this);
        }
    }

}