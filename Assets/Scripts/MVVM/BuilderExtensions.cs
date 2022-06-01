using UnityEngine;

namespace GBSnakeMVVM
{
    public static partial class BuilderExtensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject SetActiveExtensions(this GameObject gameObject, bool isActive, bool isHideInHierarchy = false)
        {
            gameObject.SetActive(isActive);
            if (isHideInHierarchy)
            {
                gameObject.hideFlags = HideFlags.HideInHierarchy;
            }
            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject, bool isTrigger, float sizeX, float sizeY)
        {
            BoxCollider2D component = gameObject.GetOrAddComponent<BoxCollider2D>();
            component.isTrigger = isTrigger;
            component.size = new Vector2(sizeX, sizeY);
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