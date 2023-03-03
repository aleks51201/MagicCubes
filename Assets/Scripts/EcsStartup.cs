using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

public class EcsStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsSystems _systems;


    private void AddSystems()
    {

    }

    private void AddInjections()
    {

    }

    private void AddOneFrames()
    {

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
