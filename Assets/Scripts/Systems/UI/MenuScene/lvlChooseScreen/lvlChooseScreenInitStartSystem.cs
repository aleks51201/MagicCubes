using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Components.Ui.Save;
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
        private readonly EcsFilter<SavesComponent> _savesFilter;
        private readonly Configurations _configurations = null;

        private const string levelContainer = "unity-content-container";
        private const string LevelButton = "LevelButton";
        private const string StarsHolder = "StarsHolder";

        public void Run()
        {
            foreach (var index in _clickedFilter)
            {

                ref var lvlScreen = ref _clickedFilter.Get2(index).LvlChooseScreen;
                lvlScreen.style.display = DisplayStyle.Flex;
                int id = 0;
                foreach (var j in _savesFilter)
                {
                    ref SavesComponent savesComponent = ref _savesFilter.Get1(j);
                    foreach (var lvl in savesComponent.Levls)
                    {
                        VisualElement container = _uiFilter.Get1(index).LevelElement.Instantiate();
                        container.Q<Button>(LevelButton).text = $"{id + 1}";
                        SpawnStars(container, lvl.Stars);
                        lvlScreen.Q(levelContainer).Add(container);
                        var lvlElement = new LevelElementComponent()
                        {
                            LvlElement = container,
                            SceneName = lvl.SceneName,
                            Id = id
                        };
                        _world.NewEntity().Get<LevelElementComponent>() = lvlElement;
                        id++;
                    }
                }
            }
        }
        private void SpawnStars(VisualElement container, int countStars)
        {
            VisualElement starsHolder = container.Q(StarsHolder);
            for (int i = 0; i <= countStars; i++)
            {
                if (i == 0) continue;
                VisualElement newStar = new();
                newStar.style.backgroundImage = _configurations.TextureHolder.ObtainedStar;
                newStar.style.width = 100;
                newStar.style.height = 100;
                newStar.style.visibility = Visibility.Visible;
                starsHolder.Add(newStar);
            }
        }
    }
}
