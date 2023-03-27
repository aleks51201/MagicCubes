using Leopotam.Ecs;
using UnityEngine;

namespace MagicCubes.Cube
{
    sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CubeTag, RotationableCubeComponent, NeighborsComponent, RotateEvent> _rotationFilter = null;
        private readonly EcsFilter<CubeTag> _cubeFilter = null;


        public void Run()
        {
            int count = _rotationFilter.GetEntitiesCount();
            foreach (var item in _rotationFilter)
            {
                ref var entity = ref _rotationFilter.GetEntity(item);
                var transform = entity.Get<InitComponent>().cubeView.transform;
                ref var rotation = ref _rotationFilter.Get2(item).rotation;
                ref var neighbors = ref _rotationFilter.Get3(item).neighborsCubes;

                transform.Rotate(new Vector3(0, rotation, 0));
                foreach (CubeView cube in neighbors)
                {
                    if (cube is null)
                    {
                        break;
                    }
                    cube.transform.Rotate(new Vector3(0, rotation, 0));
                }
                entity.Del<RotateEvent>();
            }
            if (count > 0)
            {
                foreach(var index in _cubeFilter)
                {
                    ref var entity = ref _cubeFilter.GetEntity(index);
                    entity.Get<EndRotateEvent>();
                }
            }
        }
    }
}
