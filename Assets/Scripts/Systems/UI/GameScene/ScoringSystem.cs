using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Components.Ui;
using MagicCubes.Events;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class ScoringSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RotateEvent> _rotateFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string RotationsCount = "RotationsCount";

        private int _rotateCount = 0;

        public void Run()
        {
            foreach (var index in _rotateFilter)
            {
                _rotateCount++;
                _uiFilter.Get1(index).UIDocument.rootVisualElement.Q<Label>(RotationsCount).text = $"Rotations: {_rotateCount}";
            }
        }
    }
}
