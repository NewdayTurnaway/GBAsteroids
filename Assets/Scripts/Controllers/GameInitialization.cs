namespace GBAsteroids
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, GameData gameData)
        {
            PlayerModel playerModel = new(gameData.Player.Sprite, gameData.Player.Health, gameData.Player.Speed, gameData.Player.TurnSpeed);
            PlayerWeaponModel playerWeaponModel = new(gameData.PlayerWeapon.WeaponType, gameData.PlayerWeapon.PrefabAmmunition, gameData.PlayerWeapon.Damage, gameData.PlayerWeapon.ShotForce, gameData.PlayerWeapon.TimeToDestroy);
            PlayerCreation playerCreation = new(playerModel);
            PlayerInitialization playerInitialization = new(playerCreation);
            EnemyFactory enemyFactory = new(gameData.EnemyData);
            EnemyInitialization enemyInitialization = new(enemyFactory);
            controllers.Add(playerInitialization);
            controllers.Add(enemyInitialization);
            controllers.Add(new PlayerController(playerModel, playerWeaponModel, playerInitialization.GetPlayerTransform(), playerInitialization.GetPlayerRigidbody2D()));
            controllers.Add(new EnemyController(enemyInitialization.GetMoveEnemies(), playerInitialization.GetPlayerTransform()));
        }
    }
}