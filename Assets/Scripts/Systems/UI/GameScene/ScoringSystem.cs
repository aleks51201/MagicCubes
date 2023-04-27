﻿using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class ScoringSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RotateEvent> _rotateFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<OpenedWinMenuEvent> _openWinMenuFilter = null;

        private const string RotationsCount = "RotationsCount";

        private int _rotateCount = 0;

        public void Run()
        {
            foreach (var index in _rotateFilter)
            {
                _rotateCount++;
                UpdateRotationsCount();
            }
            foreach (var i in _openWinMenuFilter)
            {
                UpdateRotationsCount();
            }
        }

        private void UpdateRotationsCount()
        {
            foreach (var j in _uiFilter)
            {
                var labels = _uiFilter.Get1(j).UIDocument.rootVisualElement.Query<Label>(RotationsCount).ToList();
                foreach (Label label in labels)
                {
                    label.text = $"Rotations: {_rotateCount}";
                }
            }
        }
    }
}
