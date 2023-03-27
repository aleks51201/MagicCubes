using Leopotam.Ecs;

namespace MagicCubes.Cube
{
    sealed class WinSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WinEvent> _winFilter = null;
        private readonly EcsFilter<WinPanelComponent> _winPanelFilter = null;

        public void Run()
        {
            foreach (var index in _winFilter)
            {
                var gameObject = _winPanelFilter.Get1(0).winPanel;
                gameObject.SetActive(true);
            }
        }
    }
}
