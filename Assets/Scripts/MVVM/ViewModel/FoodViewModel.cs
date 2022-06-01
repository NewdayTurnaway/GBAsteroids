using UnityEngine;

namespace GBSnakeMVVM
{
    public class FoodViewModel : IFoodViewModel
    {
        public IFoodModel Model { get; set; }

        public FoodViewModel(IFoodModel model)
        {
            Model = model;
        }

        public void RandomizePosition(Transform transform)
        {
            float x = Random.Range(Model.AreaSpawn.XMin, Model.AreaSpawn.XMax);
            float y = Random.Range(Model.AreaSpawn.YMin, Model.AreaSpawn.YMax);

            transform.position = new Vector3(x, y, 0f);
        }
    }
}
