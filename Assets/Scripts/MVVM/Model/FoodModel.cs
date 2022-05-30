namespace GBSnakeMVVM
{
    internal sealed class FoodModel : IFoodModel
    {
        public AreaSpawn AreaSpawn { get; }

        public float SpeedIncrease { get; }

        public FoodModel(AreaSpawn areaSpawn, float speedIncrease)
        {
            AreaSpawn = areaSpawn;
            SpeedIncrease = speedIncrease;
        }
    }
}
