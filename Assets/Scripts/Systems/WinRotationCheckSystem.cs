using Leopotam.Ecs;
using System.Collections.Generic;

namespace MagicCubes.Cube
{
    sealed class WinRotationCheckSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CubeTag, EndRotateEvent> _cubeFilter = null;

        public void Run()
        {
            List<InitComponent> winComonents = new();
            int entityCount = _cubeFilter.GetEntitiesCount();
            foreach (var index in _cubeFilter)
            {
                ref var entity = ref _cubeFilter.GetEntity(index);
                var transform = entity.Get<InitComponent>().cubeView.transform;
                ref var winYRotaion = ref entity.Get<InitComponent>().winYRotation;

                if (transform.rotation.y == winYRotaion)
                {
                    winComonents.Add(entity.Get<InitComponent>());
                    entity.Del<EndRotateEvent>();
                }
            }
            if (winComonents.Count == entityCount && entityCount > 0)
            {
                var newEntity = _world.NewEntity();
                ref var winCubesComponent = ref newEntity.Get<WinCubesComponent>();
                winCubesComponent.winCubes = winComonents;
                newEntity.Get<WinEvent>();
            }
        }
    }
}
