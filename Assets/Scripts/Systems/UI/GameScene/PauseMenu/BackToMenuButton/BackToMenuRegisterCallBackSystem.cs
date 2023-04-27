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
        private readonly EcsFilter<ClosedPauseMenuEvent> _closedPauseMenuFilter = null;
        private readonly EcsFilter<ClosedWinMenuEvent> _closedWinMenuFilter = null;

        private const string BackToMenu = "BackToMenu";

        public void Run()
        {
            foreach (var index in _openedPauseMenuFilter)
            {
                Register(index);
            }
            foreach (var index in _openedWinMenuFilter)
            {
                //_openedPauseMenuFilter.GetEntity(index).Del<OpenedWinMenuEvent>();
                Register(index);
            }
            foreach (var index in _closedPauseMenuFilter)
            {
                Unregister(index);
            }
            foreach (var index in _closedWinMenuFilter)
            {
                Unregister(index);
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
                        ButtonStatusHolder = new()
                    };
                    _ecsWorld.NewEntity().Get<BackToMenuButtonComponent>() = backBtnComponent;
                    backBtnComponent.Button = btn;
                    btn.clicked += backBtnComponent.ButtonStatusHolder.OnClicked;
                    btn.clicked += OnClick;
                }
            }
        }

        private void Unregister(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                foreach (var i in _backMenuBtnFilter)
                {
                    Button btn = _backMenuBtnFilter.Get1(i).Button;
                    var backBtnComponent = _backMenuBtnFilter.Get1(i);
                    btn.clicked -= backBtnComponent.ButtonStatusHolder.OnClicked;
                    btn.clicked -= OnClick;
                    _backMenuBtnFilter.GetEntity(i).Destroy();
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
