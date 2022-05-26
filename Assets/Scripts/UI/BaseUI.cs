using UnityEngine;

namespace GBAsteroids
{
    public abstract class BaseUI : IExecute
    {
        protected GameObject _panel;

        public BaseUI(GameObject panel) => _panel = panel;

        public abstract void Disable();
        public abstract void Execute();
    }
}