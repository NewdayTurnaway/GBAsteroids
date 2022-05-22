using System.Collections;
using System.Collections.Generic;
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
            Vector3 position = shootProjectile.GetTransformBarrel().position;
            position.y += _positionOffset;
            aim.AddSprite(Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 3, 3), position), Color.yellow);
            aim.transform.SetParent(shootProjectile.GetTransformBarrel());
            return shootProjectile;
        }
    }
}