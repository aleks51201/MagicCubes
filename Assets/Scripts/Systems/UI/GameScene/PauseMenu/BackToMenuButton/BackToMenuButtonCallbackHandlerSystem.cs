using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems.UI
{
    internal sealed class BackToMenuButtonCallbackHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BackButtonToMenuButtonClickEvent, BackToMenuButtonComponent> _btnFilter = null;

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
                SceneManager.LoadScene(MenuScene);
            }
        }
    }
}
