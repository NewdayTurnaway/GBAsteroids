namespace GBAsteroids
{
    internal abstract class ModificationShootProjectile : IWeapon
    {
        private ShootProjectile _shootProjectile;
        public float ShotForce { get; private set; }

        protected abstract ShootProjectile AddModification(ShootProjectile shootProjectile);

        public void ApplyModification(ShootProjectile shootProjectile)
        {
            _shootProjectile = AddModification(shootProjectile);
        }

        public void Shoot()
        {
            _shootProjectile.Shoot();
        }
    }
}