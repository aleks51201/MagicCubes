using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Events;
using MagicCubes.Tag;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCubes.Systems
{
    sealed class WinRotationCheckSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CubeTag, EndRotateEvent> _cubeFilter = null;

        public void Run()
        {
            List<CubeInitComponent> winComonents = new();
            int entityCount = _cubeFilter.GetEntitiesCount();
            foreach (var index in _cubeFilter)
            {
                ref var entity = ref _cubeFilter.GetEntity(index);
                var transform = entity.Get<CubeInitComponent>().cubeView.transform;
                ref var winYRotaion = ref entity.Get<CubeInitComponent>().winYRotation;

                if (transform.rotation.eulerAngles.y == winYRotaion)
                {
                    winComonents.Add(entity.Get<CubeInitComponent>());
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
