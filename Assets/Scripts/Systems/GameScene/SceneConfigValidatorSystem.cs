using Leopotam.Ecs;
using MagicCubes.Config;
using System;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems
{
    internal sealed class SceneConfigValidatorSystem : IEcsInitSystem
    {
        private readonly Configurations _configurations = null;

        public void Init()
        {
            foreach (LvlData lvlData in _configurations.LvlHolderConfig.LvlData)
            {
                var scene = SceneManager.GetSceneByName(lvlData.SceneName);
                if (scene.name != lvlData.SceneName)
                {
                    throw new ArgumentException($"Scene with name = {lvlData.SceneName} not exist");
                }
            }
        }
    }

}
