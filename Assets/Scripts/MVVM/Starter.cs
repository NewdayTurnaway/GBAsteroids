using UnityEngine;

namespace GBSnakeMVVM
{
    internal sealed class Starter : MonoBehaviour
    {
        private SnakeModel _snakeModel;
        private SnakeViewModel _snakeViewModel;
        private SnakeView _snakeView;

        private FoodModel _foodModel;
        private FoodViewModel _foodViewModel;
        private FoodView _foodView;

        private GameObject _snakeSegment;

        [Header("Snake")]
        [SerializeField]
        private float _speed = 5f;
        [SerializeField]
        private float _rotationSpeed = 200f;
        [SerializeField]
        private float _offsetTail = 1.1f;

        [Header("Food")]
        [SerializeField]
        private float _speedIncrease = 0.5f;
        [SerializeField]
        private AreaSpawn areaSpawn;

        private void Awake()
        {
            _snakeSegment = new GameObject()
                .SetName(Constants.SNAKE_SEGMENT)
                .AddSprite(Sprite.Create(Texture2D.whiteTexture, new Rect(0, 0, 4, 4), new Vector2(0.5f, 0.5f), 4), new Color(0.2f, 0.75f, 0.5f))
                .AddBoxCollider2D(true, 0.8f, 0.8f)
                .SetActiveExtensions(false, true);
            _snakeModel = new(_snakeSegment, _speed, _rotationSpeed, _offsetTail);
            _snakeViewModel = new(_snakeModel);

            _foodModel = new(areaSpawn, _speedIncrease);
            _foodViewModel = new(_foodModel);

            _snakeView = Resources.FindObjectsOfTypeAll<SnakeView>()[0];
            _foodView = Resources.FindObjectsOfTypeAll<FoodView>()[0];

            _snakeView.Activate();
            _snakeView.Initialize(_snakeViewModel);
            _foodView.Activate();
            _foodView.Initialize(_foodViewModel, _snakeViewModel);
        }

        private void Update()
        {
            _snakeViewModel.Execute();
        }
    } 
}
