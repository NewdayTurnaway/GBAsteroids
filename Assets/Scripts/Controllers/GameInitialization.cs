namespace GBAsteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, GameData gameData)
        {
            ServiceLocatorMono.GetService<Bullet>();
            PlayerModel playerModel = new(gameData.Player.Sprite, gameData.Player.Health, gameData.Player.Speed, gameData.Player.TurnSpeed);
            new ApplyPlayerModifier(playerModel);
            PlayerCreation playerCreation = new(playerModel);
            PlayerInitialization playerInitialization = new(playerCreation);
            EnemyFactory enemyFactory = new(gameData.EnemyData);
            EnemyInitialization enemyInitialization = new(enemyFactory);
            ProjectileCreation projectileCreation = new(gameData.WeaponData);
            UIController uIController = new(playerModel, enemyInitialization.GetEnemies());
            controllers.Add(uIController);
            controllers.Add(playerInitialization);
            controllers.Add(enemyInitialization);
            controllers.Add(new PlayerController(playerModel, projectileCreation, playerInitialization.GetPlayerTransform(), playerInitialization.GetPlayerRigidbody2D()));
            controllers.Add(new EnemyController(enemyInitialization, playerInitialization.GetPlayerTransform()));
        }
    }
}