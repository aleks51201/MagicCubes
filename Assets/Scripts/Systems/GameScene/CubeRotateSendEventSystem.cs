using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Events;
using MagicCubes.Tag;

namespace MagicCubes.Systems
{
    sealed class CubeRotateSendEventSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CubeTag, RotationableCubeComponent> _cubeFilter = null;


        public void Run()
        {
            foreach (var item in _cubeFilter)
            {
                ref var entity = ref _cubeFilter.GetEntity(item);
                entity.Get<RotateEvent>();
            }
        }
    }
}
