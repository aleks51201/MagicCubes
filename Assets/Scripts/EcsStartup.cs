using Leopotam.Ecs;
using MagicCubes.Config;
using MagicCubes.Cube;
using MagicCubes.Ui;
using Systems.UI;
using UnityEngine;
using Voody.UniLeo;

namespace MagicCubes
{
    public class EcsStartup : MonoBehaviour
    {
        [SerializeField] private Configurations _configurations;

        private EcsWorld _world;
        private EcsSystems _systems;


        private void AddInjections()
        {
            _systems
                .Inject(_configurations);
        }

        private void AddOneFrames()
        {
            _systems
                .OneFrame<WinEvent>()
                .OneFrame<StartButtonClickedEvent>();
        }

        private void AddSystems()
        {
            _systems
                .Add(new CreateEntityForUIVisualElementSystem())
                .Add(new StartButtonRegisterCallbackSystem())
                .Add(new StartButtonClickHandlerSystem())
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
