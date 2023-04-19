using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public class StartButtonClickHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartButtonClickEvent, StartButtonComponent> _clickFilter;
        private readonly EcsFilter<StartMenuLevelChooseScreenComponent> _lvlChooseScreenFilter;


        public void Run()
        {
            foreach (var index in _clickFilter)
            {
                _clickFilter.Get2(index).Button.style.display = DisplayStyle.None;
                _clickFilter.GetEntity(index).Del<StartButtonClickEvent>();
                _lvlChooseScreenFilter.GetEntity(index).Get<StartButtonClickedEvent>();
            }
        }
    }
}
