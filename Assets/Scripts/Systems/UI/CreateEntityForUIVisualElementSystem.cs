using Leopotam.Ecs;
using MagicCubes.Ui;
using UnityEngine.UIElements;

namespace Systems.UI
{
    public class CreateEntityForUIVisualElementSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<UIInitComponent> _initFilter = null;

        private const string UIHolder = "UIHolder";
        private const string StartButton = "StartButton";


        public void Init()
        {
            InitStartButton();
        }

        private void InitStartButton()
        {
            ref var uiInitComponent = ref _initFilter.Get1(0);
            var startButton = uiInitComponent.UIDocument.rootVisualElement.Q<Button>(StartButton);
            StartButtonComponent btnComponent = new()
            {
                Button = startButton
            };
            _world.NewEntity().Get<StartButtonComponent>() = btnComponent;
        }
    }
}
