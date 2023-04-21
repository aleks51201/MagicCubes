using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class BackToMenuRegisterCallBackSystem : IEcsRunSystem 
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<OpenedPauseMenuEvent> _openedEventFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<BackToMenuButtonComponent> _backMenuBtnFilter = null;

        private const string BackToMenu = "BackToMenu";

        public void Run()
        {
            foreach(var index in _openedEventFilter)
            {
                foreach(var indexJ in _uiFilter)
                {
                    Button btn = _uiFilter.Get1(index).UIDocument.rootVisualElement.Q<Button>(BackToMenu);
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

        private void OnClick()
        {
            foreach (var index in _backMenuBtnFilter)
            {
                _backMenuBtnFilter.GetEntity(index).Get<BackButtonToMenuButtonClickEvent>();
            }
        }
    }
}
