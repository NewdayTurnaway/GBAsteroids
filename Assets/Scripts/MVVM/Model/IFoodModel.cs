namespace GBSnakeMVVM
{
    [System.Serializable]
    public struct AreaSpawn
    {
        public float XMin;
        public float XMax;
        public float YMin;
        public float YMax;
    }

    public interface IFoodModel : IModel
    {
        AreaSpawn AreaSpawn { get; }
        float SpeedIncrease { get; }
    }
}
