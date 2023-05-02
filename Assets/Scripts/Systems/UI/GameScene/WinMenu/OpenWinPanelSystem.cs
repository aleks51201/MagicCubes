using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems
{
    internal sealed class OpenWinPanelSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<WinEvent> _winFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string ButtonsUIHolder = "ButtonsUIHolder";
        private const string OnWinMenu = "OnWinMenu";
        private const string GameUI = "GameUI";


        public void Run()
        {
            foreach (var i in _uiFilter)
            {
                VisualElement winPanel = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(OnWinMenu);
                VisualElement btnUiHolder = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(ButtonsUIHolder);
                VisualElement gameUi = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(GameUI);
                foreach (var index in _winFilter)
                {
                    btnUiHolder.style.display = DisplayStyle.Flex;
                    winPanel.style.display = DisplayStyle.Flex;
                    gameUi.style.display = DisplayStyle.None;

                    _world.NewEntity().Get<OpenedWinMenuEvent>();
                }
            }
        }
    }
}
