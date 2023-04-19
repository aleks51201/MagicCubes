using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class StartButtonClickHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartButtonComponent> _clickFilter;
        private readonly EcsFilter<StartButtonClickEvent> _clickEventFilter;
        private readonly EcsFilter<StartMenuLevelChooseScreenComponent> _lvlChooseScreenFilter;


        public void Run()
        {
            foreach (var indexi in _clickEventFilter)
            {
                foreach (var index in _clickFilter)
                {
                    if (!_clickFilter.Get1(index).ButtonStatusHolder.IsClicked)
                    {
                        continue;
                    }
                    _clickFilter.Get1(index).Button.style.display = DisplayStyle.None;
                    _clickFilter.Get1(index).ButtonStatusHolder.StatusReset();
                    _lvlChooseScreenFilter.GetEntity(index).Get<StartButtonClickedEvent>();
                }
                _clickEventFilter.GetEntity(indexi).Del<StartButtonClickEvent>();
            }
        }
    }
}
