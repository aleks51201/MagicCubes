using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Components.Ui;
using MagicCubes.Events;
using UnityEngine;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class InitGameSceneUISystem : IEcsInitSystem
    {
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string GameUI = "GameUI";

        public void Init()
        {
            foreach (var index in _uiFilter)
            {
                VisualElement visualElement = _uiFilter.Get1(index).UIDocument.rootVisualElement;
                visualElement.Q(GameUI).style.display = DisplayStyle.Flex;
            }
        }
    }
}
