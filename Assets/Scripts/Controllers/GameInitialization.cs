using UnityEngine;

namespace GBAsteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, GameData gameData)
        {
            PlayerModel playerModel = new(gameData.Player.Sprite, gameData.Player.Health, gameData.Player.Speed, gameData.Player.TurnSpeed);
            PlayerCreation playerCreation = new(playerModel);
            PlayerInitialization playerInitialization = new(playerCreation);
            controllers.Add(playerInitialization);
            controllers.Add(new PlayerController(playerModel, playerInitialization.GetPlayerRigidbody2D()));
        }
    }
}