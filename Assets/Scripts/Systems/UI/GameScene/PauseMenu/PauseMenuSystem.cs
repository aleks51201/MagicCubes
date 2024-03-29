﻿using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class PauseMenuSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<InputComponent> _inputFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string ButtonsUIHolder = "ButtonsUIHolder";
        private const string OnPauseMenu = "OnPauseMenu";
        private const string GameUI = "GameUI";

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
                ChangeDisplayStatus(index, ButtonsUIHolder, DisplayStyle.None);
                ChangeDisplayStatus(index, OnPauseMenu, DisplayStyle.None);
                ChangeDisplayStatus(index, GameUI, DisplayStyle.Flex);
                _ecsWorld.NewEntity().Get<ClosedPauseMenuEvent>();
            }
            else
            {
                ChangeDisplayStatus(index, ButtonsUIHolder, DisplayStyle.Flex);
                ChangeDisplayStatus(index, OnPauseMenu, DisplayStyle.Flex);
                ChangeDisplayStatus(index, GameUI, DisplayStyle.None);
                _ecsWorld.NewEntity().Get<OpenedPauseMenuEvent>();
            }
            _oneClick = true;
        }

        private void ChangeDisplayStatus(int index, string name, DisplayStyle displayStyle)
        {
            _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(name).style.display = displayStyle;
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
