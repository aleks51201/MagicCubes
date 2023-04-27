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
        private readonly EcsFilter<ClosedWinMenuEvent> _closedWinMenuFilter = null;

        private const string NextLevel = "NextLevel";

        public void Run()
        {
            foreach (var index in _openedWinMenuFilter)
            {
                Register(index);
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
                var btns = _uiFilter.Get1(index).UIDocument.rootVisualElement.Query<Button>(NextLevel).ToList();
                foreach (var btn in btns)
                {
                    var backBtnComponent = new NextLvlButtonComponent()
                    {
                        Button = btn,
                        ButtonStatusHolder = new()
                    };
                    _ecsWorld.NewEntity().Get<NextLvlButtonComponent>() = backBtnComponent;
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
                foreach (var i in _nextLvlBtnFilter)
                {
                    Button btn = _nextLvlBtnFilter.Get1(i).Button;
                    var backBtnComponent = _nextLvlBtnFilter.Get1(i);
                    btn.clicked -= backBtnComponent.ButtonStatusHolder.OnClicked;
                    btn.clicked -= OnClick;
                    _nextLvlBtnFilter.GetEntity(i).Destroy();
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
