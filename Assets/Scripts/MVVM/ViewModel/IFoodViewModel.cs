using UnityEngine;

namespace GBSnakeMVVM
{
    public interface IFoodViewModel : IViewModel<IFoodModel>
    {
        void RandomizePosition(Transform transform);
    }
}