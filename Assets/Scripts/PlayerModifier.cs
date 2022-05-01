namespace GBAsteroids
{
    internal class PlayerModifier
    {
        protected PlayerModel _playerModel;
        protected PlayerModifier Next;

        public PlayerModifier(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Add(PlayerModifier playerModifier)
        {
            if(Next != null)
            {
                Next.Add(playerModifier);
            }
            else
            {
                Next = playerModifier;
            }
        }

        public virtual void Handle() => Next?.Handle();

    }
}