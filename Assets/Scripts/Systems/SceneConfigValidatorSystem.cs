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
            foreach (string sceneName in _configurations.LvlHolderConfig.SceneNames)
            {
                var scene = SceneManager.GetSceneByName(sceneName);
                if (scene.name != sceneName)
                {
                    throw new ArgumentException($"Scene with name = {sceneName} not exist");
                }
            }
        }
    }

}
