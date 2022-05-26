using TMPro;
using UnityEngine;

namespace GBAsteroids
{
    internal sealed class ScoreUI : BaseUI
    {
        public int score;
        
        private TextMeshProUGUI _textScore;
        
        public TextMeshProUGUI TextScore { get => _textScore; set => _textScore = value; }

        public ScoreUI(GameObject panel) : base(panel)
        {
            TextScore = _panel.GetComponent<TextMeshProUGUI>();
        }

        public void AddScore()
        {
            score++;
        }

        public override void Disable()
        {
            _panel.SetActive(false);
        }

        public override void Execute()
        {
            _panel.SetActive(true);
        }
    }
}