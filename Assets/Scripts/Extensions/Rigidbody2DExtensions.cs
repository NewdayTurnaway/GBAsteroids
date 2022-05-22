using UnityEngine;

namespace GBAsteroids
{
    public static partial class Rigidbody2DExtensions
    {
        public static void AddExplosionForce(this Rigidbody2D rigidbody2D, float explosionForce, Vector3 explosionPosition, float explosionRadius)
        {
            Vector3 direction = rigidbody2D.transform.position - explosionPosition;
            float wearoff = 1 - (direction.magnitude / explosionRadius);
            rigidbody2D.AddForce(explosionForce * wearoff * direction.normalized);
        }

        public static void AddExplosionForce(this Rigidbody2D rigidbody2D, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier)
        {
            Vector3 direction = (rigidbody2D.transform.position - explosionPosition);
            float wearoff = 1 - (direction.magnitude / explosionRadius);
            Vector3 baseForce = explosionForce * wearoff * direction.normalized;
            rigidbody2D.AddForce(baseForce);

            float upliftWearoff = 1 - upliftModifier / explosionRadius;
            Vector3 upliftForce = explosionForce * upliftWearoff * Vector2.up;
            rigidbody2D.AddForce(upliftForce);
        }
    }
}