using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Components.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class OpenPauseMenuSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputComponent> _inputFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string ButtonsUIHolder = "ButtonsUIHolder";

        private bool _oneClick;

        public void Run()
        {
            foreach (var index in _inputFilter)
            {
                OnEscapeButtonDown(index);
                OnEscapeButtonUp(index);
            }
        }

        private void OnEscapeButtonDown(int index)
        {
            if (!_inputFilter.Get1(index).EscapeButtonDown || _oneClick)
            {
                return;
            }
            var displayStyle = _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(ButtonsUIHolder).style.display;
            if (displayStyle == DisplayStyle.Flex)
            {
                _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(ButtonsUIHolder).style.display = DisplayStyle.None;
            }
            else
            {
                _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(ButtonsUIHolder).style.display = DisplayStyle.Flex;
            }
            _oneClick = true;
        }

        private void OnEscapeButtonUp(int index)
        {
            if (!_inputFilter.Get1(index).EscapeButtonUp || !_oneClick)
            {
                return;
            }
            _oneClick = false;
        }
    }
}
