using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;

namespace MagicCubes.Systems.UI
{
    public sealed class ResumeButtonUnregisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<ResumeButtonComponent> _resumeBtnFilter = null;
        private readonly EcsFilter<ClosedPauseMenuEvent> _closedPauseMenuFilter = null;


        public void Run()
        {
            foreach (var index in _closedPauseMenuFilter)
            {
                Unregister(index);
            }
        }

        private void Unregister(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                foreach (var i in _resumeBtnFilter)
                {
                    var resumeBtnComponent = _resumeBtnFilter.Get1(i);
                    resumeBtnComponent.ButtonEventProceeder.UnsubscribeAll();
                    _resumeBtnFilter.GetEntity(i).Destroy();
                }
            }
        }
    }
}
