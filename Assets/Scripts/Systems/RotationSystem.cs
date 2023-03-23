using Leopotam.Ecs;
using UnityEngine;

namespace MagicCubes.Cube
{
    sealed class RotationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CubeTag, RotationableCubeComponent, NeighborsComponent, RotateEvent> _rotationFilte = null;


        public void Run()
        {
            foreach (var item in _rotationFilte)
            {
                ref var entity =ref  _rotationFilte.GetEntity(item);
                var transform = entity.Get<InitComponent>().cubeView.transform;
                ref var rotation = ref _rotationFilte.Get2(item).rotation;
                ref var neighbors = ref _rotationFilte.Get3(item).neighborsCubes;

                transform.Rotate(new Vector3(0, rotation, 0));
                foreach (CubeView cube in neighbors)
                {
                    if(cube is null)
                    {
                        break;
                    }
                    cube.transform.Rotate(new Vector3(0, rotation, 0));
                }

                entity.Del<RotateEvent>();
            }
        }
    }
}
