using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Config;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class LvlInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly Configurations _configurations;


        public void Init()
        {
            ref var currentLvlComponent = ref _world.NewEntity().Get<CurrentLvlComponent>();
            currentLvlComponent.SceneName = SceneManager.GetActiveScene().name;
            int id = 0;
            foreach (LvlData lvlData in _configurations.LvlHolderConfig.LvlData)
            {
                if (lvlData.SceneName == currentLvlComponent.SceneName)
                {
                    currentLvlComponent.Id = id;
                    return;
                }
                id++;
            }
        }
    }
}
