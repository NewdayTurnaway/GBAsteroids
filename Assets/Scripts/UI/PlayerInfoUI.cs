using TMPro;
using UnityEngine;

namespace GBAsteroids
{
    internal sealed class PlayerInfoUI : BaseUI
    {
        private TextMeshProUGUI _textStats;
        public TextMeshProUGUI TextStats { get => _textStats; set => _textStats = value; }

        public PlayerInfoUI(GameObject panel) : base (panel)
        {
            TextStats = _panel.GetComponent<TextMeshProUGUI>();
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