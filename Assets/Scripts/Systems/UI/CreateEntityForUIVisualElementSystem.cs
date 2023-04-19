using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class CreateEntityForUIVisualElementSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<UIInitComponent> _initFilter = null;

        private const string UIHolder = "LevelChooseScreen";
        private const string StartButton = "StartButton";


        public void Init()
        {
            foreach (var index in _initFilter)
            {
                InitStartButton(index);
                InitUIHolder(index);
            }
        }

        private void InitUIHolder(int index)
        {
            ref var uiInitComponent = ref _initFilter.Get1(index);
            var startMenuUIHolder = uiInitComponent.UIDocument.rootVisualElement.Q(UIHolder);
            var startMenuUIHolderComponent = new StartMenuLevelChooseScreenComponent()
            {
                LvlChooseScreen = startMenuUIHolder
            };
            _world.NewEntity().Get<StartMenuLevelChooseScreenComponent>() = startMenuUIHolderComponent;
        }

        private void InitStartButton(int index)
        {
            ref var uiInitComponent = ref _initFilter.Get1(index);
            var startButton = uiInitComponent.UIDocument.rootVisualElement.Q<Button>(StartButton);
            var btnComponent = new StartButtonComponent()
            {
                Button = startButton,
                ButtonStatusHolder = new()
            };
            _world.NewEntity().Get<StartButtonComponent>() = btnComponent;
        }
    }
}
