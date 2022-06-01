namespace GBAsteroids
{
    public readonly struct InfoLog
    {
        private readonly string _name;
        private readonly float _health;
        private readonly float _speed;

        public string Name => _name;

        public float Health => _health;

        public float Speed => _speed;

        public InfoLog(string name, float health, float speed)
        {
            _name = name;
            _health = health;
            _speed = speed;
        }
    }
}
