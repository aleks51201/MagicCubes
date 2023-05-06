using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Config;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class InitGameSceneUISystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
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
