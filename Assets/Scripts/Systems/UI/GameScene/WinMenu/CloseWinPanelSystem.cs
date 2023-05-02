using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems
{
    internal sealed class CloseWinPanelSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<BackButtonToMenuButtonClickEvent> _bactToMenuButtonFilter = null;
        private readonly EcsFilter<ResetButtonClickEvent> _resetButtonFilter = null;
        private readonly EcsFilter<NextLvlButtonToMenuButtonClickEvent> _nextLvlButtonFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string ButtonsUIHolder = "ButtonsUIHolder";
        private const string OnWinMenu = "OnWinMenu";


        public void Run()
        {
            foreach (var i in _bactToMenuButtonFilter)
            {
                CloseWinMenu();
                _bactToMenuButtonFilter.GetEntity(i).Del<BackButtonToMenuButtonClickEvent>();
            }
            foreach (var i in _resetButtonFilter)
            {
                CloseWinMenu();
                _resetButtonFilter.GetEntity(i).Del<ResetButtonClickEvent>();
            }
            foreach (var i in _nextLvlButtonFilter)
            {
                CloseWinMenu();
                _nextLvlButtonFilter.GetEntity(i).Del<NextLvlButtonToMenuButtonClickEvent>();
            }
        }

        private void CloseWinMenu()
        {
            foreach (var i in _uiFilter)
            {
                VisualElement winPanel = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(OnWinMenu);
                VisualElement btnUiHolder = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ButtonsUIHolder);
                btnUiHolder.style.display = DisplayStyle.None;
                winPanel.style.display = DisplayStyle.None;
                _world.NewEntity().Get<ClosedWinMenuEvent>();
            }
        }
    }
}
