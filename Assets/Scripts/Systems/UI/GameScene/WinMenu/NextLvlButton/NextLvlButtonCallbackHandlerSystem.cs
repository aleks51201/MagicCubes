using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Config;
using MagicCubes.Events.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems.UI
{
    internal sealed class NextLvlButtonCallbackHandlerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<NextLvlButtonToMenuButtonClickEvent, NextLvlButtonComponent> _btnFilter = null;
        private readonly EcsFilter<CurrentLvlComponent> _currentFilter = null;
        private readonly Configurations _configurations;

        private const string MenuScene = "MenuScene";

        public void Run()
        {
            foreach (var index in _btnFilter)
            {
                if (!_btnFilter.Get2(index).ButtonStatusHolder.IsClicked)
                {
                    continue;
                }
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
                string sceneName = SceneManager.GetActiveScene().name;
                int numSceneName = 0;
                for(var i = 0; i< _configurations.LvlHolderConfig.LvlData.Length; i++)
                {
                    if(_configurations.LvlHolderConfig.LvlData[i].SceneName == sceneName)
                    {
                        numSceneName = i;
                        break;
                    }
                }
                if (numSceneName + 1 < _configurations.LvlHolderConfig.LvlData.Length && numSceneName != 0)
                {
                    SceneManager.LoadScene(_configurations.LvlHolderConfig.LvlData[numSceneName + 1].SceneName);
                }
                else
                {
                    SceneManager.LoadScene(MenuScene);
                }
            }
        }
    }
}
