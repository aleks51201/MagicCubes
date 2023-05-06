using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace MagicCubes.Components.Ui
{
    internal class ButtonEventProceeder
    {
        private Button _button;
        private List<Action> _actions;


        public ButtonEventProceeder(Button button)
        {
            _button = button;
            _actions = new();
        }


        internal void Subscribe(Action action)
        {
            _button.clicked += action;
            _actions.Add(action);
        }

        internal void Unsubscribe(Action action)
        {
            if (!_actions.Exists(x => x == action))
            {
                return;
            }
            _button.clicked -= action;
            _actions.Remove(action);
        }

        internal void UnsubscribeAll()
        {
            for (var i = _actions.Count - 1; i >= 0; i--)
            {
                Unsubscribe(_actions[i]);
            }
        }
    }
}
