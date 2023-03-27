using Leopotam.Ecs;
using MagicCubes.Cube;
using UnityEngine;
using Voody.UniLeo;

namespace MagicCubes
{
    public class EcsStartup : MonoBehaviour
    {
        public CubeView[] cubeViews;

        private EcsWorld _world;
        private EcsSystems _systems;


        private void AddInjections()
        {
            _systems
                .Inject(cubeViews);
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<WinEvent>();
        }

        private void AddSystems()
        {
            _systems
                .Add(new CreateEntityForCubeViewSystem())
                .Add(new RotationSystem())
                .Add(new WinRotationCheckSystem())
                .Add(new WinSystem());
        }

        private void Start()
        {
            _world = new();
            _systems = new(_world);

            _systems.ConvertScene();
            AddInjections();
            AddOneFrames();
            AddSystems();
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            if (_systems is null)
            {
                return;
            }
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}
