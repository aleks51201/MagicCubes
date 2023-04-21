using Leopotam.Ecs;
using MagicCubes.Config;
using UnityEngine;
using Voody.UniLeo;

namespace MagicCubes
{
    public abstract class EcsStartupBase : MonoBehaviour
    {
        [SerializeField] private protected Configurations _configurations;

        private protected EcsWorld _world;
        private protected EcsSystems _systems;


        private protected abstract void AddOneFrames();
        private protected abstract void AddSystems();

        private protected virtual void AddInjections()
        {
            _systems
                .Inject(_configurations);
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
