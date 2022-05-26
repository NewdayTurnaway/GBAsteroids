using System.Collections.Generic;
using UnityEngine;

namespace GBAsteroids
{
    internal class UIController : IInitialization, IExecute
    {
        private readonly PlayerModel _playerModel;
        private readonly GameObject _uiObject;

        private readonly PlayerInfoUI _infoUI;
        private readonly ScoreUI _scoreUI;

        private readonly Stack<StateUI> _stateUi = new();
        private BaseUI _currentWindow;

        private const string PATH = "Prefabs\\Canvas";

        public UIController(PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _uiObject = Object.Instantiate(Resources.Load<GameObject>(PATH));
            _infoUI = new(_uiObject.transform.GetChild(0).GetChild(0).gameObject);
            _scoreUI = new(_uiObject.transform.GetChild(0).GetChild(1).gameObject);
        }

        public void Initialization()
        {
            _infoUI.TextStats.text = UIConstants.HEATH + _playerModel.Health;
            _scoreUI.TextScore.text = UIConstants.SCORE + 0;
            //_scoreUI.TextScore.text = UIConstants.SCORE + Interpreter.ScoreInterpreter(2100500);
            //_scoreUI.TextScore.text = UIConstants.SCORE + Interpreter.FormulaInterpreter("(10+5-3)/6");
        }

        private void ChangeUI(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Disable();
            }

            switch (stateUI)
            {
                case StateUI.PlayerInfo:
                    _currentWindow = _infoUI;
                    break;

                case StateUI.Score:
                    _currentWindow = _scoreUI;
                    break;

                default:
                    break;
            }

            _currentWindow.Execute();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }

        public void Execute()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeUI(StateUI.PlayerInfo);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeUI(StateUI.Score);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_stateUi.Count > 0)
                {
                    ChangeUI(_stateUi.Pop(), false);
                }
            }
        }
    }
}