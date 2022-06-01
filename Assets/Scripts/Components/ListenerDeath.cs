namespace GBAsteroids
{
    internal sealed class ListenerDeath
    {
        private readonly ScoreUI _scoreUI;

        public ListenerDeath(ScoreUI scoreUI)
        {
            _scoreUI = scoreUI;
        }

        public void Add(IEnemy enemy)
        {
            enemy.ChangeScore += AddScore;
        }

        public void Remove(IEnemy enemy)
        {
            enemy.ChangeScore -= AddScore;
        }

        private void AddScore()
        {
            _scoreUI.Score += 1000;
            _scoreUI.TextScore.text = UIConstants.SCORE + Interpreter.ScoreInterpreter(_scoreUI.Score);
        }
    }
}