namespace GBAsteroids
{
    internal sealed class AddPlayerHealthModifier : PlayerModifier
    {
        private readonly float _maxHealth;
        private readonly float _increaseHealth;

        public AddPlayerHealthModifier(PlayerModel playerModel, float maxHealth, float increaseHealth) : base(playerModel)
        {
            _maxHealth = maxHealth;
            _increaseHealth = increaseHealth;
        }

        public override void Handle()
        {
            if (_playerModel.Health <= _maxHealth)
            {
                _playerModel.Health += _increaseHealth;
            }

            base.Handle();
        }
    }
}