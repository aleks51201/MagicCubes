using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class ResetRegisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<OpenedPauseMenuEvent> _openedEventFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<ResetButtonComponent> _resetBtnFilter = null;

        private const string ResetGame= "ResetGame";

        public void Run()
        {
            foreach(var index in _openedEventFilter)
            {
                foreach(var indexJ in _uiFilter)
                {
                    Button btn = _uiFilter.Get1(index).UIDocument.rootVisualElement.Q<Button>(ResetGame);
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

        private void OnClick()
        {
            foreach (var index in _resetBtnFilter)
            {
                _resetBtnFilter.GetEntity(index).Get<ResetButtonClickEvent>();
            }
        }
    }
}
