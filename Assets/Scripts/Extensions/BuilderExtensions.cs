using UnityEngine;

namespace GBAsteroids
{
    public static partial class BuilderExtensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<Rigidbody2D>();
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float gravityScale)
        {
            Rigidbody2D component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.gravityScale = gravityScale;
            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject, bool isTrigger)
        {
            BoxCollider2D component = gameObject.GetOrAddComponent<BoxCollider2D>();
            component.isTrigger = isTrigger;
            return gameObject;
        }
        
        public static GameObject AddPolygonCollider2D(this GameObject gameObject, bool isTrigger)
        {
            PolygonCollider2D component = gameObject.GetOrAddComponent<PolygonCollider2D>();
            component.isTrigger = isTrigger;
            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            SpriteRenderer component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }
        
        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite , Color color)
        {
            SpriteRenderer component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            component.color = color;
            return gameObject;
        }

        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}