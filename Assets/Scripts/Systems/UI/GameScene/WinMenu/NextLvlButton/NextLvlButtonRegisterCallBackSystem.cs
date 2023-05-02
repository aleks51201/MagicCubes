using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class NextLvlButtonRegisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<NextLvlButtonComponent> _nextLvlBtnFilter = null;
        private readonly EcsFilter<OpenedWinMenuEvent> _openedWinMenuFilter = null;

        private const string NextLevel = "NextLevel";

        public void Run()
        {
            foreach (var index in _openedWinMenuFilter)
            {
                Register(index);
            }
        }

        private void Register(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                var btns = _uiFilter.Get1(index).UIDocument.rootVisualElement.Query<Button>(NextLevel).ToList();
                foreach (var btn in btns)
                {
                    var backBtnComponent = new NextLvlButtonComponent()
                    {
                        Button = btn,
                        ButtonStatusHolder = new(),
                        ButtonEventProceeder = new(btn)
                    };

                    backBtnComponent.ButtonEventProceeder.Subscribe(backBtnComponent.ButtonStatusHolder.OnClicked);
                    backBtnComponent.ButtonEventProceeder.Subscribe(OnClick);
                    _ecsWorld.NewEntity().Get<NextLvlButtonComponent>() = backBtnComponent;
                }
            }
        }

        private void OnClick()
        {
            foreach (var index in _nextLvlBtnFilter)
            {
                _nextLvlBtnFilter.GetEntity(index).Get<NextLvlButtonToMenuButtonClickEvent>();
            }
        }
    }
}
