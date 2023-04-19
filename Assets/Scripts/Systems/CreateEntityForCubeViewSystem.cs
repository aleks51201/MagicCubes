﻿using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Config;
using MagicCubes.Tag;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems
{
    internal sealed class CreateEntityForCubeViewSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CubeInitComponent> _initFilter = null;


        public void Init()
        {
            foreach (var item in _initFilter)
            {
                ref var init = ref _initFilter.Get1(item);
                var cubeView = init.cubeView;
                ref var entity = ref _initFilter.GetEntity(item);
                entity.Get<CubeTag>();

                cubeView.ecsEntity = entity;
            }
        }
    }

}
