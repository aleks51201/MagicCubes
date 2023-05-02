using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;

namespace MagicCubes.Systems.UI
{
    public sealed class ResetUnregisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<ResetButtonComponent> _resetBtnFilter = null;
        private readonly EcsFilter<ClosedPauseMenuEvent> _closedPauseMenuFilter = null;
        private readonly EcsFilter<ClosedWinMenuEvent> _closedWinMenuFilter = null;


        public void Run()
        {
            foreach (var index in _closedPauseMenuFilter)
            {
                Unregister(index);
            }
            foreach (var index in _closedWinMenuFilter)
            {
                Unregister(index);
            }
        }

        private void Unregister(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                foreach (var i in _resetBtnFilter)
                {
                    var resetComponent = _resetBtnFilter.Get1(i);
                    resetComponent.ButtonEventProceeder.UnsubscribeAll();
                    _resetBtnFilter.GetEntity(i).Destroy();
                }
            }
        }
    }
}
