using UnityEngine;
namespace GBAsteroids
{
    internal sealed class ModificationAim : ModificationShootProjectile
    {
        private readonly float _positionOffset;

        public ModificationAim(float positionOffset)
        {
            _positionOffset = positionOffset;
        }

        protected override ShootProjectile AddModification(ShootProjectile shootProjectile)
        {
            GameObject aim = new();
            aim.AddSprite(Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 3, 3), Vector2.zero), Color.yellow);
            aim.transform.position = new Vector3(0, _positionOffset);
            aim.transform.SetParent(shootProjectile.GetTransformBarrel(), false);
            return shootProjectile;
        }
    }
}