using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GBAsteroids
{
    internal sealed class ScoreUI : BaseUI
    {
        private int _score = 0;

        private TextMeshProUGUI _textScore;

        public TextMeshProUGUI TextScore { get => _textScore; set => _textScore = value; }
        public int Score { get => _score; set => _score = value; }

        public ScoreUI(GameObject panel, List<IEnemy> enemies) : base(panel)
        {
            TextScore = _panel.GetComponent<TextMeshProUGUI>();
            ConnectListener(this, enemies);
        }

        private void ConnectListener(ScoreUI scoreUI, List<IEnemy> enemies)
        {
            ListenerDeath listenerDeath = new(scoreUI);

            for (var i = 0; i < enemies.Count; i++)
            {
                listenerDeath.Add(enemies[i]);
            }
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