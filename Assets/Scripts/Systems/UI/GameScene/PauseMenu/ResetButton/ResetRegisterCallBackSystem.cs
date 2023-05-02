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
                        ButtonStatusHolder = new(),
                        ButtonEventProceeder = new(btn)
                    };
                    resetComponent.ButtonEventProceeder.Subscribe(resetComponent.ButtonStatusHolder.OnClicked);
                    resetComponent.ButtonEventProceeder.Subscribe(OnClick);
                    _ecsWorld.NewEntity().Get<ResetButtonComponent>() = resetComponent;
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
