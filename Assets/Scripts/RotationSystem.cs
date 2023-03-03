using Leopotam.Ecs;
using UnityEngine;

namespace MagicCubes.Cube
{
    sealed class RotationSystem : IEcsRunSystem
    {
        private EcsFilter<TransformComponent, RotationableCubeComponent> _rotationFilte = null;


        public void Run()
        {
            foreach (var item in _rotationFilte)
            {
                ref var transform = ref _rotationFilte.Get1(item).transform;
                ref var rotation = ref _rotationFilte.Get2(item).rotation;

                transform.Rotate(new Vector3(0, rotation, 0));
            }
        }
    }
}
