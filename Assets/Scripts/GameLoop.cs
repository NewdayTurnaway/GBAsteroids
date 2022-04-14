using UnityEngine;

namespace GBAsteroids
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private Controllers _controllers;

        private void Awake()
        {
            _controllers = new();
            new GameInitialization(_controllers, _gameData);
            _controllers.Initialization();
        }

        private void Update()
        {
            _controllers.Execute();
        }
    }
}