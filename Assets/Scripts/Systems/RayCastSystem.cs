using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Components.GameScene;
using UnityEngine;

namespace MagicCubes.Systems
{
    public class RayCastSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<RayCastComponent> _rayFilter;
        private readonly EcsFilter<CameraComponent> _cameraFilter;


        public void Init()
        {
            _world.NewEntity().Get<RayCastComponent>();
        }

        public void Run()
        {
            foreach (int i in _cameraFilter)
            {
                foreach (int j in _rayFilter)
                {
                    RaycastHit hit;
                    Camera camera = _cameraFilter.Get1(i).Camera;
                    //LayerMask layerMask = _cameraFilter.Get1(i).LayerMask;
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        _rayFilter.Get1(j).RaycastHit = hit;
                    }
                }
            }
        }
    }
}
