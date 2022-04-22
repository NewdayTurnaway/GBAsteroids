namespace GBAsteroids
{
    public interface IWeapon
    {
        float ShotForce { get; }
        void Shoot();
    }
}