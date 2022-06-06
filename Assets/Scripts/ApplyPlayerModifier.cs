namespace GBAsteroids
{
    internal sealed class ApplyPlayerModifier
    {
        private readonly PlayerModel _playerModel;

        public ApplyPlayerModifier(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            PlayerModifier playerModifier = new(_playerModel);
            playerModifier.Add(new AddPlayerHealthModifier(_playerModel, 150, 50));
            playerModifier.Add(new AddPlayerSpeedModifier(_playerModel, 0.8f, 0.05f));
            playerModifier.Handle();
        }
    }
}