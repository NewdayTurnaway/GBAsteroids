using System;
using System.Collections.Generic;
using UnityEngine;

namespace GBSnakeMVVM
{
    public interface ISnakeViewModel : IViewModel<ISnakeModel>
    {
        event Action<List<Transform>, List<Vector2>> ChangeSize;
        event Action OnReset;
        void InitializeViewModel(Transform transform);
        void Reset();
        void EatFood(float speedIncrease);
    } 
}
