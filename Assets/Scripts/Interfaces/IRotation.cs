namespace GBAsteroids
{
    public interface IRotation
    {
        float TurnSpeed { get; }
        void Rotation(float horizontal);
    }
}