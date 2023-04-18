using Leopotam.Ecs;
using MagicCubes.Ui;
using UnityEngine.UIElements;

namespace Systems.UI
{
    public class StartButtonClickHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartButtonClickEvent, StartButtonComponent> _clickFilter;
        private readonly EcsFilter<StartMenuLevelChooseScreenComponent> _lvlChooseScreenFilter;


        public void Run()
        {
            foreach (var index in _clickFilter)
            {
                foreach (var indexJ in _lvlChooseScreenFilter)
                {
                    ref var lvlScreen = ref _lvlChooseScreenFilter.Get1(indexJ).LvlChooseScreen;
                    lvlScreen.style.display = DisplayStyle.Flex;
                }
                _clickFilter.Get2(index).Button.style.display = DisplayStyle.None;
                _clickFilter.GetEntity(index).Del<StartButtonClickEvent>();
            }
        }
    }
}
