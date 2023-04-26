﻿using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events;
using UnityEngine.UIElements;

namespace MagicCubes.Systems
{
    sealed class WinSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WinEvent> _winFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string ButtonsUIHolder = "ButtonsUIHolder";
        private const string OnWinMenu = "OnWinMenu";

        public void Run()
        {
            foreach (var i in _uiFilter)
            {
                VisualElement winPanel = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(OnWinMenu);
                VisualElement btnUiHolder = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ButtonsUIHolder);
                foreach (var index in _winFilter)
                {
                    btnUiHolder.style.display = DisplayStyle.Flex;
                    winPanel.style.display = DisplayStyle.Flex;
                }
            }
        }
    }
}
