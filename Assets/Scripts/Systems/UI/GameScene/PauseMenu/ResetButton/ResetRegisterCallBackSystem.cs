using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class ResetRegisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<ResetButtonComponent> _resetBtnFilter = null;
        private readonly EcsFilter<OpenedPauseMenuEvent> _openedPauseMenuFilter = null;
        private readonly EcsFilter<OpenedWinMenuEvent> _openedWinMenuFilter = null;
        private readonly EcsFilter<ClosedPauseMenuEvent> _closedPauseMenuFilter = null;
        private readonly EcsFilter<ClosedWinMenuEvent> _closedWinMenuFilter = null;

        private const string ResetGame = "ResetGame";

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
                var btns = _uiFilter.Get1(index).UIDocument.rootVisualElement.Query<Button>(ResetGame).ToList();
                foreach (var btn in btns)
                {
                    var resetComponent = new ResetButtonComponent()
                    {
                        Button = btn,
                        ButtonStatusHolder = new()
                    };
                    _ecsWorld.NewEntity().Get<ResetButtonComponent>() = resetComponent;
                    resetComponent.Button = btn;
                    btn.clicked += resetComponent.ButtonStatusHolder.OnClicked;
                    btn.clicked += OnClick;
                }
            }
        }

        private void Unregister(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                foreach (var i in _resetBtnFilter)
                {
                    Button btn = _resetBtnFilter.Get1(i).Button;
                    var resetComponent = _resetBtnFilter.Get1(i);
                    btn.clicked -= resetComponent.ButtonStatusHolder.OnClicked;
                    btn.clicked -= OnClick;
                }
            }
        }

        private void OnClick()
        {
            foreach (var index in _resetBtnFilter)
            {
                _resetBtnFilter.GetEntity(index).Get<ResetButtonClickEvent>();
            }
        }
    }
}
