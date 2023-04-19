using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Config;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class lvlChooseScreenInitStartSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<StartButtonClickedEvent, StartMenuLevelChooseScreenComponent> _clickedFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly Configurations _configurations = null;

        private const string levelContainer = "unity-content-container";

        public void Run()
        {
            foreach (var index in _clickedFilter)
            {

                ref var lvlScreen = ref _clickedFilter.Get2(index).LvlChooseScreen;
                lvlScreen.style.display = DisplayStyle.Flex;
                foreach (var item in _configurations.LvlHolderConfig.SceneNames)
                {
                    TemplateContainer container = _uiFilter.Get1(index).LevelElement.Instantiate();
                    lvlScreen.Q(levelContainer).Add(container);
                    var lvlElement = new LevelElementComponent()
                    {
                        LvlElement = container,
                        SceneName = item
                    };
                    _world.NewEntity().Get<LevelElementComponent>() = lvlElement;
                }
            }
        }
    }
}
