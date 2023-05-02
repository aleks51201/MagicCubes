using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class BackToMenuRegisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<BackToMenuButtonComponent> _backMenuBtnFilter = null;
        private readonly EcsFilter<OpenedPauseMenuEvent> _openedPauseMenuFilter = null;
        private readonly EcsFilter<OpenedWinMenuEvent> _openedWinMenuFilter = null;

        private const string BackToMenu = "BackToMenu";

        public void Run()
        {
            foreach (var index in _openedPauseMenuFilter)
            {
                Register(index);
            }
            foreach (var index in _openedWinMenuFilter)
            {
                Register(index);
            }
        }

        private void Register(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                var btns = _uiFilter.Get1(index).UIDocument.rootVisualElement.Query<Button>(BackToMenu).ToList();
                foreach (var btn in btns)
                {
                    var backBtnComponent = new BackToMenuButtonComponent()
                    {
                        Button = btn,
                        ButtonStatusHolder = new(),
                        ButtonEventProceeder = new(btn)
                    };
                    backBtnComponent.ButtonEventProceeder.Subscribe(backBtnComponent.ButtonStatusHolder.OnClicked);
                    backBtnComponent.ButtonEventProceeder.Subscribe(OnClick);
                    _ecsWorld.NewEntity().Get<BackToMenuButtonComponent>() = backBtnComponent;
                }
            }
        }

        private void OnClick()
        {
            foreach (var index in _backMenuBtnFilter)
            {
                _backMenuBtnFilter.GetEntity(index).Get<BackButtonToMenuButtonClickEvent>();
            }
        }
    }
}
