using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
                _btnFilter.GetEntity(index).Del<BackButtonToMenuButtonClickEvent>();
                if (!_btnFilter.Get2(index).ButtonStatusHolder.IsClicked)
                {
                    continue;
                }
                SceneManager.LoadScene(MenuScene);
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
            }
        }
    }
}
