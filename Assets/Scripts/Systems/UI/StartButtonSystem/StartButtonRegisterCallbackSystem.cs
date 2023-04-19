using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;

namespace MagicCubes.Systems.UI
{
    public sealed class StartButtonRegisterCallbackSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<StartButtonComponent> _startButtonFilter = null;


        public void Init()
        {
            foreach (var index in _startButtonFilter)
            {
                ref var startBtnComponent = ref _startButtonFilter.Get1(index);
                _startButtonFilter.Get1(index).Button.clicked += startBtnComponent.ButtonStatusHolder.OnClicked;
                _startButtonFilter.Get1(index).Button.clicked += OnClick;
            }
        }

        private void OnClick()
        {
            _world.NewEntity().Get<StartButtonClickEvent>();
        }
    }
}
