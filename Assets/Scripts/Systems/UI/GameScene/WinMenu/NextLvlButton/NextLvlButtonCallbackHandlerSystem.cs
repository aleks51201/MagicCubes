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
                Debug.Log("NextLvlButtonCallbackHandlerSystem");
                _btnFilter.GetEntity(index).Del<NextLvlButtonToMenuButtonClickEvent>();
                if (!_btnFilter.Get2(index).ButtonStatusHolder.IsClicked)
                {
                    continue;
                }
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
                _world.NewEntity().Get<ClosedWinMenuEvent>();
                foreach(var i in _currentFilter)
                {
                    Debug.Log("NextLvlButtonCallbackHandlerSystem _currentFilter");
                    int id = _currentFilter.Get1(i).Id + 1;
                    if(id < _configurations.LvlHolderConfig.SceneNames.Length)
                    {
                        SceneManager.LoadScene(_configurations.LvlHolderConfig.SceneNames[id]);
                    }
                    else
                    {
                        SceneManager.LoadScene(MenuScene);
                    }
                }
            }
        }
    }
}
