using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;

namespace MagicCubes.Systems.UI
{
    public sealed class NextLvlButtonUnregisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<NextLvlButtonComponent> _nextLvlBtnFilter = null;
        private readonly EcsFilter<ClosedWinMenuEvent> _closedWinMenuFilter = null;


        public void Run()
        {
            foreach (var index in _closedWinMenuFilter)
            {
                Unregister(index);
            }
        }

        private void Unregister(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                foreach (var i in _nextLvlBtnFilter)
                {
                    var backBtnComponent = _nextLvlBtnFilter.Get1(i);
                    backBtnComponent.ButtonEventProceeder.UnsubscribeAll();
                    _nextLvlBtnFilter.GetEntity(i).Destroy();
                }
            }
        }
    }
}
